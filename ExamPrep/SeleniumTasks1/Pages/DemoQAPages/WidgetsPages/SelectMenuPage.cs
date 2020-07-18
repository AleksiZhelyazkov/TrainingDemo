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
    public class SelectMenuPage : NavigationBarPage
    {
        public SelectMenuPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement SelectValueMenu => Driver.FindElement(By.XPath("//div[@class=' css-1hwfws3']"));


        public void SelectGroup2Option2()
        {
            Action.MoveToElement(SelectValueMenu).Click().Perform();

            //List<IWebElement>Group2 = Driver.FindElements(By.XPath("//div[@class=' css-26l3qy-menu']//*[normalize-space(text())='Group 2']")).ToList();

            //Group2[1].Click();
            var Group2 = Driver.FindElement(By.XPath("//div[@class=' css-26l3qy-menu']//*[normalize-space(text())='Group 2, option 2']"));

            Group2.Click();
        }
    }
}
