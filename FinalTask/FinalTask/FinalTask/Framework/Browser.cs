using FinalTask.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace FinalTask.Framework
{
    public static class Browser
    {
        private static IWebDriver WebDriver { get; set; }
        public static string BrowserName => ((RemoteWebDriver)WebDriver)
            .Capabilities.GetCapability("browserName").ToString();
        public static string BrowserVersion => ((RemoteWebDriver)WebDriver)
            .Capabilities.GetCapability("browserVersion").ToString();

        public static void Initializes(bool maximized = true)
        {
            WebDriver = DriverHelper.FactoryDriver();

            if (maximized)
            {
                WebDriver.Manage().Window.Maximize();
                WebDriver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(30));
            }
        }

        public static IWebDriver Driver => WebDriver;

        public static void ReturnToPreviousPage()
        {
            WebDriver.Navigate().Back();
        }

        public static void Quit()
        {
            WebDriver.Quit();
        }

        public static void PrintScreen(string fileName, 
            ScreenshotImage‌​Format ScreenshotImage‌​Format, string path = null)
        {
            if (WebDriver == null)
                return;

            if (string.IsNullOrEmpty(path))
                path = Directory.GetCurrentDirectory() + @"\..\..\..\Screenshots\";

            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var file = path + fileName + "." + ScreenshotImage‌​Format.ToString();

            var ss = ((ITakesScreenshot)WebDriver).GetScreenshot();
            ss.SaveAsFile(file, ScreenshotImage‌​Format);
        }

        public static void ImplicitlyWait(int seconds)
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public static void ExplicitWait(int seconds, IWebElement element)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(seconds));
            wait.Until((webDriver => element.Displayed && element.Enabled));
        }

        public static void OverlayWait(int seconds)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy
                (By.CssSelector(".fancybox-overlay[style^='display: block;']")));
        }

        public static void WaitForElementExists(IWebElement element, int seconds)
        {
            var wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(webDriver => element.Displayed && element.Enabled);
        }

        public static string GetSelectedElementsText(IWebElement element)
        {
            var selectElement = new SelectElement(element);
            var elem = selectElement.SelectedOption.Text;

            return elem;
        }
    }
}
