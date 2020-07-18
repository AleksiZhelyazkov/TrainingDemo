using NUnit.Framework;
using SeleniumTasks1.Pages;

namespace SeleniumTasks1.Tests.DemoQATests.WidgetsTests
{
    public class ProgressBarTests : BaseTest
    {
        private HomePage _homePage;
        private ProgressBarPage _progressBarPage;

        [SetUp]
        public void DemoQASetup()
        {
            Initialize("http://demoqa.com/");
            _homePage = new HomePage(Driver);
            _progressBarPage = new ProgressBarPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            MakeScreenshotOnFailedTests();
            CloseBrowser();
        }

        [Test]
        public void ProgressBar()
        {
            _homePage.Widget.Click();
            _progressBarPage.ScrollTo(_progressBarPage.ProgressBarButton).Click();

            int percent = 22;
            _progressBarPage.Load();

            int value = int.Parse(_progressBarPage.loadBar.GetAttribute("aria-valuenow"));
            Assert.AreEqual(percent, value);
        }
    }
}
