using Newtonsoft.Json.Bson;
using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SeleniumTasks1.Pages
{
    public class TabsPage : NavigationBarPage
    {
        public TabsPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement OriginTab => Driver.FindElement(By.Id("demo-tab-origin"));

        public void SelectOriginTab()
        {

            OriginTab.Click();

        }
    }
}
