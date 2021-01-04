namespace PageObjectTests.Pages
{
    public class TutByHomepage : PageBase
    {
        private const string _homePage = "https://www.tut.by/";
        private readonly string title = "Белорусский портал TUT.BY. Новости Беларуси и мира";

        public TutByHomepage() : base(_homePage)
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
