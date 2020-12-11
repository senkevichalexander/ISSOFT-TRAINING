using OpenQA.Selenium;
using Training.Helpers;

namespace Training.Pages
{
    public class HomePage : MainPage
    {
        private const string homePage = "https://www.tut.by/";
        private readonly By enterButton = By.ClassName("enter");
        private readonly By loginField = By.CssSelector("input[name=login]");
        private readonly By passwordField = By.CssSelector("input[name=password]");
        private readonly By enterButtonAfterLogin = By.XPath("//*[@id='authorize']/div/div/div/div[2]/form/div[2]/input");
        private readonly By userName = By.CssSelector(".uname");

        public bool IsPageOpened { get; private set; }

        public void OpenHomepage()
        {
            Driver.Navigate().GoToUrl(homePage);
        }

        public void ClickEnterButton()
        {
            Driver.FindElement(enterButton).Click();
        }


        public void InputLoginAndPassword(string loginAttribute, string passwordAttribute)
        {

            var loginValue = loginAttribute;
            var passwordValue = passwordAttribute;

            var login = Driver.FindElement(loginField);
            login.SendKeys(loginValue);

            var password = Driver.FindElement(passwordField);
            password.SendKeys(passwordValue);
        }

        public void ClickEnterButtonAfterInputEnterValues()
        {
            var enterButton = Driver.FindElement(enterButtonAfterLogin);

            enterButton.Click();

            WaitHelper.WaitElementExist(userName);

            IsPageOpened = true;
        }
    }
}
