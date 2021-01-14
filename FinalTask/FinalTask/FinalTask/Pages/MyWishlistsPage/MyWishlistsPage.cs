using FinalTask.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.Pages.MyWishlistsPage
{
    public class MyWishlistsPage : PageBase
    {
        public MyWishlistsPage() : base(Browser.Driver.Url)
        {

        }
        private readonly string url = "http://automationpractice.com/index.php?fc=module&module=blockwishlist&controller=mywishlist";
        private readonly string wishlistName = "qwerty";

        #region WebElements

        [FindsBy(How = How.CssSelector, Using = "tr[id^='wishlist_'] td:nth-child(1) a")]
        private IWebElement _wishlistTableName;

        [FindsBy(How = How.CssSelector, Using = "#s_title")]
        private IWebElement _productName;

        [FindsBy(How = How.CssSelector, Using = ".inputTxt")]
        private IWebElement _wishlistNameInput;

        [FindsBy(How = How.CssSelector, Using = "#submitWishlist")]
        private IWebElement _saveButton;

        [FindsBy(How = How.CssSelector, Using = "div#best-sellers_block_right a.product-name")]
        private IList<IWebElement> _productsNameTopSellers;

        #endregion

        public void OpenWishlistDetail()
        {
            _wishlistTableName.Click();
        }

        public List<string> GetProductPropertiesToList()
        {
            var text = _productName.Text.Replace("\r\n", ", ");

            return text.Split(", ").ToList();
        }

        public void InputNameOfWishList()
        {
            _wishlistNameInput.SendKeys(wishlistName);
        }

        public void ClickSaveButton()
        {
            _saveButton.Click();
            Browser.ImplicitlyWait(20);
        }

        public void ClickFirstTopSellersProduct()
        {
            _productsNameTopSellers[0].Click();
        }
    }
}
