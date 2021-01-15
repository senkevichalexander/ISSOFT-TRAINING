using FinalTask.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.Pages.MyAccountPage
{
    public class MyAccountPage : PageBase
    {
        public MyAccountPage() : base(Browser.Driver.Url)
        {

        }

        public readonly string url = "http://automationpractice.com/index.php?controller=my-account";
        public readonly string title = "My account - My Store";

        #region WebElements

        [FindsBy(How = How.CssSelector, Using = "a[title= 'My wishlists']")]
        private readonly IWebElement _myWishlists;

        [FindsBy(How = How.CssSelector, Using = "div#mywishlist>div>table")]
        private readonly IList<IWebElement> _wishlistTable;

        [FindsBy(How = How.CssSelector, Using = "a.icon")]
        private readonly IWebElement _iconForDeleteWishlists;

        [FindsBy(How = How.CssSelector, Using = "div#best-sellers_block_right a.product-name")]
        private readonly IList<IWebElement> _productsNameTopSellers;

        #endregion

        public bool IsOpened => Browser.Driver.Url.Equals(url);

        public void ClickMyWishlists()
        {
            _myWishlists.Click();
        }

        public void ClearTheWishlists()
        {
            if (_wishlistTable.Any())
            {
                for (int i = 0; i < _wishlistTable.Count; i++)
                {
                    _iconForDeleteWishlists.Click();
                    ChooseOKConditionOfAlertBoxButton();
                }
            }
        }

        private void ChooseOKConditionOfAlertBoxButton()
        {
            var prompt = GetAlertPrompt();
            prompt.Accept();
            GetMainPageAfterAlertPromptClosed();
        }

        private IAlert GetAlertPrompt() => Browser.Driver.SwitchTo().Alert();

        private IWebDriver GetMainPageAfterAlertPromptClosed() => Browser.Driver.SwitchTo().DefaultContent();
    }
}
