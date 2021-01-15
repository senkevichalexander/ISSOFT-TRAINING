using Allure.Commons;
using FinalTask.Framework;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;

namespace FinalTask.Helpers
{
    public class ReportHelper
    {
        public void MakeScreenshorAfterTestIsFailed()
        {
            if (TestContext.CurrentContext.Result.Outcome.Status.Equals(TestStatus.Failed))
            {
                var screen = ((ITakesScreenshot)Browser.Driver).GetScreenshot().AsByteArray;
                AllureLifecycle.Instance.AddAttachment(
                    $"Screenshot_{DateTime.Now:ddMMyyyymmssffff} + {Browser.BrowserName}" +
                    $"{Browser.BrowserVersion}", "image/png", screen, "png");
            }
        }
    }
}
