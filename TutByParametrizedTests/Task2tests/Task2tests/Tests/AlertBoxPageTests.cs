using NUnit.Framework;
using Task2tests.Pages.SeleniumeasyPages;
using Training.Helpers;

namespace Task2tests
{
    class AlertBoxPageTests
    {

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ConfirmAlertPromptCondition()
        {
            var alertBoxDemoPage = new AlertBoxDemoPage();
            alertBoxDemoPage.OpenHomePage();
            alertBoxDemoPage.ClickAlertBoxButton();
            alertBoxDemoPage.ConfirmConditionOfAlertPrompt();

            Assert.IsFalse(alertBoxDemoPage.IsAlertPresent(), "Alert box conditions must be confirmed");
        }

        [Test]

        public void ChooseCondititionFromSecondsButtonPromt()
        {
            var alertBoxDemoPage = new AlertBoxDemoPage();
            alertBoxDemoPage.OpenHomePage();
            alertBoxDemoPage.ClickConfirmBoxButton();
            alertBoxDemoPage.ChooseOKConditionOfConfirmBoxButton();

            Assert.IsTrue(alertBoxDemoPage.IsConfirmBoxChanged(), "Alert condition must be confirmed");

            alertBoxDemoPage.ClickConfirmBoxButton();
            alertBoxDemoPage.ChooseCancelConditionOfConfirmBoxButton();

            Assert.IsFalse(alertBoxDemoPage.IsConfirmBoxChanged(), "Alert condition must be dismissed");
        }


        [Test]

        public void ChooseConditionFromThirdsButtnPromt()
        {
            var alertBoxDemoPage = new AlertBoxDemoPage();
            alertBoxDemoPage.OpenHomePage();
            alertBoxDemoPage.ClickPromtBoxButton();
            alertBoxDemoPage.ChooseOKConditionOfPromptBoxButton();

            Assert.IsTrue(alertBoxDemoPage.IsPromptBoxChanged(), "Alert condition must be confirmed");

            alertBoxDemoPage.RefreshPage();

            alertBoxDemoPage.ClickPromtBoxButton();
            alertBoxDemoPage.ChooseCancelConditionOfPromptBoxButton();

            Assert.IsFalse(alertBoxDemoPage.IsPromptBoxChanged(), "Alert condition must be dismissed");
        }

        [Test]
        public void SelectThreeOptions()
        {
            var homepage = new MultiselectPage();
            homepage.OpenHomepage();

            var count = homepage.GetSelectedElementsCount();

            Assert.AreEqual(count, 3,"Three options must be selected");
        }

        [Test]
        public void GetNewUser()
        {
            var userWaitsPage = new UserWaitsPage();
            userWaitsPage.OpenHomePage();
            userWaitsPage.ClickGetNewUserButton();

            Assert.IsTrue(WaitHelper.WaitUntilAllElementsAreVisible(userWaitsPage.UserContainer), "New user info must be dispayed");
        }


        [Test]
        [TestCase(50)]
        public void RefreshPageAutomatedScript(int numberOfPercent)
        {
            var downloadPage = new DownloadDemoPage();
            downloadPage.OpenHomePage();
            downloadPage.ClickDownloadButton();

            Assert.IsTrue(WaitHelper.WaitUntilPercentCondition(downloadPage.DownloadPercentViewer, numberOfPercent),
                "Download must be stooped, and after than page must be refreshed");

            downloadPage.RefreshPage();
        }

        [Test]
        [TestCase("10", 30, 500000)]
        public void TableSortTestAutomatedScript(string countOfRows, int age, decimal salary)
        {
            var tablepage = new TableSortSearchDemoPage();
            tablepage.OpenTableSortSearchDemoPage();
            tablepage.ChooseQuantityOfEntries(countOfRows);

            var workers = tablepage.GetWorkersBySalaryAndAge(age, salary);
            Assert.IsNotNull(workers, "Count of custom workers must be added in list");
        }


        [TearDown]
        public void AfterTests()
        {
            DriverGenerator.Quit();
        }
    }
}
