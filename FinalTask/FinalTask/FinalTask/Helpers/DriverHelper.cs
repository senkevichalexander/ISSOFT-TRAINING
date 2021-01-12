using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace FinalTask.Helpers
{

    public static class DriverHelper
    {
        public static IWebDriver FactoryDriver() => new ChromeDriver();
    }
}
