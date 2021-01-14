using FinalTask.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FinalTask.Pages.ProductPage
{
    public class ProductPage :PageBase
    {
        public ProductPage() : base(Browser.Driver.Url)
        {

        }

        #region WebElements

        [FindsBy(How = How.CssSelector, Using = "#wishlist_button")]
        private IWebElement _addToWishlistButton;

        [FindsBy(How = How.CssSelector, Using = ".fancybox-close")]
        private IWebElement _overlayCloseAddToWishlist;

        [FindsBy(How = How.CssSelector, Using = ".pb-center-column>h1")]
        private IWebElement _productName;

        [FindsBy(How = How.CssSelector, Using = "#group_1")]
        private IWebElement _sizeSelect;

        [FindsBy(How = How.CssSelector, Using = "#color_to_pick_list>li")]
        private IList<IWebElement> _colors;

        [FindsBy(How = How.CssSelector, Using = "button.exclusive")]
        private IWebElement _addToCardButton;

        [FindsBy(How = How.CssSelector, Using = ".continue")]
        private IWebElement _continueShoppingButton;

        [FindsBy(How = How.CssSelector, Using = "#our_price_display")]
        private IWebElement _price;

        #endregion

        public void ClickAddToWishlistButton()
        {
            _addToWishlistButton.Click();
        }

        public void CloseOverlayAddToWishlist()
        {
            //var closeWishlist = By.CssSelector(".fancybox-close");
            //Browser.WaitForElementIsVisible(closeWishlist, 15);
            Browser.ImplicitlyWait(5);
            _overlayCloseAddToWishlist.Click();
        }

        private string GetProductNameText()
        {
            return _productName.Text;
        }

        private string GetSizeDropdownText()
        {
            return Browser.GetSelectedElementsText(_sizeSelect);
        }
        
        private string GetColorText()
        {
            foreach (var item in _colors.Where(item => item.GetAttribute("class") == "selected"))
            {
                return item.FindElement(By.CssSelector(":first-child")).GetAttribute("title");
            }

            return string.Empty;
        }

        public List<string> GetProductPropertiesToList()
        {
            return new List<string> { GetProductNameText(), GetSizeDropdownText(), GetColorText() };
        }

        public void ClickAddToCardButton()
        {
            _addToCardButton.Click();
        }

        public void ClickContinueShoppingButton()
        {
            Browser.ImplicitlyWait(3);
            _continueShoppingButton.Click();
        }

        public decimal GetProductPrice()
        {
            var price = _price.Text.Trim('$');

            return Convert.ToDecimal(price);
        } 
    }
}
