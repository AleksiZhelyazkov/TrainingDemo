using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using SeleniumTasks1.Pages;
using System;
using System.Collections.Generic;
using System.Text;

namespace SeleniumTasks1.Tests.DemoQATests.WidgetsTests
{
    public class AccordianTests : BaseTest
    {
        private HomePage _homePage;
        private AccordianPage _accordianPage;

        [SetUp]
        public void DemoQASetup()
        {
            Initialize("http://demoqa.com/");
            _homePage = new HomePage(Driver);
            _accordianPage = new AccordianPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            MakeScreenshotOnFailedTests();
            CloseBrowser();
        }

        [Test]
        public void Accordian()
        {
            _homePage.Widget.Click();

            _accordianPage.ScrollTo(_accordianPage.AccordianButton).Click();
            _accordianPage.SelectSecondTab();

            Assert.IsTrue(_accordianPage.SecondTab.Displayed);
        }

    }
}
