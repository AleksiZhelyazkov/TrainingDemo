using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System.Linq;

namespace SeleniumTasks1.Pages
{
    public class AccordianPage : NavigationBarPage
    {
        public AccordianPage (IWebDriver driver) : base(driver)
        {
        }

        public IWebElement SecondTab =>
            Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("section2Content")));

        public void SelectSecondTab()
        {
            var Container = Driver.FindElements(By.ClassName("card"));
            Container.Count();
            var index = 1;
            Container[index].Click();
        }
    }
}
