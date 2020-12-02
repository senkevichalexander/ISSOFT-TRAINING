using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Training.Helpers
{
    public static class DriverGenerator
    {
        private static IWebDriver driver;
        private static bool isOpen;
        public static IWebDriver GetInstance()
        {
            if (driver == null || !isOpen)
            {
                var options = new ChromeOptions();

                options.AddUserProfilePreference("download.prompt_for_download", false);
                options.AddUserProfilePreference("download.directory_upgrade", true);
                driver = new ChromeDriver(options);
                driver.Manage().Window.Maximize();// open
                isOpen = true;
            }

            return driver;
        }

        public static void Quit()
        {
            driver.Quit();
            isOpen = false;
        }
    }
}
