using Allure.Commons;
using Allure.NUnit.Attributes;
using FinalTask.Framework;
using FinalTask.Helpers;
using FinalTask.Pages;
using FinalTask.TestData;
using NUnit.Framework;

namespace FinalTask.Tests
{

    [TestFixture]
    [AllureSuite("")]
    public class LoginTests : AllureReport
    {
        private ReportHelper _reportHelper = new ReportHelper();

        [SetUp]
        public void Setup()
        {
            Browser.Initializes(true);
            var loginpage = PageGenerator.LoginPage;
            loginpage.OpenLoginPage();
            Assert.IsTrue(loginpage.IsOpened, "Login page must be  opened");
        }

        [Test(Description = "Login to site")]
        [AllureSeverity(Allure.Commons.Model.SeverityLevel.Minor)]
        [AllureLink("http://automationpractice.com/")]
        [AllureOwner("Alexander Senkevich")]
        [AllureSubSuite("Login")]

        public void LogInTest()
        {
            var loginPage = PageGenerator.LoginPage;
            var myAccountPage = PageGenerator.MyAccountPage;

            loginPage.InputEmailForSignIn();
            loginPage.InputPasswordForSignIn();
            loginPage.ClickSignInButton();

            Assert.IsTrue(myAccountPage.IsOpened, "MyAcccount page must be opened");
        }

        [TearDown]
        public void AfterTests()
        {
            _reportHelper.MakeScreenshorAfterTestIsFailed();
            Browser.Quit();
        }
    }
}

