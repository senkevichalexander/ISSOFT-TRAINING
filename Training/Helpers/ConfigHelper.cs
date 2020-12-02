using Microsoft.Extensions.Configuration;

namespace Training.Helpers
{
    class ConfigHelper
    {
            private static IConfigurationRoot config;

            public static IConfiguration GetConfiguration()
            {
                if (config == null)
                {
                    var config = new ConfigurationBuilder()
                    .AddJsonFile("appSettings.json")
                    .Build();
                }

                return config;
            }
        }
    }
