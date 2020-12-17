using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace PageObjectTests
{

    public static class DriverHelper
    {
        public static IWebDriver FactoryDriver() => new ChromeDriver();
    }
}
