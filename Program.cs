using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Products
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfigurationRoot config = new ConfigurationBuilder()
        .SetBasePath(Directory.GetCurrentDirectory())
        .AddJsonFile("appsettings.json")
        .Build();
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
    //               .UseKestrel(options =>
    // {        // http:*:80
    //     options.Listen(IPAddress.Any, 443, listenOptions =>
    //     {
    //         listenOptions.UseHttps("C:\\Users\\Prateek\\Documents\\sslcertificate.pfx", "prateek");
    //     });
    // })
                .UseKestrel()
                
                // .UseUrls("https://localhost:5001", "http://odin:52044", "http://192.168.225.45:52044")
                .Build();
        // WebHost.CreateDefaultBuilder(args)
        //     .UseStartup<Startup>()
        //     .UseContentRoot(Directory.GetCurrentDirectory())
        //     .UseUrls("http://localhost:5000", "http://odin:5000", "http://192.168.43.15:5000")
        //     .UseIISIntegration()
        //     .UseStartup<Startup>()
        //     .Build();

    }
}
