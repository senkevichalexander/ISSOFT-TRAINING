using FinalTask.Framework;
using OpenQA.Selenium;
using SeleniumExtras.PageObjects;
using System;
using System.Collections.Generic;

namespace FinalTask.Pages.Header
{
    public class TopSellersBlock : PageBase
    {
        public TopSellersBlock() : base(Browser.Driver.Url)
        {

        }

        #region WebElements
        [FindsBy(How = How.CssSelector, Using = "div#best-sellers_block_right a.product-name")]
        private IList<IWebElement> _productsNameTopSellers;

        #endregion

        public void ClickFirstTopSellersProduct()
        {
            _productsNameTopSellers[0].Click();
        }

        public void ClickSecondTopSellersProduct()
        {
            _productsNameTopSellers[1].Click();
        }

        public void ClickThirdTopSellersProduct()
        {
            _productsNameTopSellers[2].Click();
        }
    }
}
