using System;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;

namespace HttpServer
{
    class Program
    {
        private static readonly int HttpsPort = 3333;
        private static readonly int HttpPort = 3334;
        private const string CertificateName = "localhost.pfx";
        private const string Password = "qwerty";

        static void Main()
        {
            var task = RegisterHttpRemoting();
            var host = task.Result;
            host.WaitForShutdownAsync().Wait();
        }


        private static async Task<IWebHost> RegisterHttpRemoting()
        {
            var certificate = new X509Certificate2(CertificateName, Password);

            var host = new WebHostBuilder()
                .UseKestrel(options =>
                    {
                        options.Listen(IPAddress.Loopback, HttpPort);
                        options.Listen(IPAddress.Loopback, HttpsPort, listenOptions =>
                        {
                            listenOptions.UseHttps(certificate);
                        });
                    })
                .UseStartup<Startup>()
                .UseContentRoot(AppContext.BaseDirectory)               
                .Build();
            await host.StartAsync();
            return host;
        }
    }
}
