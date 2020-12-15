using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Training.Helpers
{
    public /*static*/ class DriverGenerator
    {
        //private static IWebDriver driver;
        //public static IWebDriver GetInstance()
        //{
        //    if (driver == null)
        //    {
        //        var options = new ChromeOptions();

        //        options.AddUserProfilePreference("download.prompt_for_download", false);
        //        options.AddUserProfilePreference("download.directory_upgrade", true);
        //        options.AddLocalStatePreference("browser", new { enabled_labs_experiments = new string[] { "calculate-native-win-occlusion@2" } });
        //        options.AddArgument("no-sandbox");
        //        driver = new ChromeDriver(options);
        //        driver.Manage().Window.Maximize();
        //        driver.Manage().Timeouts().PageLoad.Add(System.TimeSpan.FromSeconds(30));
        //    }

        //    return driver;
        //}

        //public static void Quit()
        //{
        //    driver.Quit();
        //    driver = null;
        //}

        private static DriverGenerator instance = null;
        private IWebDriver driver;

        public DriverGenerator()
        {
            driver = new ChromeDriver();

            var options = new ChromeOptions();
            options.AddUserProfilePreference("download.prompt_for_download", false);
            options.AddUserProfilePreference("download.directory_upgrade", true);
            options.AddLocalStatePreference("browser", new { enabled_labs_experiments = new string[] { "calculate-native-win-occlusion@2" } });
            options.AddArgument("no-sandbox");
            options.AddArguments("--headless --disable-gpu");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(30));
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);
        }



        //public IWebDriver openBrowser()
        //{
        //    var options = new ChromeOptions();

        //    driver = new ChromeDriver();

        //    options.AddUserProfilePreference("download.prompt_for_download", false);
        //    options.AddUserProfilePreference("download.directory_upgrade", true);
        //    options.AddLocalStatePreference("browser", new { enabled_labs_experiments = new string[] { "calculate-native-win-occlusion@2" } });
        //    options.AddArgument("no-sandbox");
        //    driver.Manage().Window.Maximize();
        //    driver.Manage().Timeouts().PageLoad.Add(TimeSpan.FromSeconds(30));
        //    driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(20);

        //    return driver;
        //}

        public static DriverGenerator GetInstance()
        {
            if (instance == null)
            {
                instance = new DriverGenerator();
            }
            return instance;
        }

        public IWebDriver GetDriver()
        {
            return driver;
        }

        public void Quit()
        {
            instance = null;
            driver.Quit();
        }
    }
}
