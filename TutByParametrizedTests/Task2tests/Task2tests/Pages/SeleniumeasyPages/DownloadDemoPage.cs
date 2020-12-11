using OpenQA.Selenium;
using Training.Helpers;
using Training.Pages;

namespace Task2tests
{
    class DownloadDemoPage : MainPage
    {
        private const string homePage = "https://www.seleniumeasy.com/test/bootstrap-download-progress-demo.html";
        private readonly By downloadButton = By.Id("cricle-btn");
        private readonly By downloadPercentViewer = By.CssSelector(".percenttext");

        public void OpenHomePage()
        {
            Driver.Navigate().GoToUrl(homePage);
        }

        public void ClickDownloadButton()
        {
            Driver.FindElement(downloadButton).Click();
            WaitHelper.WaitUntilElementClickable(downloadButton);
        }

        public void RefreshPageAfter(int percentToReload)
        {
            WaitHelper.WaitUntilPercentCondition(downloadPercentViewer, percentToReload);
            Driver.Navigate().Refresh();
        }
    }
}
