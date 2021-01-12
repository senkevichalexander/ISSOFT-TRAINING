using Allure.Commons;
using Allure.NUnit.Attributes;
using FinalTask.Framework;
using FinalTask.Helpers;
using FinalTask.Pages;
using NUnit.Framework;
using System.Threading;

namespace FinalTask.Tests
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
            var loginpage = PageGenerator.LoginPage;
            loginpage.OpenLoginPage();
            Assert.IsTrue(loginpage.IsOpened, "Login page must be  opened");
        }
        
        [Test(Description = "Register on site with required fields and check  account was created")]
        [AllureSeverity(Allure.Commons.Model.SeverityLevel.Minor)]
        [AllureLink("http://automationpractice.com/")]
        [AllureOwner("Alexander Senkevich")]
        [AllureSubSuite("Register")]

        public void RegisterOnSite()
        {
            var loginPage = PageGenerator.LoginPage;
            var createAnAccountPage = PageGenerator.CreateAnAccountPage;

            loginPage.CreateAnAccount();
            createAnAccountPage.RegisterWithRequiredFields();
            createAnAccountPage.ClickRegisterButton();
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

        [Test(Description = "Add to auto-created wishlist")]
        [AllureSeverity(Allure.Commons.Model.SeverityLevel.Minor)]
        [AllureLink("http://automationpractice.com/")]
        [AllureOwner("Alexander Senkevich")]
        [AllureSubSuite("Add to Wishlist")]

        public void AddToAutoCreatedWishlist()
        {
            var loginPage = PageGenerator.LoginPage;
            var myAccountPage = PageGenerator.MyAccountPage;
            var productPage = PageGenerator.ProductPage;
            var header = PageGenerator.Header;

            loginPage.InputEmailForSignIn();
            loginPage.InputPasswordForSignIn();
            loginPage.ClickSignInButton();

            Assert.IsTrue(myAccountPage.IsOpened, "MyAcccount page must be opened");

            myAccountPage.ClickMyWishlists();
            myAccountPage.ClearTheWishlists();
            myAccountPage.ClickFirstTopSellersProduct();

            productPage.ClickAddToWishlistButton();
            productPage.CloseOverlayAddToWishlist();

            var a = productPage.GetProductNameText();
            var b = productPage.GetSizeDropdownText();
            var c = productPage.GetColorText();

            header.ClickAccount();

            myAccountPage.ClickMyWishlists();

            Thread.Sleep(10000);
        }

        [TearDown]
        public void AfterTests()
        {
            _reportHelper.MakeScreenshorAfterTestIsFailed();
            Browser.Quit();
        }
    }
}