using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;

namespace SeleniumTasks1.Tests
{
    public abstract class BaseTest
    {
        public IWebDriver Driver { get; private set; }
        public void Initialize(string url)
        {
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(url);
        }
        
        protected void MakeScreenshotOnFailedTests()
        {
            if (TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var screenshot = ((ITakesScreenshot)Driver).GetScreenshot();
                screenshot.SaveAsFile($"{Directory.GetCurrentDirectory()}/{TestContext.CurrentContext.Test.Name}.png", ScreenshotImageFormat.Png);
            }
        }

        protected void CloseBrowser()
        {
            if (Driver != null)
            {
                Driver.Quit();
            }
        }
    }
}
