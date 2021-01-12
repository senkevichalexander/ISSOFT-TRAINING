using FinalTask.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace FinalTask.Pages.ProductPage
{
    public class ProductPage :PageBase
    {
        //добавить исопенд по ссылке
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

        public string GetProductNameText()
        {
            return _productName.Text;
        }

        public string GetSizeDropdownText()
        {
            return Browser.GetSelectedElementsText(_sizeSelect);
        }
        
        public string GetColorText()
        {
            //return _colors.FirstOrDefault(x => x.Selected)?.GetAttribute("title");

            foreach (var item in _colors)
            {
                if (item.Selected)
                {
                    return item.GetAttribute("title");
                }
            }
            return "";
        }



        
        

    }
}
