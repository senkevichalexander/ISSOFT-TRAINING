using OpenQA.Selenium;

namespace FinalTask.Framework
{
    public class PageBase 
    {
        public string PageUrl { get; private set; }

        public PageBase(string pageUrl)
        {
            PageUrl = pageUrl;
        }

        protected void WaitUntilElementExists(IWebElement element, int seconds = 10)
        {
            Browser.WaitForElementExists(element, seconds);
        }

        protected void ImplicitlyWait(int seconds = 10)
        {
            Browser.ImplicitlyWait(seconds);
        }

        protected void WaitForElement(IWebElement element, int seconds = 10)
        {
            Browser.ExplicitWait(seconds, element);
        }

        public void WaitForOverlay(int seconds = 10)
        {
            Browser.OverlayWait(seconds);
        }
    }
}
