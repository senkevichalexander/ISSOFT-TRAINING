using OpenQA.Selenium;
using Training.Helpers;

namespace Training.Pages
{
    public class HomePage : MainPage
    {
        private const string _homePage = "https://www.tut.by/";
        private readonly By _enterButton = By.ClassName("enter");
        private readonly By _loginField = By.CssSelector("input[name=login]");
        private readonly By _passwordField = By.CssSelector("input[name=password]");
        private readonly By _enterButtonAfterLogin = By.CssSelector("input.auth__enter");

        public By UserName => By.CssSelector(".uname");

        public void OpenHomepage()
        {
            Driver.Navigate().GoToUrl(_homePage);
        }

        public void ClickEnterButton()
        {
            Driver.FindElement(_enterButton).Click();
        }


        public void InputLoginAndPassword(string loginAttribute, string passwordAttribute)
        {

            var loginValue = loginAttribute;
            var passwordValue = passwordAttribute;

            var login = Driver.FindElement(_loginField);
            login.SendKeys(loginValue);

            var password = Driver.FindElement(_passwordField);
            password.SendKeys(passwordValue);
        }

        public void ClickEnterButtonAfterInputEnterValues()
        {
            var enterButton = Driver.FindElement(_enterButtonAfterLogin);

            enterButton.Click();
        }
    }
}
