using NUnit.Framework;
using SeleniumTasks1.Pages;

namespace SeleniumTasks1.Tests.DemoQATests.WidgetsTests
{
    public class ToolTipsTests : BaseTest
    {
        private HomePage _homePage;
        private ToolTipsPage _tooltipPage;

        [SetUp]
        public void DemoQASetup()
        {
            Initialize("http://demoqa.com/");
            _homePage = new HomePage(Driver);
            _tooltipPage = new ToolTipsPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            MakeScreenshotOnFailedTests();
            CloseBrowser();
        }

        [Test]
        public void ToolTip()
        {
            _homePage.Widget.Click();
            _tooltipPage.ScrollTo(_tooltipPage.ToolTipButton).Click();

            _tooltipPage.HoverToolTip();

            Assert.IsTrue(_tooltipPage.ToolTipDiv.Displayed);
            Assert.AreEqual("You hovered over the text field", _tooltipPage.ToolTipDiv.Text);
        }
    }
}
