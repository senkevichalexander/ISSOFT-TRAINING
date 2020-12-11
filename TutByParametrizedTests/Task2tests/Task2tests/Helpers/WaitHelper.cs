using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Training.Helpers
{
    public static class WaitHelper
    {
        private static readonly IWebDriver Driver = DriverGenerator.GetInstance();

        public static void WaitElementExist(By by)
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 20));

            var element = wait.Until(condition =>
            {
                try
                {
                    var elementExists = Driver.FindElement(by);
                    return elementExists.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public static void WaitUntilElementClickable(By by)
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 10));

            var element = wait.Until(condition =>
            {
                try
                {
                    var clickableElement = Driver.FindElement(by);
                    return clickableElement.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public static void WaitUntilPercentCondition(By by, int percent)
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));

            var isReady = wait.Until(condition =>
            {
                try
                {
                    var numberFromPercentElement = Driver.FindElement(by).Text.Trim('%');
                    var percentOfDownload = Convert.ToInt32(numberFromPercentElement);
                    return percentOfDownload >= percent;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }

        public static void WaitUntilAllElementsAreVisible(By by)
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 10));

            var isReady = wait.Until(condition =>
            {
                try
                {
                    var clickableElement = Driver.FindElement(by);

                    return clickableElement.Displayed;
                }
                catch (StaleElementReferenceException)
                {
                    return false;
                }
                catch (NoSuchElementException)
                {
                    return false;
                }
            });
        }
    }
}
