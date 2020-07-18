using Newtonsoft.Json.Bson;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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

        public IWebElement loadBar => Driver.FindElement(By.CssSelector(".progress-bar"));

        public void Load(string percent)
        {
            this.WaitForLoad();
            startButton.Click();

            while (loadBar.GetAttribute("aria-valuenow") != percent)
            {
                
            }
            startButton.Click();
        }
    }
}
