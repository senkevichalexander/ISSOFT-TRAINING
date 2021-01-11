using Allure.Commons;
using Allure.NUnit.Attributes;
using NUnit.Framework;
using PageObjectTests.Helpers;
using PageObjectTests.Pages;
using System.Threading;

namespace PageObjectTests
{
    [TestFixture]
    [AllureSuite("")]
    public class Tests : AllureReport
    {
        private ReportHelper _reportHelper = new ReportHelper();

        [SetUp]
        public void Setup()
        {
            Browser.Initializes(true);
            var homepage = PageGenerator.Homepage;
            Browser.GoToPage(homepage);
            Assert.IsTrue(homepage.IsOpened);
        }
        
        [Test(Description = "Register on site with required fields and check  account was created")]
        [AllureSeverity(Allure.Commons.Model.SeverityLevel.Minor)]
        [AllureLink("http://automationpractice.com/")]
        [AllureOwner("Alexander Senkevich")]
        [AllureSubSuite("Register")]

        public void LoginToSite()
        {
            var loginPage = PageGenerator.LoginPage;
            var createAnAccountPage = PageGenerator.CreateAnAccountPage;
            var header = PageGenerator.Header;

            header.ClickLoginButton();
            loginPage.CreateAnAccount();
            createAnAccountPage.RegisterWithRequiredFields();
            createAnAccountPage.ClickRegisterButton();

            Thread.Sleep(100000);
        }


        [TearDown]
        public void AfterTests()
        {
            _reportHelper.MakeScreenshorAfterTestIsFailed();
            Browser.Quit();
        }
    }
}