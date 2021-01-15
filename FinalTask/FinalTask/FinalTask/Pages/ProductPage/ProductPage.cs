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
        private readonly IWebElement _addToWishlistButton;

        [FindsBy(How = How.CssSelector, Using = ".fancybox-close")]
        private readonly IWebElement _overlayCloseAddToWishlist;

        [FindsBy(How = How.CssSelector, Using = ".pb-center-column>h1")]
        private readonly IWebElement _productName;

        [FindsBy(How = How.CssSelector, Using = "#group_1")]
        private readonly IWebElement _sizeSelect;

        [FindsBy(How = How.CssSelector, Using = "#color_to_pick_list>li")]
        private readonly IList<IWebElement> _colors;

        [FindsBy(How = How.CssSelector, Using = "button.exclusive")]
        private readonly IWebElement _addToCardButton;

        [FindsBy(How = How.CssSelector, Using = ".continue")]
        private readonly IWebElement _continueShoppingButton;

        [FindsBy(How = How.CssSelector, Using = "#our_price_display")]
        private readonly IWebElement _price;

        #endregion

        public void ClickAddToWishlistButton()
        {
            _addToWishlistButton.Click();
        }

        public void CloseOverlayAddToWishlist()
        {
            WaitForOverlay();
            ImplicitlyWait();
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
            var element = _colors.FirstOrDefault(item => item.GetAttribute("class") == "selected");

            return element == null 
                ? string.Empty
                : element.FindElement(By.CssSelector(":first-child")).GetAttribute("title");
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
