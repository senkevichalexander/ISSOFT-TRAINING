using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace PageObjectTests
{
    public static class Browser
    {
        private const string chromeDriver = "chromedriver";
        private static IWebDriver WebDriver { get; set; }

        public static void Initializes(bool maximized = true)
        {
            WebDriver = DriverHelper.FactoryDriver();

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
