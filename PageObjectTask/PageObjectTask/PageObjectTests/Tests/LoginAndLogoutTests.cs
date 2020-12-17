using NUnit.Framework;
using PageObjectTests.Helpers;
using PageObjectTests.Pages;

namespace PageObjectTests
{
    [TestFixture]
    public class Tests
    {
        private ReportHelper _reportHelper = new ReportHelper();

        [SetUp]
        public void Setup()
        {
            Browser.Initializes(true);
            var tutByHomepage = PageGenerator.TutByHomepage;
            Browser.GoToPage(tutByHomepage);
            Assert.IsTrue(tutByHomepage.IsOpened);
        }
        
        [Test]
        [TestCase("seleniumtests@tut.by", "123456789zxcvbn")]

        public void LoginToSite(string login, string password)
        {
            var authorizeForm = PageGenerator.AuthorizeForm;
            var loginWindow = PageGenerator.LoginWindow;
            
            authorizeForm.ClickEnterButton();
            loginWindow.SignIn(login, password);

            Assert.IsNotNull(authorizeForm.UserName, "Homepage must be opened ater the login and user name must exists on page");
        }


        [Test]
        [TestCase("seleniumtests@tut.by", "123456789zxcvbn")]

        public void LogoutFromTutBy(string login, string password)
        {
            var loginWindow = PageGenerator.LoginWindow;
            var authorizeForm = PageGenerator.AuthorizeForm;

            authorizeForm.ClickEnterButton();
            loginWindow.SignIn(login, password);

            Assert.IsNotNull(authorizeForm.UserName, "Page must be opened ater login and user name must exists on page");

            authorizeForm.EnterTheAuthorrizationForm();

            Assert.IsNotNull(authorizeForm.ActiveAuthorizeForm, "Authorize fom must be opened");
            
            authorizeForm.ClickExitButton();

            Assert.IsNotNull(authorizeForm.EnterButton, "Page must be opened after exit from the profile");
        }

        [TearDown]
        public void AfterTests()
        {
            _reportHelper.GenerateReport();
            Browser.Quit();
        }
    }
}