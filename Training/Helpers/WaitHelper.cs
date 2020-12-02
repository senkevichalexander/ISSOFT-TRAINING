using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.ObjectModel;

namespace Training.Helpers
{
    public static class WaitHelper
    {
        private static readonly IWebDriver driver = DriverGenerator.GetInstance();

        public static void WaitUntil(Func<IWebDriver, ReadOnlyCollection<IWebElement>> condition, int timeout = 1000)
        { 
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeout));
            wait.Until(condition);
        }
    }
}
