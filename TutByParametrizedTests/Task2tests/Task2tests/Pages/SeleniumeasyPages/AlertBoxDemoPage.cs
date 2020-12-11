using OpenQA.Selenium;
using Training.Pages;

namespace Task2tests
{
    public class AlertBoxDemoPage : MainPage
    {
        private const string alertBoxDemoPageUrl = "https://www.seleniumeasy.com/test/javascript-alert-box-demo.html";
        private readonly By firstAlertBoxButton = By.CssSelector("button[onclick='myAlertFunction()']");
        private readonly By confirmBoxButton = By.CssSelector("button[onclick='myConfirmFunction()']");
        private readonly By promtBoxButton = By.CssSelector("button[onclick='myPromptFunction()']");
        private readonly By confirmIDField = By.CssSelector("#confirm-demo");
        private readonly By promptIDField = By.CssSelector("#prompt-demo");
        private readonly string name = "Alexander";

        public void OpenHomePage()
        {
            Driver.Navigate().GoToUrl(alertBoxDemoPageUrl);
        }

        public void ClickAlertBoxButton()
        {
            Driver.FindElement(firstAlertBoxButton).Click();
        }

        public void ClickConfirmBoxButton()
        {
            Driver.FindElement(confirmBoxButton).Click();
        }

        public void ClickPromtBoxButton()
        {
            Driver.FindElement(promtBoxButton).Click();
        }

        public bool IsAlertPresent()
        {
            try
            {
                GetAlertPrompt();

                return true;
            }
            catch
            {
                return false;
            }
        }

        private IAlert GetAlertPrompt()
        {
            return Driver.SwitchTo().Alert();
        }

        private IWebDriver GetMainPageAfterAlertPromptClosed()
        {
            return Driver.SwitchTo().DefaultContent();
        }

        public void ConfirmConditionOfAlertPrompt()
        {
            var prompt = GetAlertPrompt();
            prompt.Accept();
            GetMainPageAfterAlertPromptClosed();
        }

        public bool IsConfirmBoxChanged()
        {
            var informationOfActionsMessage = Driver.FindElement(confirmIDField).Text;

            return informationOfActionsMessage == "You pressed OK!";
        }

        public void ChooseOKConditionOfConfirmBoxButton()
        {
            var prompt = GetAlertPrompt();
            prompt.Accept();
            GetMainPageAfterAlertPromptClosed();
        }

        public void ChooseCancelConditionOfConfirmBoxButton()
        {
            var prompt = GetAlertPrompt();
            prompt.Dismiss();
            GetMainPageAfterAlertPromptClosed();
        }

        public bool IsPromptBoxChanged()
        {
            var informationOfActionsMessage = Driver.FindElement(promptIDField).Text;

            return informationOfActionsMessage == $"You have entered '{name}' !";
        }

        public void ChooseOKConditionOfPromptBoxButton()
        {
            var prompt = GetAlertPrompt();
            prompt.SendKeys(name);
            prompt.Accept();
            GetMainPageAfterAlertPromptClosed();
        }

        public void ChooseCancelConditionOfPromptBoxButton()
        {
            var prompt = GetAlertPrompt();
            prompt.Dismiss();
            GetMainPageAfterAlertPromptClosed();
        }

        public void RefreshPage()
        {
            Driver.Navigate().Refresh();
        }

    }
}
