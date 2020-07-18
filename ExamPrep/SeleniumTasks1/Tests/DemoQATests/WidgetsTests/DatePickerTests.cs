using NUnit.Framework;
using OpenQA.Selenium;
using SeleniumTasks1.Pages;



namespace SeleniumTasks1.Tests.DemoQATests.WidgetsTests
{
    public class DatePickerTests : BaseTest
    {
        private HomePage _homePage;
        private DatePickerPage _datepickerPage;


        [SetUp]
        public void DemoQASetup()
        {
            Initialize("http://demoqa.com/");
            _homePage = new HomePage(Driver);
            _datepickerPage = new DatePickerPage(Driver);
        }

        [TearDown]
        public void TearDown()
        {
            MakeScreenshotOnFailedTests();
            CloseBrowser();
        }


        [Test]
        [TestCase("01", "17")]
        [TestCase("02", "17")]
        [TestCase("03", "17")]
        [TestCase("04", "17")]
        [TestCase("05", "17")]
        [TestCase("06", "17")]
        [TestCase("07", "17")]
        [TestCase("08", "17")]
        [TestCase("09", "17")]
        [TestCase("10", "17")]
        [TestCase("11", "17")]
        [TestCase("12", "17")]
        public void DatePicker(string month, string day)
        {
            _homePage.Widget.Click();
            _datepickerPage.ScrollTo(_datepickerPage.DatePickerButton).Click();

            _datepickerPage.ClearSelectDate();
            _datepickerPage.FillDate(month, day);

            string expectedDate = _datepickerPage.GetMonthName(month) + " 2020";
            string actualDate = _datepickerPage.currentMonth.Text;
            string expectedDay = day;
            string actualDay = _datepickerPage.currentDay.Text;

            Assert.AreEqual(expectedDate, actualDate);
            Assert.AreEqual(expectedDay, actualDay);
        }

        [Test]
        [TestCase("01", "17")]
        public void DateAndTimePicker(string month, string day)
        {
            _homePage.Widget.Click();
            _datepickerPage.ScrollTo(_datepickerPage.DatePickerButton).Click();

            string hour = "7";
            string minute = "45";
            string meridiem = "PM";
            _datepickerPage.ClearDateAndTimeField();
            _datepickerPage.FillDateAndTime(month, day, hour, minute, meridiem);

            var state = Driver.FindElement(By.CssSelector(".react-datepicker__time-list-item--selected"));
            string stateText = state.Text;

            Assert.AreEqual(stateText, "19:45");
        }
    }
}