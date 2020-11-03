using Newtonsoft.Json.Bson;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;

namespace SeleniumTasks1.Pages
{
    public class MenuPage : NavigationBarPage
    {
        public MenuPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement MainItem2 => Driver.FindElement(By.XPath("//div[@class='nav-menu-container']//ul//a[normalize-space(text())='Main Item 2']"));

        public void HoverMainMenu2()
        {


            //MainItem2.GetType();
            //MainItem2.Click();
            Action.MoveToElement(MainItem2).Perform();

        }
    }
}
