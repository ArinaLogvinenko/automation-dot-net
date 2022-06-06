using HardcoreFramework.Driver;
using HardcoreFramework.Utils;
using OpenQA.Selenium;

namespace HardcoreFramework.Pages
{
    public abstract class BasePage
    {
        private readonly int waitTime = 20000;

        protected IWebDriver Driver { get; set; }

        protected BasePage()
        {
            Driver = DriverInstance.GetInstance();
            Waiter.Driver = Driver;
            Waiter.WaitTime = waitTime;
        }
    }
}
