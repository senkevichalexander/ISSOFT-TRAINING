using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using Training.Helpers;

namespace Training.Pages
{
    public class HomePage : MainPage
    {
        private const string _homePage = "https://www.tut.by/";
        private readonly string title = "Белорусский портал TUT.BY. Новости Беларуси и мира";

        //[FindsBy(How = How.ClassName, Using = "enter")]
        //private readonly IWebElement _enterButton;

        //[FindsBy(How = How.CssSelector, Using = "input[name = login]")]
        //private readonly IWebElement _loginField;

        //[FindsBy(How = How.CssSelector, Using = "input[name = password]")]
        //private readonly IWebElement _passwordField;

        //[FindsBy(How = How.CssSelector, Using = "input.auth__enter")]
        //private readonly IWebElement _enterButtonAfterLogin;

        //private const string _homePage = "https://www.tut.by/";
        private readonly By _enterButton = By.ClassName("enter");
        private readonly By _loginField = By.CssSelector("input[name=login]");
        private readonly By _passwordField = By.CssSelector("input[name=password]");
        private readonly By _enterButtonAfterLogin = By.CssSelector("input.auth__enter");


        public By UserName => By.CssSelector(".uname");
        public bool IsOpened
        {
            get { return Driver.Title.Equals(title); }
        }

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
            Driver.FindElement(_enterButtonAfterLogin).Click();
        }
    }
}
