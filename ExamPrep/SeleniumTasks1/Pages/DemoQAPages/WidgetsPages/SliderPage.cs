using OpenQA.Selenium;

namespace SeleniumTasks1.Pages
{
    public class SliderPage : NavigationBarPage
    {
        public SliderPage(IWebDriver driver) : base(driver)
        {
        }
        public IWebElement SliderPath => Driver.FindElement(By.CssSelector(".range-slider"));

        public void MoveSlider(int points)
        {
            if (points>=0)
            {
                for (int i = 0; i < points; i++)
                {
                    SliderPath.SendKeys(Keys.ArrowUp);
                }
            }
            else if (points<0)
            {
                for (int i = points; i < 0; i++)
                {
                    SliderPath.SendKeys(Keys.ArrowDown);
                }
            }
        }
    }
}
