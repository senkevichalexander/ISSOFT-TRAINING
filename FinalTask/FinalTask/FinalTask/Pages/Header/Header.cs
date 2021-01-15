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
        private readonly IWebElement _loginButton;

        [FindsBy(How = How.CssSelector, Using = ".account")]
        private readonly IWebElement _account;

        #endregion

        public void ClickAccount()
        {
            WaitForElement(_account);
            _account.Click();
        }
    }
}
