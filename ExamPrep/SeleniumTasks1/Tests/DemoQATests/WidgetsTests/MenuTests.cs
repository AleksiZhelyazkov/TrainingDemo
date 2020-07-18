using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTasks1.Pages;

namespace SeleniumTasks1.Tests.DemoQATests.WidgetsTests
{
    public class MenuTests : BaseTest
    {
        private HomePage _homePage;
        private MenuPage _menuPage;

        [SetUp]
        public void DemoQASetup()
        {
            Initialize("http://demoqa.com/");
            _homePage = new HomePage(Driver);
            _menuPage = new MenuPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            MakeScreenshotOnFailedTests();
            CloseBrowser();
        }

        [Test]
        public void Menu()
        {
            _homePage.Widget.Click();

            _menuPage.ScrollTo(_menuPage.MenuButton).Click();
            _menuPage.HoverMainMenu2();

            var subMenu = Driver.FindElement(By.XPath("//div[@class='nav-menu-container']//ul//a[normalize-space(text())='Sub Item']"));
            Assert.IsTrue(subMenu.Displayed);
        }
    }
}
