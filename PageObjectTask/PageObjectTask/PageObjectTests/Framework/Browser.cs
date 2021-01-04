using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.IO;

namespace PageObjectTests
{
    public static class Browser
    {


        //private const string chromeDriver = "chromedriver";
        private static IWebDriver WebDriver { get; set; }
        public static string BrowserName => ((RemoteWebDriver)WebDriver).Capabilities.GetCapability("browserName").ToString();
        public static string BrowserVersion => ((RemoteWebDriver)WebDriver).Capabilities.GetCapability("browserVersion").ToString();

        public static void Initializes(bool maximized = true)
        {
            WebDriver = DriverHelper.FactoryDriver();

            //var uri = new Uri("http://localhost:4444/wd/hub");
            //var capabilities = new ChromeOptions().ToCapabilities();
            //var commandTimeout = TimeSpan.FromMinutes(5);
            //WebDriver = new RemoteWebDriver(uri, capabilities, commandTimeout);

            //var uri = new Uri("https://aois:a52a20c9-4d18-4697-9c98-6ec38307f493@ondemand.us-west-1.saucelabs.com:443/wd/hub");
            //var ffOptions = new FirefoxOptions();
            //ffOptions.PlatformName = "Windows 8.1";
            //ffOptions.BrowserVersion = "39.0";
            //var sauceOptions = new Dictionary<string, object>();

            //sauceOptions.Add("name", TestContext.CurrentContext.Test.Name);

            ////sauceOptions.Add("seleniumVersion", "2.53.1")

            //ffOptions.AddAdditionalCapability("sauce:options", sauceOptions, true);
            //ffOptions.AddAdditionalCapability("seleniumVersion", "2.53.0");
            //ffOptions.AddAdditionalCapability("marionettte", false);
            //WebDriver = new RemoteWebDriver(uri, ffOptions);


            if (maximized)
            {
                WebDriver.Manage().Window.Maximize();
            }
        }

        public static IWebDriver Driver
        {
            get
            {
                return WebDriver;
            }
        }

        public static void GoToPage(PageBase page)
        {
            WebDriver.Navigate().GoToUrl(page.PageUrl);
        }

        public static void Quit()
        {
            WebDriver.Quit();
            //KillDriverProcesses();
        }

        public static void PrintScreen(string fileName, ScreenshotImage‌​Format ScreenshotImage‌​Format, string path = null)
        {
            if (WebDriver == null)
                return;

            if (string.IsNullOrEmpty(path))
                path = Directory.GetCurrentDirectory() + @"\..\..\..\Screenshots\";
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var file = path + fileName + "." + ScreenshotImage‌​Format.ToString();
            Screenshot ss = ((ITakesScreenshot)WebDriver).GetScreenshot();
            ss.SaveAsFile(file, ScreenshotImage‌​Format);
        }

        //private static void KillDriverProcesses()
        //{
        //    var driverName = WebDriver.GetType().Name.ToLower();
        //    string processName = String.Empty;
        //    if (driverName == chromeDriver)
        //    {
        //        processName = chromeDriver;
        //    }
        //    if (!String.IsNullOrEmpty(processName))
        //    {
        //        var processes = Process.GetProcesses().Where(p => p.ProcessName.ToLower() == processName);
        //        foreach (var process in processes)
        //        {
        //            process.Kill();
        //        }
        //    }
        //}

        public static void ImplicitlyWait(int seconds)
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public static void WaitForElementExists(IWebElement element, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(seconds));
            wait.Until((webDriver => element.Displayed && element.Enabled));
        }
    }
}
