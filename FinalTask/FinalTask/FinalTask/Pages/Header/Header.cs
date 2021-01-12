using FinalTask.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace FinalTask.Pages.Header
{
    public class Header : PageBase
    {
        public Header() : base(Browser.Driver.Url)
        {
        }
        #region WebElements

        [FindsBy(How = How.CssSelector, Using = ".login")]
        private IWebElement _loginButton;

        [FindsBy(How = How.CssSelector, Using = ".account")]
        private IWebElement _account;

        #endregion

        public void ClickLoginButton()
        {
            _loginButton.Click();
        }

        public void ClickAccount()
        {
            _account.Click();
        }




    }
}
