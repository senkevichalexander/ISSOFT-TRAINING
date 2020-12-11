using OpenQA.Selenium;
using Training.Helpers;
using Training.Pages;

namespace Task2tests
{
    public class UserWaitsPage : MainPage
    {
        private const string homePage = "https://www.seleniumeasy.com/test/dynamic-data-loading-demo.html";
        private readonly By getNewUserButton = By.Id("save");
        private readonly By userContainer = By.XPath("//div[@id='loading']/*");

        public void OpenHomePage()
        {
            Driver.Navigate().GoToUrl(homePage);
        }

        public void ClickGetNewUserButton()
        {
            Driver.FindElement(getNewUserButton).Click();
        }

        public bool WaitForUser()
        {
            var elementInContainer = Driver.FindElement(userContainer);

            WaitHelper.WaitUntilAllElementsAreVisible(userContainer);

            return elementInContainer.Displayed;  
        }
    }
}
