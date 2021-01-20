using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using Training.Pages;

namespace Task2tests.Pages.SeleniumeasyPages
{
    public class TableSortSearchDemoPage : MainPage
    {
        private const string _tableSortSearchPage = "https://www.seleniumeasy.com/test/table-sort-search-demo.html";
        private readonly By _numberSelect = By.CssSelector("select[name='example_length']");
        private readonly By _informationAboutWorker = By.CssSelector("tbody>tr");
        private readonly By _workerName = By.CssSelector("tr>td:nth-child(1)");
        private readonly By _workerPosition= By.CssSelector("tr>td:nth-child(2)");
        private readonly By _workerOffice = By.CssSelector("tr>td:nth-child(3)");
        private readonly By _workerAge = By.CssSelector("tr>td:nth-child(4)");
        private readonly By _workerSalary = By.CssSelector("tr>td:nth-child(6)");
        private readonly By _nextPageButton = By.CssSelector("#example_next");
        private readonly By _numberOfPages = By.CssSelector("span>a");

        public void OpenTableSortSearchDemoPage()
        {
            Driver.Navigate().GoToUrl(_tableSortSearchPage);
        }

        public void ChooseQuantityOfEntries(string countOfRows)
        {
            var selectElement = new SelectElement(Driver.FindElement(_numberSelect));
            selectElement.SelectByValue(countOfRows);
        }

        private List<IWebElement> GetRowsInfo()
        {
            var rowInfo = Driver.FindElements(_informationAboutWorker).ToList();

            return rowInfo;
        }

        private List<Worker> GetWorkers(List<IWebElement> workerInfo)
        {
            var workers = new List<Worker>();

            foreach (var item in workerInfo)
            {
                var name = item.FindElement(_workerName).Text;
                var position = item.FindElement(_workerPosition).Text;
                var office = item.FindElement(_workerOffice).Text;

                var ageText = item.FindElement(_workerAge).Text;
                var age = Convert.ToInt32(ageText);

                var salaryText = item.FindElement(_workerSalary).Text.Trim(new char[] {'$', '/', 'y' });
                var salary = Convert.ToDecimal(salaryText);

                var worker = new Worker(name, position, office, age, salary);

                workers.Add(worker);
            }

            return workers;
        }

        public List<Worker> GetWorkersBySalaryAndAge(int age, decimal salary)
        {           
            var workers = GetAllWorkersList();

            return workers.Where(x => x.Age > age && x.Salary > salary).ToList();
        }

        private List<Worker> GetAllWorkersList()
        {  
            var allWorkers = new List<Worker>();

            var allPages = GetNumberOfTablePages();

            for(var currentPage = 1; currentPage <= allPages; currentPage++)
            {
                var info = GetRowsInfo();
                var workers = GetWorkers(info);                

                allWorkers.AddRange(workers);

                var nextPage = Driver.FindElement(_nextPageButton);

                if(nextPage.Enabled)
                {
                    nextPage.Click();
                }
            }

            return allWorkers;
        }

        private int GetNumberOfTablePages()
        {
            var countOfPages = Driver.FindElements(_numberOfPages).Count;

            return countOfPages;
        }
    }
}
