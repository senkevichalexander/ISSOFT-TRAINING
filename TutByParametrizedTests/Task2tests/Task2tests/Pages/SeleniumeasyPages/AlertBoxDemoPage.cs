using OpenQA.Selenium;
using Training.Pages;

namespace Task2tests
{
    public class AlertBoxDemoPage : MainPage
    {
        private const string _alertBoxDemoPageUrl = "https://www.seleniumeasy.com/test/javascript-alert-box-demo.html";
        private readonly By _firstAlertBoxButton = By.CssSelector("button[onclick='myAlertFunction()']");
        private readonly By _confirmBoxButton = By.CssSelector("button[onclick='myConfirmFunction()']");
        private readonly By _promtBoxButton = By.CssSelector("button[onclick='myPromptFunction()']");
        private readonly By _confirmIDField = By.CssSelector("#confirm-demo");
        private readonly By _promptIDField = By.CssSelector("#prompt-demo");
        private readonly string _name = "Alexander";

        public void OpenHomePage()
        {
            Driver.Navigate().GoToUrl(_alertBoxDemoPageUrl);
        }

        public void ClickAlertBoxButton()
        {
            Driver.FindElement(_firstAlertBoxButton).Click();
        }

        public void ClickConfirmBoxButton()
        {
            Driver.FindElement(_confirmBoxButton).Click();
        }

        public void ClickPromtBoxButton()
        {
            Driver.FindElement(_promtBoxButton).Click();
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
            var informationOfActionsMessage = Driver.FindElement(_confirmIDField).Text;

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
            var informationOfActionsMessage = Driver.FindElement(_promptIDField).Text;

            return informationOfActionsMessage == $"You have entered '{_name}' !";
        }

        public void ChooseOKConditionOfPromptBoxButton()
        {
            var prompt = GetAlertPrompt();
            prompt.SendKeys(_name);
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
