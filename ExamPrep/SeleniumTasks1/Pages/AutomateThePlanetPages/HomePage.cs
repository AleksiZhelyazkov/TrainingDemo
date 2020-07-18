using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTasks1.Pages.AutomateThePlanet
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver)
        {

        }

        public IWebElement BlogButton => Driver.FindElement(By.Id("menu-item-6"));
    }
}
