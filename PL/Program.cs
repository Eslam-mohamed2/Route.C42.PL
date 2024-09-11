using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PL
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var HostBuilder = CreateHostBuilder(args).Build();

            // Date Seeding 
            // Apply Migrations 

            HostBuilder.Run(); // Application is Ready for Requests
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
