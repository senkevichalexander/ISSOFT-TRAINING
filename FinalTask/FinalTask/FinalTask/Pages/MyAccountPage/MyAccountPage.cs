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
        private IWebElement _myWishlists;

        [FindsBy(How = How.CssSelector, Using = "div#mywishlist>div>table")]
        private IList<IWebElement> _wishlistTable;

        [FindsBy(How = How.CssSelector, Using = "a.icon")]
        private IWebElement _iconForDeleteWishlists;

        [FindsBy(How = How.CssSelector, Using = "div#best-sellers_block_right a.product-name")]
        private IList<IWebElement> _productsNameTopSellers;

        #endregion

        public bool IsOpened => Browser.Driver.Url.Equals(url);

        public void ClickMyWishlists()
        {
            _myWishlists.Click();
        }

        public bool IsWishlistsHasTables()
        {
            return _wishlistTable.Any();
        }

        public void ClearTheWishlists()
        {
            if (IsWishlistsHasTables() == true)
            {
                foreach (var item in _wishlistTable)
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

        private IAlert GetAlertPrompt()
        {
            return Browser.Driver.SwitchTo().Alert();
        }

        private IWebDriver GetMainPageAfterAlertPromptClosed()
        {
            return Browser.Driver.SwitchTo().DefaultContent();
        }

        public void ClickFirstTopSellersProduct()
        {
            _productsNameTopSellers[0].Click();
        }
        

    }
}
