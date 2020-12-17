using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjectTests.Pages
{
    public class LoginWindow : PageBase
    {

        public LoginWindow() : base(Browser.Driver.Url)
        {
        }

        [FindsBy(How = How.CssSelector, Using = "input[name = login]")]
        private IWebElement _loginField;

        [FindsBy(How = How.CssSelector, Using = "input[name = password]")]
        private IWebElement _passwordField;

        [FindsBy(How = How.CssSelector, Using = "input.auth__enter")]
        private IWebElement _enterButtonAfterLogin;

        public void SignIn(string loginAttribute, string passwordAttribute)
        {
            _loginField.SendKeys(loginAttribute);
            _passwordField.SendKeys(passwordAttribute);
            _enterButtonAfterLogin.Click();
        }
    }
}
