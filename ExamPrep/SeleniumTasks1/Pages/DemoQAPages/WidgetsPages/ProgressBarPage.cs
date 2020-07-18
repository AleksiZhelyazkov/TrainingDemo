using Newtonsoft.Json.Bson;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SeleniumTasks1.Pages
{
    public class ProgressBarPage : NavigationBarPage
    {
        public ProgressBarPage (IWebDriver driver) : base(driver)
        {
        }

        public IWebElement progressBar => Driver.FindElement(By.Id("progressBar"));
        public IWebElement startButton => Driver.FindElement(By.Id("startStopButton"));

        public IWebElement loadBar => Driver.FindElement(By.XPath("//div[@id='progressBar']//div"));

        public void Load()
        {
            //int percent = 22;
            this.WaitForLoad();
            startButton.Click();

            var state = Wait.Until(ExpectedConditions.TextToBePresentInElementValue(loadBar, "22%"));
            startButton.Click();
            
            
            //int value = int.Parse(loadBar.GetAttribute("aria-valuenow"));

            //while (value != percent)
            //{
            //    value = int.Parse(loadBar.GetAttribute("aria-valuenow"));
            //}
            //startButton.Click();


        }
    }
}
