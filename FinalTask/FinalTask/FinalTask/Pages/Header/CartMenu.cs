using FinalTask.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;


namespace FinalTask.Pages.Header
{
    public class CartMenu : PageBase
    {
        public CartMenu() : base(Browser.Driver.Url)
        {
        }

        #region WebElements

        [FindsBy(How = How.CssSelector, Using = "a[title = 'View my shopping cart']")]
        private readonly IWebElement _shoppingCartName;

        #endregion

        public void ClickShoppingCartMennu()
        {
            _shoppingCartName.Click();
        }
    }
}
