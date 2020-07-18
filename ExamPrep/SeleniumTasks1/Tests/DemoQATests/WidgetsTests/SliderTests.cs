using NUnit.Framework;
using SeleniumTasks1.Pages;

namespace SeleniumTasks1.Tests.DemoQATests.WidgetsTests
{
    public class SliderTests : BaseTest
    {
        private HomePage _homePage;
        private SliderPage _sliderPage;

        [SetUp]
        public void DemoQASetup()
        {
            Initialize("http://demoqa.com/");
            _homePage = new HomePage(Driver);
            _sliderPage = new SliderPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            MakeScreenshotOnFailedTests();
            CloseBrowser();
        }

        [Test]
        public void Slider()
        {
            _homePage.Widget.Click();
            _sliderPage.ScrollTo(_sliderPage.SliderButton).Click();

            int movePoints = -7;
            _sliderPage.MoveSlider(movePoints);

            int newPosition = int.Parse(_sliderPage.SliderPath.GetAttribute("value"));
            Assert.AreEqual((25+movePoints),newPosition);
        }
    }
}
