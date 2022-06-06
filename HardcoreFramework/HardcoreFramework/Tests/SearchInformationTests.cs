using HardcoreFramework.Pages.GoogleCloud;
using NUnit.Framework;

namespace HardcoreFramework.Tests
{
    [TestFixture]
    public class SearchInformationTests : CommonConditions
    {
        [Test]
        [Category("Smoke")]
        [Category("All")]
        public void SearchInformationTest()
        {
            driver.Navigate().GoToUrl(GOOGLE_CLOUD_URL);
            GCPricingCalculatorPage calc = new GCMainPage()
               .SearchInformation(INFO_TO_SEARCH)
               .GoToCalculator();

            Assert.NotNull(calc);
        }
    }
}
