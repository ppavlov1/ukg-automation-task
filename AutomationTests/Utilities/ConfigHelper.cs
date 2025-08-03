using Microsoft.Extensions.Configuration;
using System.IO;

namespace AutomationTests.Utilities
{
    public static class ConfigHelper
    {
        private static readonly IConfigurationRoot _configuration;

        static ConfigHelper()
        {
            var basePath = Path.Combine(Directory.GetCurrentDirectory(), @"..\..\..");
            basePath = Path.GetFullPath(basePath);

            _configuration = new ConfigurationBuilder()
                .SetBasePath(basePath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static string BaseUrl => _configuration["BaseUrl"];
        public static string Username => _configuration["Username"];
        public static string Password => _configuration["Password"];
    }
}
