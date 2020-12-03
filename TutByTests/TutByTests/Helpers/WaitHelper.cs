using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.ObjectModel;

namespace Training.Helpers
{
    public static class WaitHelper
    {
        private static readonly IWebDriver driver = DriverGenerator.GetInstance();

        public static void SetExplicitWait(By by, int timeout = 2)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementExists(by));
        }

        public static void SetPresenceOfAllElementsLocatedWait(By by, int timeout = 2)
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        }
    }
}
