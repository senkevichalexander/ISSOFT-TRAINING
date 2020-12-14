using NUnit.Framework;
using Training.Helpers;
using Training.Pages;

namespace TutByTests
{
    public class Tests
    {
        private HomePage _homePage;

        [SetUp]
        public void Setup()
        {
            _homePage = new HomePage();
            _homePage.OpenHomepage();
            Assert.IsTrue(_homePage.IsPageOpened, "Homepage must be opened");
        }

        [Test]
        public void LoginToSite()
        {
            _homePage.ClickEnterButton();
            _homePage.InputLoginAndPassword();
            _homePage.ClickEnterButtonAfterInputEnterValues();
            Assert.IsTrue(_homePage.IsPageOpened, "Homepage must be opened ater the login");
        }

        [TearDown]

        public void AfterTests()
        {
            DriverGenerator.Quit();
        }
    }
}