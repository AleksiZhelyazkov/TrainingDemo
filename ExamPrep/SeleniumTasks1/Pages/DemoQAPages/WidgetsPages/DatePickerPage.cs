using OpenQA.Selenium;
namespace SeleniumTasks1.Pages
{
    public class DatePickerPage : NavigationBarPage
    {
        public DatePickerPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement SelectDateTable => Driver.FindElement(By.Id("datePickerMonthYearInput"));

        public IWebElement currentMonth => Driver.FindElement(By.CssSelector(".react-datepicker__current-month"));
        public IWebElement currentDay => Driver.FindElement(By.CssSelector(".react-datepicker__day--selected"));

        public void ClearSelectDate()
        {
            for (int i = 0; i < 10; i++)
            {
                SelectDateTable.SendKeys(Keys.Backspace);
            }
        }

        public void FillDate(string month, string day)
        {
            SelectDateTable.SendKeys($"{month}/{day}/2020");
        }

        public string GetMonth(string month)
        {
            switch (month)
            {
                case "01": month = "January"; break;
                case "02": month = "February"; break;
                case "03": month = "March"; break;
                case "04": month = "April"; break;
                case "05": month = "May"; break;
                case "06": month = "June"; break;
                case "07": month = "July"; break;
                case "08": month = "August"; break;
                case "09": month = "September"; break;
                case "10": month = "October"; break;
                case "11": month = "November"; break;
                case "12": month = "December"; break;
            }
            return month;
        }
    }
}
