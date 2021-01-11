using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace PageObjectTests.Pages
{
    public class Header : PageBase
    {
        public Header() : base(Browser.Driver.Url)
        {
        }

        [FindsBy(How = How.CssSelector, Using = ".login")]
        private IWebElement _loginButton;

        public void ClickLoginButton()
        {
            _loginButton.Click();
        }
    }
}
