using NUnit.Framework;
using OpenQA.Selenium;
using System;

namespace PageObjectTests.Helpers
{
    public class ReportHelper
    {
        public void GenerateReport()
        {
            var fileName = String.Format("Test_{0}_{1}", TestContext.CurrentContext.Test.MethodName, DateTime.Now.ToString("yyyyMMdd_HHmm"));
            Browser.PrintScreen(fileName, ScreenshotImage‌​Format.Png);       
        }
    }
}
