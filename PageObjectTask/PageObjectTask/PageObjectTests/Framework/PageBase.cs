using OpenQA.Selenium;

namespace PageObjectTests
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
    }
}
