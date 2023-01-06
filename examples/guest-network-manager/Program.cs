using HuaweiWS5200.API;
using HuaweiWS5200.API.DTOs.ntwk;
using Microsoft.Extensions.Configuration;

// ConfigurationBuilder
IConfiguration config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddCommandLine(args)
    .Build();

// Get options
string host = config.GetValue<string>("host") ?? throw new ArgumentException("host is null or empty");
string username = config.GetValue<string>("username") ?? throw new ArgumentException("username is null or empty");
string password = config.GetValue<string>("password") ?? throw new ArgumentException("password is null or empty");
string operation = config.GetValue<string>("guest_network") ?? throw new ArgumentException("guest_network argument is null or empty");

// HuaweiWS5200Client
HuaweiWS5200Client client = new HuaweiWS5200Client(
    new HttpClient() {
            BaseAddress = new Uri(host),
            Timeout = TimeSpan.FromSeconds(5),
    });

//main
await client.LoginAsync(username, password);
try
{
    switch (operation)
    {
        case "status":
            bool isEnabled = await client.IsGuestNetworkEnabledAsync();
            Console.WriteLine(isEnabled ? "on" : "off");
            break;
        case "run":
        case "enable":
        case "start":
            await client.EnableGuestNetworkAsync();
            break;
        case "disable":
        case "stop":
            await client.DisableGuestNetworkAsync();
            break;
        default:
            throw new Exception("Operation not supported");
    }
}
finally
{
    await client.LogoutAsync();
}