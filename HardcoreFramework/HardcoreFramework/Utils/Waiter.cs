using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace HardcoreFramework.Utils
{
    public static class Waiter
    {
        public static IWebDriver Driver { get; set; }

        public static int WaitTime { get; set; }

        public static void WaitElementIsVisible(By locator)
        {
            new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime)).Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static void WaitElementToBeClickable(By locator)
        {
            new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime)).Until(ExpectedConditions.ElementToBeClickable(locator));
        }

        public static void WaitVisabilityOfAllElementLocatedBy(By locator)
        {
            new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime)).Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }

        public static void WaitPageLoading()
        {
            new WebDriverWait(Driver, new TimeSpan(0, 0, 0, 0, WaitTime));
        }
    }
}
