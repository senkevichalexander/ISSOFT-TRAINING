using OpenQA.Selenium;
using Training.Helpers;
using Training.Pages;

namespace Task2tests
{
    public class UserWaitsPage : MainPage
    {
        private const string _homePage = "https://www.seleniumeasy.com/test/dynamic-data-loading-demo.html";
        private readonly By _getNewUserButton = By.Id("save");
        public By UserContainer => By.XPath("//div[@id='loading']/*");

        public void OpenHomePage()
        {
            Driver.Navigate().GoToUrl(_homePage);
        }

        public void ClickGetNewUserButton()
        {
            Driver.FindElement(_getNewUserButton).Click();
        }
    }
}
