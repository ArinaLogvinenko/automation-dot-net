using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;

namespace HardcoreFramework.Driver
{
    public class DriverInstance
    {
        private static IWebDriver driver;

        private DriverInstance() { }

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                //Environment.SetEnvironmentVariable("browser", "firefox");

                if (Environment.GetEnvironmentVariable("browser").Equals("chrome"))
                {
                    driver = new ChromeDriver();
                }
                else if (Environment.GetEnvironmentVariable("browser").Equals("firefox"))
                {
                    var firefoxPath = @"C:\Users\User\Desktop";
                    driver = new FirefoxDriver(firefoxPath);
                }

                driver.Manage().Timeouts().ImplicitWait.Add(TimeSpan.FromSeconds(60));
                driver.Manage().Window.Maximize();
            }

            return driver;
        }

        public static void CloseBrowser()
        {
            driver.Quit();
            driver = null;
        }
    }
}
