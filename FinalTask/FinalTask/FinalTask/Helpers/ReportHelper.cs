using Allure.Commons;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;

namespace PageObjectTests.Helpers
{
    public class ReportHelper
    {
        public void GenerateReport()
        {
            var fileName = string.Format("Test_{0}_{1}", TestContext.CurrentContext.Test.MethodName, DateTime.Now.ToString("yyyyMMdd_HHmm"));
            Browser.PrintScreen(fileName, ScreenshotImage‌​Format.Png);       
        }

        public void MakeScreenshorAfterTestIsFailed()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                var screen = ((ITakesScreenshot)Browser.Driver).GetScreenshot().AsByteArray;
                AllureLifecycle.Instance.AddAttachment(
                    $"Screenshot_{DateTime.Now:ddMMyyyymmssffff}", "image/png", screen, "png");
            }
        }
    }
}
