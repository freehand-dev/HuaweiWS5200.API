using Microsoft.Extensions.Logging;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using HuaweiWS5200.API.DTOs;
using HuaweiWS5200.API.DTOs.ntwk;
using HuaweiWS5200.API.DTOs.system;

namespace HuaweiWS5200.API
{
    public class HuaweiWS5200Client
    {
        readonly string device_info = @"/api/system/deviceinfo";
        readonly string host_info = @"/api/system/HostInfo";
        readonly string guest_network = @"/api/ntwk/guest_network?type=notshowpassall";
        readonly string wan = @"/api/ntwk/wan";
        readonly string wan_detect = @"/api/ntwk/wandetect";
        readonly string login_page = @"/html/index.html#/login";
        readonly string user_login_nonce = @"/api/system/user_login_nonce";
        readonly string user_login_proof = @"/api/system/user_login_proof";
        readonly string heartbeat = @"/api/system/heartbeat";
        readonly string wandiagnose = @"/api/ntwk/wandiagnose";

        private readonly ILogger<HuaweiWS5200Client>? _logger;
        public HttpClient Client
        {
            get;
            set;
        }

        public Uri? BaseAddress
        {
            get
            {
                return this.Client?.BaseAddress;
            }
            set
            {
                this.Client.BaseAddress = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        private string? _csrf_param_proof;

        /// <summary>
        /// 
        /// </summary>
        private string? _csrf_token_proof;

        public bool LoggedIn { get => !string.IsNullOrEmpty(this._csrf_param_proof) && !string.IsNullOrEmpty(this._csrf_token_proof); }

        public HuaweiWS5200Client(HttpClient httpClient, ILogger<HuaweiWS5200Client>? logger = null)
        {
            this._logger = logger;
            this.Client = httpClient;
            this.Client.DefaultRequestHeaders.UserAgent.Add(new ProductInfoHeaderValue(new ProductHeaderValue(typeof(HuaweiWS5200Client).FullName ?? "HuaweiWS5200Client")));
            this.Client.DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/json;charset=UTF-8");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="activeOnly"></param>
        /// <returns></returns>
        public async Task<IEnumerable<Wan>> GetWanAsync(bool activeOnly = false)
        {
            var response = await this.Client.GetAsync($"{wan}{(activeOnly ? "?type=active" : string.Empty)}");
            using var contentStream = await response.Content.ReadAsStreamAsync();

            // try Deserialize first array, secondary object
            var arrayResult = new List<Wan>();
            try
            {
                var wans = await JsonSerializer.DeserializeAsync<IEnumerable<Wan>>(contentStream);
                if (wans != null)
                {
                    foreach (var wan in wans)
                    {
                        arrayResult.Add(wan);
                    }
                }
            } 
            catch
            {
                contentStream.Position = 0;
                var wan = await JsonSerializer.DeserializeAsync<Wan>(contentStream);
                if (wan != null)
                    arrayResult.Add(wan);
            }

            return arrayResult;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="config5g"></param>
        /// <param name="config2g"></param>
        /// <returns></returns>
        public async Task<GuestNetworkResponse?> ConfigGuestNetworkAsync(GuestNetwork? config2g, GuestNetwork? config5g)
        {
            //{"data":{
            //"config5g":
            //{"Enable":true,"ID":"InternetGatewayDevice.X_Config.Wifi.Radio.2.Ssid.2.","WifiSsid":"FreeWiFi_OnBlackout","ValidTime":3,"SecOpt":"none","WpaPreSharedKey":""},
            //"config2g":
            //{"Enable":true,"ID":"InternetGatewayDevice.X_Config.Wifi.Radio.1.Ssid.2.","WifiSsid":"FreeWiFi_OnBlackout","ValidTime":3,"SecOpt":"none","WpaPreSharedKey":""}},
            //"csrf":{"csrf_param":"WoRQ5Ea9cNkvDpSBl5OcOz0xNMZ2rA6p","csrf_token":"HX726dgtKRoONvfwgcz0OPpZQM2CtO5q"}}

            RequestData<GuestNetworkRequest> requestData = new RequestData<GuestNetworkRequest>(this._csrf_param_proof!, this._csrf_token_proof!, new GuestNetworkRequest()
            {
                Config2G = config2g,
                Config5G = config5g
            });

            return await PostAsync<GuestNetworkResponse>(guest_network, requestData);
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="requestUri"></param>
        /// <param name="content"></param>
        /// <returns></returns>
        internal async Task<T?> PostAsync<T>(string? requestUri, object content) where T : class
        {
            var requestContent = new StringContent(
                JsonSerializer.Serialize(
                    content,
                    new JsonSerializerOptions()
                    {
                        DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull
                    }
                ), Encoding.UTF8, "application/json");

            var response = await this.Client.PostAsync(requestUri, requestContent);
            response.EnsureSuccessStatusCode();

            string responseStr = await response.Content.ReadAsStringAsync();
            this._logger?.LogTrace($"POST {guest_network} response: {responseStr}");


            using var contentStream = await response.Content.ReadAsStreamAsync();

            T? result = await JsonSerializer.DeserializeAsync<T>(contentStream);
            if (result != null)
            {
                Csrf? csrf = result as Csrf;
                if (csrf != null)
                {
                    this._csrf_param_proof = csrf.CsrfParam;
                    this._csrf_token_proof = csrf.CsrfToken;
                }
            }
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="enable"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> EnableGuestNetworkAsync(bool enable = true)
        {
            this._logger?.LogDebug($"EnableGuestNetworkAsync, enable={enable}");

            IEnumerable<GuestNetwork> guestNetwork = await this.GetGuestNetworkAsync();

            bool isEnable = !guestNetwork.Any(c => c.EnableFrequency == false);
            this._logger?.LogDebug($"Guest Network is {(isEnable ? "On" : "Off")}");

            if (isEnable == enable)
            {
                this._logger?.LogDebug($"Skip, no action needed");
                return enable;
            }

            GuestNetwork? guestNetwork2g = guestNetwork.Where(s => (s.FrequencyBand ?? string.Empty).Equals("2.4GHz")).FirstOrDefault();
            GuestNetwork? guestNetwork5g = guestNetwork.Where(s => (s.FrequencyBand ?? string.Empty).Equals("5GHz")).FirstOrDefault();

            GuestNetwork? config2g = default;
            GuestNetwork? config5g = default;

            if (guestNetwork2g != null)
            {
                config2g = new GuestNetwork()
                {
                    Enable = enable,
                    ID = guestNetwork2g.ID
                };
            }
            if (guestNetwork5g != null)
            {
                config5g = new GuestNetwork()
                {
                    Enable = enable,
                    ID = guestNetwork5g.ID
                };
            }

            GuestNetworkResponse? guestNetworkResponse = await this.ConfigGuestNetworkAsync(config2g, config5g);

            if (guestNetworkResponse?.errcode != 0)
            {
                this._logger?.LogError($"ConfigGuestNetworkAsync error with code {guestNetworkResponse?.errcode}");
            }

            return guestNetworkResponse?.errcode == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task<bool> DisableGuestNetworkAsync()
        {
            return await this.EnableGuestNetworkAsync(false);
        }

        public async Task<bool> IsGuestNetworkEnabledAsync()
        {
            IEnumerable<GuestNetwork> guestNetwork = await this.GetGuestNetworkAsync();
            bool reasul = !guestNetwork.Any(c => c.EnableFrequency == false);
            return reasul;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<GuestNetwork>> GetGuestNetworkAsync()
        {
            var response = await this.Client.GetFromJsonAsync<IEnumerable<GuestNetwork>>(guest_network);
            return response ?? throw new Exception("GuestNetwork");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<IEnumerable<HostInfo>> GetHostInfoAsync()
        {
            var response = await this.Client.GetFromJsonAsync<IEnumerable<HostInfo>>(host_info);
            return response ?? throw new Exception("HostInfo");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<DeviceInfo> GetDeviceInfoAsync()
        {
            var response = await this.Client.GetFromJsonAsync<DeviceInfo>(device_info);
            return response ?? throw new Exception("GetDeviceInfoAsync");
        }

        public async Task<bool> HeartBeatAsync()
        {
            var response = await this.Client.GetAsync(heartbeat);
            return response.IsSuccessStatusCode;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <auth>none</auth>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<WanDetect> GetWanDetectAsync()
        {
            var response = await this.Client.GetFromJsonAsync<WanDetect>(wan_detect);
            return response ?? throw new Exception("GetWanDetectAsync");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<WanDiagnose> GetWanDiagnoseAsync()
        {
            var response = await this.Client.GetFromJsonAsync<WanDiagnose>(wandiagnose);
            return response ?? throw new Exception("GetWanDiagnoseAsync");
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public async Task<bool> LoginAsync(string username, string password)
        {
            #region 'first login'
            var responseLogin = await this.Client.GetAsync(login_page);
            responseLogin.EnsureSuccessStatusCode();
            var contentLoginString = await responseLogin.Content.ReadAsStringAsync();
            #endregion

            //
            RequestData<UserLoginNonceRequest> requestDataNonce = new RequestData<UserLoginNonceRequest>()
            {
                Data = new UserLoginNonceRequest()
                {
                    UserName = username,
                    FirstNonce =  UserLoginNonceRequest.GenrateFirstNonce(),
                },
                Csrf = new Csrf()
                {
                    CsrfParam = HuaweiWS5200Client.GetMetaContent(contentLoginString, "csrf_param") ?? throw new Exception("csrf_param is null"),
                    CsrfToken = HuaweiWS5200Client.GetMetaContent(contentLoginString, "csrf_token") ?? throw new Exception("csrf_token is null")
                }
            };

            #region 'UserLoginNonce'
            UserLoginNonce? userLoginNonce = await this.PostAsync<UserLoginNonce>(user_login_nonce, requestDataNonce);
            if (userLoginNonce?.Err != 0)
            {
                throw new Exception("UserLoginNonce failed");
            }
            #endregion

            #region 'crypt'
            byte[] clientProof = GetClientProof(
                password,
                userLoginNonce.Salt ?? throw new Exception("Salt is null"),
                userLoginNonce.Iterations ?? throw new Exception("Iterations is null"),
                requestDataNonce.Data.FirstNonce,
                userLoginNonce.ServerNonce ?? throw new Exception("ServerNonce is null")
            );

            _logger?.LogDebug($"clientProof: {Convert.ToHexString(clientProof)}");
            #endregion

            //
            RequestData<UserLoginProofRequest> requestDataProof = new RequestData<UserLoginProofRequest>(userLoginNonce.CsrfParam!, userLoginNonce.CsrfToken!,
                new UserLoginProofRequest()
                {
                    ClientProof = Convert.ToHexString(clientProof).ToLower(),
                    FinalNonce = userLoginNonce.ServerNonce,
                });


            #region 'UserLoginProof'
            UserLoginProof? userLoginProof = await this.PostAsync<UserLoginProof>(user_login_proof, requestDataProof);
            if (userLoginProof?.Err != 0)
            {
                throw new Exception("UserLoginProof failed");
            }
            #endregion

            return userLoginProof?.Err == 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public async Task LogoutAsync()
        {
            string user_logout = @"/api/system/user_logout";
            RequestData<UserLogoutRequest> requestData = new RequestData<UserLogoutRequest>(this._csrf_param_proof!, this._csrf_token_proof!);
            UserLogout? userLogout = await this.PostAsync<UserLogout>(user_logout, requestData);
            this._csrf_param_proof = null;
            this._csrf_token_proof = null;    
        }

       
        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="iterations"></param>
        /// <param name="firstNonce"></param>
        /// <param name="serverNonce"></param>
        /// <returns></returns>
        internal static byte[] GetClientProof(string password, string salt, int iterations, string firstNonce, string serverNonce)
        {
            string authMsg = $"{firstNonce},{serverNonce},{serverNonce}";

            byte[] saltPassword = PBKDF2(password, Convert.FromHexString(salt), iterations);

            var clientKey = HMACSHA256(Encoding.UTF8.GetBytes("Client Key"), saltPassword);
            var storeKey = SHA256.HashData(clientKey);
            var clientSignature = HMACSHA256(Encoding.UTF8.GetBytes(authMsg), storeKey);

            byte[] clientProof = new byte[32];
            for (int i = 0; i < clientProof.Length; i++)
            {
                clientProof[i] = (byte)(clientKey[i] ^ clientSignature[i]);
            }

            return clientProof;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="password"></param>
        /// <param name="salt"></param>
        /// <param name="iterations"></param>
        /// <param name="outputBytes"></param>
        /// <returns></returns>
        internal static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes = 32)
        {
            using (Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(Encoding.UTF8.GetBytes(password), salt, iterations, HashAlgorithmName.SHA256))
                return pbkdf2.GetBytes(outputBytes);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <param name="buffer"></param>
        /// <returns></returns>
        internal static byte[] HMACSHA256(byte[] key, byte[] buffer)
        {
            using (HMACSHA256 hash = new HMACSHA256(key))
                return hash.ComputeHash(buffer);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="html"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        internal static string? GetMetaContent(string html, string name)
        {
            var pattern = $"<meta\\s+name=\"{name}\"\\s+content=\"(?<content>\\w+)\"\\/>";
            Match m = Regex.Match(html, pattern, RegexOptions.IgnoreCase);
            m.Groups.TryGetValue("content", out Group? result);
            return result?.Value;
        }


    }
}
