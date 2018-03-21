using LivePersonQA.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePersonQA.Framework.Pages
{
    class HomePage : Header<HomePage>
    {

        const String _homeSliderId = "homeslider";
        [FindsBy(How = How.Id, Using = _homeSliderId)]
        IWebElement HomeSlider;


        public HomePage(WebDriver WebDriver) : base(WebDriver)
        {
            WaitForElements.Add(By.Id(_homeSliderId));
        }

        public override string GetUrl()
        {
            return "http://automationpractice.com/index.php";
        }

        public override HomePage NavigateToPage(WebDriver webDriver)
        {
            return (HomePage)NavigateToPage(this);
        }

        
    }
}
