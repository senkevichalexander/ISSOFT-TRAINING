using Microsoft.Extensions.Configuration;

namespace FinalTask
{
    public static class ConfigurationHelper
    {
        public static IConfiguration InitAppConfig()
        {
            var config = new ConfigurationBuilder()
                   .AddJsonFile("applicationConfig.json")
                   .Build();

            return config;
        }
    }
}
