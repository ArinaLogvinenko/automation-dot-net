using HardcoreFramework.Models;
using HardcoreFramework.Utils;
using NLog;
using OpenQA.Selenium;
using System;
using System.Globalization;

namespace HardcoreFramework.Pages.GoogleCloud
{
    public class GCPricingCalculatorPage : BasePage
    {
        private readonly By FirstFrameLocator = By.XPath("//iframe[@src][@allow]");
        private readonly By FrameWithFormLocator = By.Id("myFrame");
        private readonly By computeEngineMode = By.XPath("//div[@title='Compute Engine']/parent::md-tab-item");
        private readonly By numberOfInstancesInput = By.XPath("//*[@ng-model='listingCtrl.computeServer.quantity']");
        private readonly By VMClass = By.XPath("//*[@placeholder='VM Class']//div");
        private readonly By instanceTypeLocator = By.XPath("//md-select[@placeholder='Instance type']//div");
        private readonly By seriesLocator = By.XPath("//*[@placeholder='Series']//span/div");
        private readonly By addGpuCheckbox = By.XPath("//*[contains(@ng-model,'listingCtrl.computeServer.addGPUs')]");
        private readonly By gpuTypeLocator = By.XPath("//*[@placeholder='GPU type']");
        private readonly By gpuNumberLocator = By.XPath("//*[@placeholder='Number of GPUs']");
        private readonly By localSsdPlaceholder = By.XPath("//*[contains(@ng-if, 'listingCtrl.checkLocalSsdAvailibility')]");
        private readonly By datacenterPlaceholder = By.XPath("//*[@ng-model='listingCtrl.computeServer.location']");
        private readonly By committedUsagePlaceholder = By.XPath("//*[@ng-model='listingCtrl.computeServer.cud']");
        private readonly By addToEstimateButton = By.XPath("//button[contains(@ng-disabled,'Compute')]");
        private readonly By emailEstimateButton = By.XPath("//button[contains(@ng-click,'EmailForm')]");
        private readonly By enterEmailLocator = By.XPath("//input[@ng-model='emailQuote.user.email']");
        private readonly By sendEmailLocator = By.XPath("//button[@aria-label='Send Email']");

        private readonly Logger logger = LogManager.GetCurrentClassLogger();

        public GCPricingCalculatorPage() : base()
        {
            WaitPageLoading();
        }

        public GCPricingCalculatorPage ActivateMode()
        {
            Driver.SwitchTo().Frame(Driver.FindElement(FirstFrameLocator)).SwitchTo()
                .Frame(Driver.FindElement(FrameWithFormLocator));

            Driver.FindElement(computeEngineMode).Click();

            Driver.SwitchTo().DefaultContent();

            logger.Info($"Compute Engine mode is active!");

            return this;
        }

        public GCPricingCalculatorPage InputNumberOfInstances(int number)
        {
            if (number <= 0)
            {
                throw new ArgumentException("Number of instances is incorrect!");
            }

            Driver.SwitchTo().Frame(Driver.FindElement(FirstFrameLocator)).SwitchTo()
                .Frame(Driver.FindElement(FrameWithFormLocator));

            var input = Driver.FindElement(numberOfInstancesInput);
            input.SendKeys(number.ToString());

            Driver.SwitchTo().DefaultContent();

            logger.Info($"Number of instances is {number}");

            return this;
        }

        public GCPricingCalculatorPage SelectSystem(string operatingSystem)
        {
            if (string.IsNullOrEmpty(operatingSystem))
            {
                throw new ArgumentException("Operation system field is empty!");
            }

            Driver.SwitchTo().Frame(Driver.FindElement(FirstFrameLocator)).SwitchTo()
                .Frame(Driver.FindElement(FrameWithFormLocator));

            var systems = Driver.FindElements(By.XPath($"//md-content//div[@class='md-text'][contains(text(),'{operatingSystem}')]"));
            if (systems.Count == 1)
            {
                Driver.FindElement(By.XPath("//md-select[contains(@aria-label, 'Operating System')]//span[@class]")).Click();
                Driver.FindElement(By.XPath($"//md-content//div[@class='md-text'][contains(text(),'{operatingSystem}')]")).Click();
            }

            Driver.SwitchTo().DefaultContent();

            logger.Info($"System {operatingSystem} is active!");

            return this;
        }

        public GCPricingCalculatorPage SelectVMClass(string vmClass)
        {// /parent::md-option
            if (string.IsNullOrEmpty(vmClass))
            {
                throw new ArgumentException("VM class field is empty!");
            }

            Driver.SwitchTo().Frame(Driver.FindElement(FirstFrameLocator)).SwitchTo()
                .Frame(Driver.FindElement(FrameWithFormLocator));

            if (Driver.FindElement(VMClass).Text != vmClass)
            {
                Driver.FindElement(By.XPath("//*[@placeholder='VM Class']//span[@class]")).Click();
                Driver.FindElement(By.XPath($"//md-option[@value='{vmClass.ToLower()}'][@aria-selected='false'][@ng-disabled]")).Click();
            }

            Driver.SwitchTo().DefaultContent(); 

            logger.Info($"VM class: Regular is active!");

            return this;
        }

        public GCPricingCalculatorPage SelectInstanceType(string type)
        {
            if (string.IsNullOrEmpty(type))
            {
                throw new ArgumentException("Instance type field is empty!");
            }

            Driver.SwitchTo().Frame(Driver.FindElement(FirstFrameLocator)).SwitchTo()
                .Frame(Driver.FindElement(FrameWithFormLocator));

            var instanceType = Driver.FindElement(instanceTypeLocator);
            string text = instanceType.Text.Trim();
            SelectSeries(type.Split('-')[0]);

            if (!text.Equals(type.Trim()))
            {
                Driver.FindElement(By.XPath("//md-select[@placeholder='Instance type']//span[@class]")).Click();
                Driver.FindElement(By.XPath($"//md-option[contains(@value,'{type.Split(' ')[0].ToUpper()}')][@aria-selected='false']")).Click();
            }

            Driver.SwitchTo().DefaultContent();

            logger.Info($"Instance type is {type}");

            return this;
        }

        public GCPricingCalculatorPage SetGpu(string gpuType, int gpuNumber)
        {
            if (string.IsNullOrEmpty(gpuType) || gpuNumber < 0)
            {
                throw new ArgumentException("GPU field is empty or incorrect number of GPUs!");
            }

            Driver.SwitchTo().Frame(Driver.FindElement(FirstFrameLocator)).SwitchTo()
                .Frame(Driver.FindElement(FrameWithFormLocator));

            Waiter.WaitElementIsVisible(addGpuCheckbox);
            Waiter.WaitElementToBeClickable(addGpuCheckbox);
            Driver.FindElement(addGpuCheckbox).Click();

            Driver.FindElement(gpuTypeLocator).Click();
            Driver.FindElement(By.XPath($"//*[contains(@ng-repeat, 'listingCtrl.gpuList')]//div[contains(text(),'{gpuType}')]")).Click();
            Driver.FindElement(gpuNumberLocator).Click();
            Driver.FindElement(By.XPath($"//*[contains(@ng-repeat, 'supportedGpuNumbers')]//div[contains(text(),'{gpuNumber}')]")).Click();

            Driver.SwitchTo().DefaultContent();

            logger.Info($"GPU type is { gpuType }, number of GPUs is { gpuNumber }");

            return this;
        }

        public GCPricingCalculatorPage SelectLocalSsd(string ssd)
        {
            if (string.IsNullOrEmpty(ssd))
            {
                throw new ArgumentException("Local SSD field is empty!");
            }

            Driver.SwitchTo().Frame(Driver.FindElement(FirstFrameLocator)).SwitchTo()
                .Frame(Driver.FindElement(FrameWithFormLocator));

            Driver.FindElement(localSsdPlaceholder).Click();
            Driver.FindElement(By.XPath($"//*[contains(@ng-repeat, 'item in listingCtrl.dynamicSsd.computeServer')]//div[contains(text(),'{ssd}')]")).Click();

            Driver.SwitchTo().DefaultContent();

            logger.Info($"Local SSD is {ssd}");

            return this;
        }

        public GCPricingCalculatorPage SelectDatacenterLocation(string datacenter)
        {
            if (string.IsNullOrEmpty(datacenter))
            {
                throw new ArgumentException("Datacenter location field is empty!");
            }

            Driver.SwitchTo().Frame(Driver.FindElement(FirstFrameLocator)).SwitchTo()
                .Frame(Driver.FindElement(FrameWithFormLocator));

            Driver.FindElement(datacenterPlaceholder).Click();
            Driver.FindElement(By.XPath($"//*[contains(@ng-repeat, 'item in listingCtrl.fullRegionList | filter:listingCtrl.inputRegionText.computeServer')]//div[contains(text(),'{datacenter}')]")).Click();

            Driver.SwitchTo().DefaultContent();

            logger.Info($"Datacenter location is {datacenter}");

            return this;
        }

        public GCPricingCalculatorPage SelectCommittedUsage(string committedUsage)
        {
            if (string.IsNullOrEmpty(committedUsage))
            {
                throw new ArgumentException("Committed usage field is empty!");
            }

            Driver.SwitchTo().Frame(Driver.FindElement(FirstFrameLocator)).SwitchTo()
                .Frame(Driver.FindElement(FrameWithFormLocator));

            Driver.FindElement(committedUsagePlaceholder).Click();
            Driver.FindElement(By.XPath($"//*[@id='select_container_127']//div[contains(text(),'{committedUsage}')]")).Click();

            Driver.SwitchTo().DefaultContent();

            logger.Info($"Committed usage is {committedUsage}");

            return this;
        }

        public GCPricingCalculatorPage AddToEstimate()
        {
            Driver.SwitchTo().Frame(Driver.FindElement(FirstFrameLocator)).SwitchTo()
                .Frame(Driver.FindElement(FrameWithFormLocator));

            Driver.FindElement(addToEstimateButton).Click();

            Driver.SwitchTo().DefaultContent();

            return this;
        }

        public GCPricingCalculatorPage EmailEstimate(string email)
        {
            if (string.IsNullOrEmpty(email))
            {
                throw new ArgumentException("Email field is empty!");
            }

            Driver.SwitchTo().Frame(Driver.FindElement(FirstFrameLocator)).SwitchTo()
                .Frame(Driver.FindElement(FrameWithFormLocator));

            Driver.FindElement(emailEstimateButton).Click();
            Driver.FindElement(enterEmailLocator).SendKeys(email);
            Driver.FindElement(sendEmailLocator).Click();

            Driver.SwitchTo().DefaultContent();

            logger.Info($"Email with information sended to {email}");

            return this;
        }

        public double GetTotalPrice()
        {
            Driver.SwitchTo().Frame(Driver.FindElement(FirstFrameLocator)).SwitchTo()
                    .Frame(Driver.FindElement(FrameWithFormLocator));

            string message = Driver.FindElement(By.XPath("//b[contains(text(),'Total')]")).Text;
            message.Replace(",", "");
            int first = message.IndexOf('D') + 1;
            int last = message.IndexOf('p') - 1;

            Driver.SwitchTo().DefaultContent();

            IFormatProvider formatter = new NumberFormatInfo { NumberDecimalSeparator = "." };
            return double.Parse(message.Substring(first, last - first), formatter);
        }

        public GCPricingCalculatorPage FillComputerEngineForm(ComputeEngine computeEngine)
        {
            try
            {
                InputNumberOfInstances(computeEngine.NumberOfInstances)
                     .SelectSystem(computeEngine.OperatingSystem).SelectVMClass(computeEngine.VMClass)
                     .SelectInstanceType(computeEngine.InstanceType)
                     .SetGpu(computeEngine.GPUType, computeEngine.NumberOfGPUs)
                     .SelectLocalSsd(computeEngine.LocalSSD)
                     .SelectDatacenterLocation(computeEngine.DatacenterLocation)
                     .SelectCommittedUsage(computeEngine.CommitedUsage);
            }
            catch (ArgumentException ex)
            {
                logger.Error(ex.Message);
            }
            catch (Exception ex)
            {
                logger.Error(ex.Message);
            }
            return this;
        }

        private void SelectSeries(string sery)
        {
            if (string.IsNullOrEmpty(sery))
            {
                throw new ArgumentException("Series field is empty!");
            }

            var series = Driver.FindElement(seriesLocator);

            if (!series.Text.Equals(sery))
            {
                Driver.FindElement(By.XPath("//md-select[@placeholder='Series']//span[@class]")).Click();
                Driver.FindElement(By.XPath($"//md-option[contains(@value,'{sery}')]")).Click();
            }
        }

        private void WaitPageLoading()
        {
            Waiter.WaitPageLoading();
        }
    }
}
