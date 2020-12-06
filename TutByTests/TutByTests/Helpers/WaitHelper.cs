using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.ObjectModel;

namespace Training.Helpers
{
    public static class WaitHelper
    {
        private static readonly IWebDriver Driver = DriverGenerator.GetInstance();


        public static void WaitElementExists(By by, int timeout = 2)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.ElementExists(by));
        }

        public static void WaitForPresenceOfAllElementsLocated(By by, int timeout = 2)
        {
            WebDriverWait wait = new WebDriverWait(Driver, TimeSpan.FromSeconds(timeout));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(by));
        }
    }
}
