using OpenQA.Selenium;

namespace HardcoreFramework.Pages.GoogleCloud
{
    public class GCMainPage : BasePage
    {
        private readonly By searchButtonLocator = By.XPath("//input[@placeholder='Search']");

        private readonly IWebElement searchButton;

        public GCMainPage() : base()
        {
            searchButton = Driver.FindElement(searchButtonLocator);
        }

        public GCResultPage SearchInformation(string query)
        {
            searchButton.Click();
            searchButton.SendKeys(query);
            searchButton.SendKeys(Keys.Enter);

            return new GCResultPage();
        }
    }
}
