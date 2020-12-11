using NUnit.Framework;
using Training.Helpers;
using Training.Pages;

namespace Task2tests
{
    [TestFixture]
    public class Tests
    {
        private HomePage _homePage;

        [SetUp]
        public void Setup()
        {
            _homePage = new HomePage();
            _homePage.OpenHomepage();
        }

        [Test]

        [TestCase("seleniumtests@tut.by", "123456789zxcvbn")]
        [TestCase("seleniumtests2@tut.by", "123456789zxcvbn")]
        public void LoginToSite(string login, string password)
        {
            _homePage.ClickEnterButton();
            _homePage.InputLoginAndPassword(login, password);
            _homePage.ClickEnterButtonAfterInputEnterValues();

            Assert.IsTrue(_homePage.IsPageOpened, 
                "Homepage must be opened ater the login and user name must exists on page");
        }


        [TearDown]
        public void AfterTests()
        {
            DriverGenerator.Quit();
        }
    }
}