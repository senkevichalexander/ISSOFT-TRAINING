using OpenQA.Selenium;
using Training.Helpers;
using Training.Pages;

namespace Task2tests
{
    class DownloadDemoPage : MainPage
    {
        private const string _homePage = "https://www.seleniumeasy.com/test/bootstrap-download-progress-demo.html";
        private readonly By _downloadButton = By.Id("cricle-btn");
        public By DownloadPercentViewer => By.CssSelector(".percenttext");

        public void OpenHomePage()
        {
            Driver.Navigate().GoToUrl(_homePage);
        }

        public void ClickDownloadButton()
        {
            Driver.FindElement(_downloadButton).Click();
            WaitHelper.WaitUntilElementClickable(_downloadButton);
        }

        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }
    }
}
