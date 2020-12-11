using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Training.Helpers
{
    public static class DriverGenerator
    {
        private static IWebDriver driver;
        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                var options = new ChromeOptions();

                options.AddUserProfilePreference("download.prompt_for_download", false);
                options.AddUserProfilePreference("download.directory_upgrade", true);
                //options.AddLocalStatePreference("browser", new { enabled_labs_experiments = new string[] { "calculate-native-win-occlusion@2" } });
                //options.AddArgument("no-sandbox");
                driver = new ChromeDriver(options); 
                driver.Manage().Window.Maximize();
                driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
            }

            return driver;
        }

        public static void Quit()
        {
            driver.Close();
            driver.Quit();
            driver.Dispose();
            driver = null;
        }
    }
}
