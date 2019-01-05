using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
        WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
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
