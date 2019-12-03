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
                
                // .UseUrls("http://localhost:52044", "http://odin:52044", "http://192.168.225.44:52044")
                .Build();

        // WebHost.CreateDefaultBuilder(args)
        //     .UseStartup<Startup>()
        //     .UseContentRoot(Directory.GetCurrentDirectory())
        //     .UseStartup<Startup>()
        //     .Build();

    }
}
