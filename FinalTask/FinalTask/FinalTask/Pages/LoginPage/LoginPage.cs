using FinalTask.Framework;
using FinalTask.TestData;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FinalTask.Pages.LoginPage
{
    public class LoginPage : PageBase
    {
        public LoginPage() : base(Browser.Driver.Url)
        {

        }

        private const string _loginPage 
            = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
        private readonly string title = "Login - My Store";
        private readonly User _user = UserRepository.GetLoginUser();


        #region WebElements

        [FindsBy(How = How.CssSelector, Using = "#email_create")]
        private readonly IWebElement _registerInputField;

        [FindsBy(How = How.CssSelector, Using = "button#SubmitCreate")]
        private readonly IWebElement _createAnAccountButton;

        [FindsBy(How = How.CssSelector, Using = "#login_form #email")]
        private readonly IWebElement _emailField;

        [FindsBy(How = How.CssSelector, Using = "#passwd")]
        private readonly IWebElement _passwordField;

        [FindsBy(How = How.CssSelector, Using = "#SubmitLogin")]
        private readonly IWebElement _signInButton;

        [FindsBy(How = How.CssSelector, Using = "#create_account_error")]
        private readonly IWebElement _createAccountErrorMessage;

        #endregion

        public void OpenLoginPage()
        {
            Browser.Driver.Navigate().GoToUrl(_loginPage);
        }

        public bool IsOpened => Browser.Driver.Title.Equals(title);

        public void InputEmailToCreateAccount(string email)
        {
            WaitUntilElementExists(_registerInputField);
            _registerInputField.SendKeys(email);
        }

        public void ClickCreateAnAccountButton()
        {
            _createAnAccountButton.Click();
        }

        public User CreateAnAccount()
        {
            var user = UserRepository.GetNewUserForRegister();

            InputEmailToCreateAccount(user.EmailValue);
            ClickCreateAnAccountButton();

            return user;
        }

        public void InputEmailForSignIn()
        {
            _emailField.SendKeys(_user.EmailValue);
        }

        public void InputPasswordForSignIn()
        {
            _passwordField.SendKeys(_user.Password);
        }

        public void ClickSignInButton()
        {
            _signInButton.Click();
        }
    }
}
