using NUnit.Framework;
using SeleniumTasks1.Pages;

namespace SeleniumTasks1.Tests.DemoQATests.WidgetsTests
{
    public class AutoCompletePageTests : BaseTest
    {
        private HomePage _homePage;
        private AutoCompletePage _autoCompletePage;

        [SetUp]
        public void DemoQASetup()
        {
            Initialize("http://demoqa.com/");
            _homePage = new HomePage(Driver);
            _autoCompletePage = new AutoCompletePage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            MakeScreenshotOnFailedTests();
            CloseBrowser();
        }

        [Test]
        public void AutoCompleteRedColor()
        {
            _homePage.Widget.Click();
            _autoCompletePage.ScrollTo(_autoCompletePage.AutoCompleteButton).Click();

            _autoCompletePage.Action
                .MoveToElement(_autoCompletePage.SingleColorField)
                .Click()
                .SendKeys("Re")
                .Perform();

            Assert.IsTrue(_autoCompletePage.RedColorOption.Displayed);
            Assert.IsTrue(_autoCompletePage.GreenColorOption.Displayed);
        }
    }
}
