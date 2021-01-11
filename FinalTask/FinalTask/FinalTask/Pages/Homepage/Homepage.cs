namespace PageObjectTests.Pages
{
    public class Homepage : PageBase
    {
        private const string _homePage = "http://automationpractice.com/index.php";
        private readonly string title = "My Store";

        public Homepage() : base(_homePage)
        {

        }
        public void OpenHomepage()
        {
            Browser.Driver.Navigate().GoToUrl(_homePage);
        }

        public bool IsOpened
        {
            get { return Browser.Driver.Title.Equals(title); }
        }
    }
}
