using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumTasks1.Pages;
using SeleniumTasks1.Pages.AutomateThePlanet;
using SeleniumTasks1.Tests;
using System.IO;
using System.Linq;
using System.Threading;

namespace SeleniumTasks1
{
    public class PageTests : BaseTest
    {
        private IWebDriver _driver;
        private Pages.HomePage _homePage;
        private Pages.AutomateThePlanet.HomePage _automateThePlanetPage;
        private BlogPage _blogpage;
        private ArticlePage _articlePage;

        [SetUp]
        public void Setup()
        {
            Initialize("https://www.automatetheplanet.com/");
            _homePage = new Pages.HomePage(_driver);
            _automateThePlanetPage = new SeleniumTasks1.Pages.AutomateThePlanet.HomePage(_driver);
            _blogpage = new BlogPage(_driver);
            _articlePage = new ArticlePage(_driver); 
        }

        [TearDown]
        public void TearDown()
        {
            MakeScreenshotOnFailedTests();
            CloseBrowser();
        }


        [Test]
        public void AutomateThePlanet()
        {
            _driver.Url = "https://www.automatetheplanet.com/";

            _automateThePlanetPage.BlogButton.Click();
            _blogpage.Articles[2].Click();

            for (int i = 0; i < _articlePage.NavigationMainTitles.Count; i++)
            {
                if (_articlePage.QuickNavigation.Displayed == true)
                {
                    _articlePage.ScrollTo(_articlePage.QuickNavigation);
                    _articlePage.Scroll(150);

                    _articlePage.NavigationMainTitles[i].Click();
                    Assert.IsTrue(_articlePage.MainHeaders[i].Displayed);
                }
            }

            var navigationTitles = _articlePage.NavigationMainTitles.Select(e => e.Text).ToList();
            var Titles = _articlePage.MainHeaders.Select(e => e.Text).ToList();

            CollectionAssert.AreEqual(navigationTitles, Titles);
        }


    }
}