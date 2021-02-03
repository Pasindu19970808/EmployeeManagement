using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement
{
    public class Program
    {
        //entry point for the program
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        //this method calls the CreateDefaultBuilder method of the WebHost class
        //CreateDefaultBuilder methods sets up the webhost that hosts the application

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
