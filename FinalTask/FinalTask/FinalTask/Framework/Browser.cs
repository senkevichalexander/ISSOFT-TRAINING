using FinalTask.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.UI;
using System;
using System.IO;

namespace FinalTask.Framework
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


        public static void ImplicitlyWait(int seconds)
        {
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(seconds);
        }

        public static void WaitForElementExists(IWebElement element, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(seconds));
            wait.Until((webDriver => element.Displayed && element.Enabled));
        }

        public static void WaitForElementIsVisible(IWebElement element, int seconds)
        {
            WebDriverWait wait = new WebDriverWait(WebDriver, TimeSpan.FromSeconds(seconds));
            wait.Until(x => element.Displayed);//ExpectedConditions.VisibilityOfAllElementsLocatedBy(element));// ;
        }

        public static void SwitchToFrame(IWebElement element)
        {
            Driver.SwitchTo().Frame(element);
        }

        public static void SwitchToDefaultContent()
        {
            Driver.SwitchTo().DefaultContent();
        }

        public static string GetSelectedElementsText(IWebElement element)
        {
            var selectElement = new SelectElement(element);

            var elem = selectElement.SelectedOption.Text;

            return elem;
        }
    }
}
