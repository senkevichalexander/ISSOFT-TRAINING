using OpenQA.Selenium;
using Training.Helpers;

namespace Training.Pages
{
    public class MainPage
    {
        //DriverGenerator driverGenerator = DriverGenerator.GetInstance();
        public IWebDriver Driver { get; } = DriverGenerator.GetInstance().GetDriver();

    }
}
