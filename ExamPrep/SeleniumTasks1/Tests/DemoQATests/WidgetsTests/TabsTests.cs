using NUnit.Framework;
using SeleniumTasks1.Pages;

namespace SeleniumTasks1.Tests.DemoQATests.WidgetsTests
{
    public class TabsTests : BaseTest
    {
        private HomePage _homePage;
        private TabsPage _tabsPage;

        [SetUp]
        public void DemoQASetup()
        {
            Initialize("http://demoqa.com/");
            _homePage = new HomePage(Driver);
            _tabsPage = new TabsPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            MakeScreenshotOnFailedTests();
            CloseBrowser();
        }

        [Test]
        public void Tabs()
        {
            _homePage.Widget.Click();

            _tabsPage.ScrollTo(_tabsPage.TabsButton).Click();
            _tabsPage.SelectOriginTab();

            var status = _tabsPage.OriginTab.GetAttribute("aria-selected");
            Assert.IsTrue(status == "true");
        }

    }
}
