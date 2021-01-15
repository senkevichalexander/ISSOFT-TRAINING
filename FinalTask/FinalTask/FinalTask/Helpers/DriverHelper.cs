using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;

namespace FinalTask.Helpers
{

    public static class DriverHelper
    {
        public static IWebDriver FactoryDriver()
        {
            var path = AppDomain.CurrentDomain.BaseDirectory;
            var type = GetBrowserType();

            switch (type)
            {
                case "FireFox":
                    return new FirefoxDriver(path);
                case "Chrome":
                    return new ChromeDriver();
                case "Grid":
                    var uri = new Uri("http://localhost:4444/wd/hub");
                    var capabilities = new ChromeOptions().ToCapabilities();
                    var commandTimeout = TimeSpan.FromMinutes(5);
                    return new RemoteWebDriver(uri, capabilities, commandTimeout);
                case "SauceLabs":
                    var cloudUri = new Uri("https://aois:a52a20c9-4d18-4697-9c98-6ec38307f493@ondemand.us-west-1.saucelabs.com:443/wd/hub");
                    var sauceOptions = new Dictionary<string, object>();
                    sauceOptions.Add("name", TestContext.CurrentContext.Test.Name);
                    var browserOptions = new ChromeOptions
                    {
                        UseSpecCompliantProtocol = true,
                        PlatformName = "Windows 10",
                        BrowserVersion = "75.0"
                    };
                    browserOptions.AddAdditionalCapability("sauce:options", sauceOptions, true);
                    var cloudCommandTimeout = TimeSpan.FromMinutes(5);
                    return new RemoteWebDriver(cloudUri, browserOptions.ToCapabilities(), cloudCommandTimeout);
                default:
                    throw new Exception("The driver doesn't exist. Current drivers allowed: Chrome");
            }
        }

        private static string GetBrowserType() 
            => ConfigurationHelper.InitAppConfig().GetSection("WebDriverType").Value.ToString();
    }
}
