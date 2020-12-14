using OpenQA.Selenium;
using Training.Helpers;
using TutByTests.Helpers;

namespace Training.Pages
{
    public class HomePage : MainPage
    {
        private const string homePage = "https://www.tut.by/";
        private By enterButton = By.ClassName("enter");
        private By enterFormChangeBlock = By.XPath("//*[@class='b-auth-form b-popup'][contains(@style, 'display: block')]"); 
        private By loginField = By.CssSelector("input[name=login]");
        private By passwordField = By.CssSelector("input[name=password]");
        private By enterButtonAfterLogin = By.XPath("//*[@id='authorize']/div/div/div/div[2]/form/div[2]/input");
        private By headerLogoTutBy = By.ClassName("header-logo");
        public bool IsPageOpened { get; private set; }
        public bool IsVisible { get; private set; }

        public void OpenHomepage()
        {
            IsPageOpened = false;
            Driver.Navigate().GoToUrl(homePage);
            WaitHelper.WaitElementExists(headerLogoTutBy);
            IsPageOpened = true;
        }

        public void ClickEnterButton()
        {
            Driver.FindElement(enterButton).Click();
            WaitHelper.WaitForPresenceOfAllElementsLocated(enterFormChangeBlock);
        }


        public void InputLoginAndPassword()
        {
            var jsonText = JsonHelper.GetDictiinaryFromJSON();

            var loginValue = jsonText["loginValue"];
            var passwordValue = jsonText["passwordValue"];

            IWebElement login = Driver.FindElement(loginField);
            login.SendKeys(loginValue);

            IWebElement password = Driver.FindElement(passwordField);
            password.SendKeys(passwordValue);
        }

        public void ClickEnterButtonAfterInputEnterValues()
        {
            var enterButton = Driver.FindElement(enterButtonAfterLogin);
            
            enterButton.Click();
        }
    }

}
