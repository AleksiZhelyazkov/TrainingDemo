using OpenQA.Selenium;
using System.Collections.Generic;
using System.Linq;

namespace SeleniumTasks1.Pages.AutomateThePlanet
{
    public class ArticlePage : BasePage
    {
        public ArticlePage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement QuickNavigation => Driver.FindElement(By.ClassName("tve_ct_title"));

        public List<IWebElement> NavigationMainTitles => Driver.FindElements(By.ClassName("tve_ct_level0")).ToList();

        public List<IWebElement> NavigationSecondaryTitles => Driver.FindElements(By.ClassName("tve_ct_level1")).ToList();

        public List<IWebElement> MainHeaders => Driver.FindElements(By.XPath("//*[@id='tve_flt']//h2")).ToList();

        public List<IWebElement>SecondaryHeaders => Driver.FindElements(By.XPath("//*[@id='tve_flt']//h3")).ToList();
    }
}
