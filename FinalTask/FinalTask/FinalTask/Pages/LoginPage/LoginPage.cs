using FinalTask.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FinalTask.Pages.LoginPage
{
    public class LoginPage : PageBase
    {
        public LoginPage() : base(Browser.Driver.Url)
        {

        }

        private const string _loginPage = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
        private readonly string title = "Login - My Store";
        private readonly string emailValue = "sdad4616@gmail.com";
        private readonly string password = "Qwerty1";


        #region WebElements

        [FindsBy(How = How.CssSelector, Using = "#email_create")]
        private IWebElement _registerInputField;

        [FindsBy(How = How.CssSelector, Using = "button#SubmitCreate")]
        private IWebElement _createAnAccountButton;

        [FindsBy(How = How.CssSelector, Using = "#login_form #email")]
        private IWebElement _emailField;

        [FindsBy(How = How.CssSelector, Using = "#passwd")]
        private IWebElement _passwordField;

        [FindsBy(How = How.CssSelector, Using = "#SubmitLogin")]
        private IWebElement _signInButton;

        #endregion

        public void OpenLoginPage()
        {
            Browser.Driver.Navigate().GoToUrl(_loginPage);
        }

        public bool IsOpened
        {
            get { return Browser.Driver.Title.Equals(title); }
        }

        public void InputEmailToCreateAccount()
        {
            WaitUntilElementExists(_registerInputField);
            _registerInputField.SendKeys(emailValue);
        }
        public void ClickCreateAnAccountButton()
        {
            _createAnAccountButton.Click();
        }

        public void CreateAnAccount()
        {
            InputEmailToCreateAccount();
            ClickCreateAnAccountButton();
        }

        public void InputEmailForSignIn()
        {
            _emailField.SendKeys(emailValue);
        }

        public void InputPasswordForSignIn()
        {
            _passwordField.SendKeys(password);
        }

        public void ClickSignInButton()
        {
            _signInButton.Click();
        }
    }
}
