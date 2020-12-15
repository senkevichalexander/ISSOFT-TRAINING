using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace Training.Helpers
{
    public static class WaitHelper 
    {
        private static IWebDriver Driver { get;} = DriverGenerator.GetInstance().GetDriver();

        public static bool WaitElementExist(By by)
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 20));

            return wait.Until(condition =>
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

        public static bool WaitUntilElementClickable(By by)
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 10));

            return wait.Until(condition =>
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

        public static bool WaitUntilPercentCondition(By by, int percent)
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 30));

            return wait.Until(condition =>
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

        public static bool WaitUntilAllElementsAreVisible(By by)
        {
            var wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 10));

            return wait.Until(condition =>
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
