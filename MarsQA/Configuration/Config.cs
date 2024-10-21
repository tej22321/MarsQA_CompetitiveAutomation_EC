using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace MarsQA.Configuration
{
    public class Config
    {

        public static IConfigurationRoot Configuration { get; set; }
        static Config() {
            try
            {
                var builder = new ConfigurationBuilder()
                        .SetBasePath(Directory.GetCurrentDirectory())
                        .AddJsonFile("appsettings.json");   

                Configuration = builder.Build();
                Console.WriteLine("current directory" + Directory.GetCurrentDirectory);

                Console.WriteLine($"URL: {Configuration["TestSettings:Url"]}");
                Console.WriteLine($"Username: {Configuration["TestSettings:Username"]}");
                Console.WriteLine($"Password: {Configuration["TestSettings:Password"]}");
            }
            catch(Exception ex) {
                Console.WriteLine($"Failed to initialize configuration: {ex.Message}"); 
                throw new Exception("Failed to load configuration settings.", ex);

            }
        }
        public static string Url => Configuration["TestSettings:Url"] ?? throw new NullReferenceException("Url is not set in configuration.");
        public static string Username => Configuration["TestSettings:Username"] ?? throw new NullReferenceException("Username is not set in configuration.");
        public static string Password => Configuration["TestSettings:Password"] ?? throw new NullReferenceException("Password is not set in configuration.");



    }


}
