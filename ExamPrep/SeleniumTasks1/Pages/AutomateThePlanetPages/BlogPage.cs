using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace SeleniumTasks1.Pages.AutomateThePlanet
{
    public class BlogPage : BasePage
    {
        public BlogPage(IWebDriver driver) : base(driver)
        {
        }

        public List<IWebElement> Articles => Driver.FindElements(By.XPath("//*[@class='so-panel widget widget_categorylist']//article")).ToList();

        //public List<IWebElement> Articles => Wait.Until(d=>d.FindElements(By.XPath("//*[@class='so-panel widget widget_categorylist']//article")).ToList());
    }
}
