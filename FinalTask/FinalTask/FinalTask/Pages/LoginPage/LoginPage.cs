

using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Configuration;

namespace PageObjectTests.Pages
{
    public class LoginPage : PageBase
    {
        public LoginPage() : base(Browser.Driver.Url)
        {

        }

        private const string _loginPage = "http://automationpractice.com/index.php?controller=authentication&back=my-account";
        private readonly string title = "Login - My Store";
        //private readonly string emailValue = ConfigurationManager.AppSettings["RegistrationEmail"];
        private readonly string emailValue = "sdad4616@gmail.com";

        [FindsBy(How = How.CssSelector, Using = "#email_create")]
        private IWebElement _registerInputField;

        [FindsBy(How = How.CssSelector, Using = "button#SubmitCreate")]
        private IWebElement _createAnAccountButton;

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
    }
}
