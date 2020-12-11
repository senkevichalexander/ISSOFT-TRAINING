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
        private const string tableSortSearchPage = "https://www.seleniumeasy.com/test/table-sort-search-demo.html";
        private readonly By numberSelect = By.CssSelector("select[name='example_length']");
        private readonly By informationAboutWorker = By.CssSelector("tbody>tr");
        private readonly By workerName = By.CssSelector("tr>td:nth-child(1)");
        private readonly By workerPosition= By.CssSelector("tr>td:nth-child(2)");
        private readonly By workerOffice = By.CssSelector("tr>td:nth-child(3)");
        private readonly By workerAge = By.CssSelector("tr>td:nth-child(4)");
        private readonly By workerSalary = By.CssSelector("tr>td:nth-child(6)");
        private readonly By netxPageButton = By.CssSelector("#example_next");
        private readonly By numberOfPages = By.CssSelector("span>a");

        public void OpenTableSortSearchDemoPage()
        {
            Driver.Navigate().GoToUrl(tableSortSearchPage);
        }

        public void ChooseQuantityOfEntries(string countOfRows)
        {
            var selectElement = new SelectElement(Driver.FindElement(numberSelect));
            selectElement.SelectByValue(countOfRows);
        }

        private List<IWebElement> GetRowsInfo()
        {
            var rowInfo = Driver.FindElements(informationAboutWorker).ToList();

            return rowInfo;
        }

        private List<Worker> GetWorkers(List<IWebElement> workerInfo)
        {
            var workers = new List<Worker>();

            foreach (var item in workerInfo)
            {
                var name = item.FindElement(workerName).Text;
                var position = item.FindElement(workerPosition).Text;
                var office = item.FindElement(workerOffice).Text;

                var ageText = item.FindElement(workerAge).Text;
                var age = Convert.ToInt32(ageText);

                var salaryText = item.FindElement(workerSalary).Text.Trim(new char[] {'$', '/', 'y' });
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

                var nextPage = Driver.FindElement(netxPageButton);

                if(nextPage.Enabled)
                {
                    nextPage.Click();
                }
            }

            return allWorkers;
        }

        private int GetNumberOfTablePages()
        {
            var countOfPages = Driver.FindElements(numberOfPages).Count;

            return countOfPages;
        }
    }
}
