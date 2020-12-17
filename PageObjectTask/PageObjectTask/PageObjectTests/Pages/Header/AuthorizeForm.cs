using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjectTests
{
    public class AuthorizeForm : PageBase
    {
        public AuthorizeForm() : base(Browser.Driver.Url)
        {

        }

        [FindsBy(How = How.CssSelector, Using = ".button.wide.auth__reg")]
        private IWebElement _exitButton;

        [FindsBy(How = How.CssSelector, Using = ".uname")]
        private IWebElement _userName;

        [FindsBy(How = How.CssSelector, Using = ".enter.logedin")]
        private IWebElement _authorize;

        [FindsBy(How = How.ClassName, Using = "enter")]
        private IWebElement _enterButton;

        [FindsBy(How = How.CssSelector, Using = ".enter.logedin.active")]
        private IWebElement _activeAuthorizeForm;

        public void ClickEnterButton()
        {
            _enterButton.Click();
        }

        public void EnterTheAuthorrizationForm()
        {
            _authorize.Click();
        }

        public void ClickExitButton()
        {
            _exitButton.Click();
        }

        public IWebElement UserName
        {
            get
            {
                WaitUntilElementExists(_userName);
                return _userName;
            }
        }

        public IWebElement EnterButton
        {
            get
            {
                WaitUntilElementExists(_enterButton);
                return _enterButton;
            }
        }

        public IWebElement ActiveAuthorizeForm
        {
            get
            {
                WaitUntilElementExists(_activeAuthorizeForm);
                return _activeAuthorizeForm;
            }
        }
    }
}
