using OpenQA.Selenium;
using SeleniumExtras.WaitHelpers;
using Training.Helpers;

namespace Training.Pages
{
    class HomePage : MainPage
    {
        private const string homePage = "https://www.tut.by/";
        private By enterButton = By.Name("icon-auth");
        private By enterFormChangeBlock = By.XPath("//*[@id='b-auth-form b-popup'][contains(@style, 'display: block')]");
        private By loginField = By.CssSelector("input[name=login]");
        private By passwordField = By.CssSelector("input[name=password]");
        public bool IsPageOpened { get; private set; }
        public bool IsVisible { get; private set; }


        public void OpenHomepage()
        {
            Driver.Navigate().GoToUrl(homePage);

            IsPageOpened = true;
            
        }

        public void ClickEnterButton()
        {
            Driver.FindElement(enterButton).Click();
            WaitHelper.WaitUntil(ExpectedConditions.PresenceOfAllElementsLocatedBy(enterFormChangeBlock));
        }


        public void InputLoginAndPassword()
        {
            var loginValue = Config["loginValue"];
            var passwordValue = Config["passwordValue"];

            IWebElement login = Driver.FindElement(loginField);
            login.SendKeys(loginValue);

            IWebElement password = Driver.FindElement(passwordField);
            password.SendKeys(passwordValue);
        }

    }
}
