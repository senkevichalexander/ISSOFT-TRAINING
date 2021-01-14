

using FinalTask.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace FinalTask.Pages.ShoppingCartPage
{
    public class ShoppingCartPage : PageBase
    {
        public ShoppingCartPage() : base(Browser.Driver.Url)
        {

        }

        #region WebElements

        [FindsBy(How = How.CssSelector, Using = ".cart_item")]
        private IList<IWebElement> _cartItems;

        [FindsBy(How = How.CssSelector, Using = "#total_product")]
        private IWebElement _totalProductPrice;

        private By _actualPrice = By.CssSelector(".cart_unit span span.price");

        #endregion

        public decimal GetSumFromProductsPrice()
        {
            decimal productsPriceSum = 0;

            foreach (var item in _cartItems)
            {
                var productsPriceText = item.FindElement(_actualPrice).Text.Trim('$');
                productsPriceSum += Convert.ToDecimal(productsPriceText);
            }

            return productsPriceSum;
        }

        private decimal GetTotalProductPrice()
        {
            var price = _totalProductPrice.Text.Trim('$');
            return Convert.ToDecimal(price);
        }

        public bool IsPriceOfTheProductEqual()
        {
            return GetSumFromProductsPrice() == GetTotalProductPrice();
        }
    }
}
