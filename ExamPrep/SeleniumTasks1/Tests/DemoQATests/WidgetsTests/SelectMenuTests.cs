using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTasks1.Pages;

namespace SeleniumTasks1.Tests.DemoQATests.WidgetsTests
{
    public class SelectMenuTests : BaseTest
    {
        private HomePage _homePage;
        private SelectMenuPage _selectMenuPage;

        [SetUp]
        public void DemoQASetup()
        {
            Initialize("http://demoqa.com/");
            _homePage = new HomePage(Driver);
            _selectMenuPage = new SelectMenuPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            MakeScreenshotOnFailedTests();
            CloseBrowser();
        }

        [Test]
        public void SelectMenu()
        {
            _homePage.Widget.Click();

            _selectMenuPage.ScrollTo(_selectMenuPage.SelectMenuButton).Click();
            _selectMenuPage.SelectGroup2Option2();

            var state = Driver.FindElement(By.XPath("//div[@class=' css-1uccc91-singleValue']"));
            Assert.AreEqual("Group 2, option 2", state.Text);
        }
    }
}
