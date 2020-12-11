using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using Training.Pages;

namespace Task2tests
{
    public class MultiselectPage : MainPage
    {
        private const string homePage = "https://www.seleniumeasy.com/test/basic-select-dropdown-demo.html";
        private readonly By multiSelect = By.CssSelector("select#multi-select");

        public void OpenHomepage()
        {
            Driver.Navigate().GoToUrl(homePage);
        }

        public int GetSelectedElementsCount()
        {
            var selectElement = new SelectElement(Driver.FindElement(multiSelect));

            var random = new Random();
            var elements = selectElement.Options.OrderBy(x => random.Next()).Take(3).ToList();

            foreach (var el in elements)
            {
                selectElement.SelectByText(el.Text);
            }

            return selectElement.AllSelectedOptions.Count;
        }
    }
}
