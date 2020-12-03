using Microsoft.Extensions.Configuration;
using OpenQA.Selenium;
using Training.Helpers;

namespace Training.Pages
{
    public class MainPage
    {
        public IWebDriver Driver { get; } = DriverGenerator.GetInstance();
        public IConfiguration Config { get; } = ConfigHelper.GetConfiguration();
    }
}
