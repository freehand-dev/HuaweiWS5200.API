using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using HuaweiWS5200.API;
using HuaweiWS5200.API.DTOs.ntwk;
using HuaweiWS5200.API.DTOs.system;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Text.Json;

var host = new HostBuilder()
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddCommandLine(args);
        config.AddEnvironmentVariables();
    })
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHttpClient<HuaweiWS5200Client>((sp, c) =>
        {
            IConfiguration configuration = sp.GetRequiredService<IConfiguration>();
            c.BaseAddress = new Uri(configuration.GetValue<string>("uri") ?? @"http://192.168.3.1");
            c.Timeout = TimeSpan.FromSeconds(5);
        });
    })
    .ConfigureLogging((hostContext, logging) =>
    {   
        logging.ClearProviders();
        logging.AddConsole();
        logging.SetMinimumLevel(LogLevel.Debug);
        //logging.AddSimpleConsole(options => options.IncludeScopes = true);
        //Provided by Microsoft.Extensions.Logging.Console
        //logging.AddSimpleConsole(options => options.TimestampFormat = "[HH:mm:ss] ");
        //logging.AddJsonConsole(options => { });
        //logging.AddSystemdConsole(options => { });
    })
    .Build();

ILogger<Program> _logger = host.Services.GetRequiredService<ILogger<Program>>();
IConfiguration _configuration = host.Services.GetRequiredService<IConfiguration>();
HuaweiWS5200Client client = host.Services.GetRequiredService<HuaweiWS5200Client>();

try
{
    // Get options 
    string username = _configuration.GetValue<string>("user") ?? "admin";
    string password = _configuration.GetValue<string>("password") ?? throw new ArgumentException("password is null or empty");

    //   
    await client.LoginAsync(username, password);
    try
    {

        await client.EnableGuestNetworkAsync();
        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!");
        await Task.Delay(5000);
        await client.DisableGuestNetworkAsync();
        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!");
        await Task.Delay(5000);
        await client.EnableGuestNetworkAsync();
        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!");
        await Task.Delay(5000);
        await client.DisableGuestNetworkAsync();
        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!");
        await Task.Delay(5000);
        await client.EnableGuestNetworkAsync();
        Console.WriteLine("!!!!!!!!!!!!!!!!!!!!");
        await Task.Delay(5000);
        await client.DisableGuestNetworkAsync();

        throw new Exception("exit");


        IEnumerable<Wan> wan = await client.GetWanAsync();
        _logger.LogInformation(wan.FirstOrDefault()?.IPv4Addr);

        WanDetect wanDetect = await client.GetWanDetectAsync();
        _logger.LogInformation(wanDetect.ExternalIPAddress);

        IEnumerable<GuestNetwork> guestNetwork = await client.GetGuestNetworkAsync();
        _logger.LogInformation(guestNetwork.FirstOrDefault()?.WifiSsid);

        DeviceInfo deviceInfo = await client.GetDeviceInfoAsync();
        _logger.LogInformation(Convert.ToString(deviceInfo.UpTime ?? -1));


        WanDiagnose wanDiagnose = await client.GetWanDiagnoseAsync();
        IEnumerable<HostInfo> hostInfo = await client.GetHostInfoAsync();
        foreach (var item in hostInfo)
        {
            _logger.LogInformation(item.HostName ?? "-");
        }
    }
    finally
    {
        await client.LogoutAsync();
    }

}
catch (Exception ex)
{
    _logger.LogError(ex, "HuaweiWS5200Client error.");
}


