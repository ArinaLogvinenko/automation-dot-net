using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System;

namespace HardcoreFramework
{
    public class CommonConditions
    {
        protected IWebDriver driver;
        public const string GOOGLE_CLOUD_URL = "https://cloud.google.com/";
        public const string INFO_TO_SEARCH = "Pricing Calculator";
        public const string CALCULATOR_URL = "https://cloud.google.com/products/calculator";
        public const string YOPMAIL_URL = "https://yopmail.com/ru/";

        [SetUp]
        public void Setup()
        {
            driver = Driver.DriverInstance.GetInstance();
        }

        [TearDown]
        public void StopBrowser()
        {
            var result = TestContext.CurrentContext.Result.Outcome;
            if (result.Equals(ResultState.Failure) || result.Equals(ResultState.Error))
            {
                var screenFile = ((ITakesScreenshot)Driver.DriverInstance.GetInstance()).GetScreenshot();
                screenFile
                    .SaveAsFile($"D:/HardcoreFramework/HardcoreFramework/Target/Screenshots/{DateTime.Now.ToString("dd_MM_yy_HH_mm_ss")}.png", ScreenshotImageFormat.Png);
            }
            Driver.DriverInstance.CloseBrowser();
        }
    }
}