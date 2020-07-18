using Newtonsoft.Json.Bson;
using OpenQA.Selenium;

namespace SeleniumTasks1.Pages
{
    public class ToolTipsPage : NavigationBarPage
    {
        public ToolTipsPage(IWebDriver driver) : base(driver)
        {


        }

        public IWebElement Input => Driver.FindElement(By.Id("toolTipTextField"));

        public IWebElement ToolTipDiv => Driver.FindElement(By.Id("textFieldToolTip"));

        public void HoverToolTip()
        {
            Action.MoveToElement(Input).Perform();
        }
    }
}
