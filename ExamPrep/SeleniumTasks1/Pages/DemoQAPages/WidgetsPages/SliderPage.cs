using Newtonsoft.Json.Bson;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace SeleniumTasks1.Pages
{
    public class SliderPage : NavigationBarPage
    {
        public SliderPage(IWebDriver driver) : base(driver)
        {
        }

        public IWebElement Slider => Driver.FindElement(By.XPath("//input[@type='range']"));

        public void MoveSlider(int pixels)
        {
            //int pixels = 5;

            Action.DragAndDropToOffset(Slider, pixels, 0).Perform();

        }
    }
}
