﻿using FinalTask.Framework;

namespace FinalTask.Pages.Homepage
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

        public bool IsOpened => Browser.Driver.Title.Equals(title);
    }
}