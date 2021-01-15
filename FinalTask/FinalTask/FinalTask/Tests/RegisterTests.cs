using Allure.Commons;
using Allure.NUnit.Attributes;
using FinalTask.Framework;
using FinalTask.Helpers;
using FinalTask.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace FinalTask.Tests
{
    [TestFixture]
    [AllureSuite("")]
    public class RegisterTests : AllureReport
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
            var myAccountPage = PageGenerator.MyAccountPage;

            var user = loginPage.CreateAnAccount();
            createAnAccountPage.RegisterWithRequiredFields(user);
            createAnAccountPage.ClickRegisterButton();

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
