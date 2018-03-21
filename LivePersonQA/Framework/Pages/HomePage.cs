using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace LivePersonQA.Framework.Pages
{
    class HomePage : Header<HomePage>
    {

        const String _homeSliderId = "homeslider";
        [FindsBy(How = How.Id, Using = _homeSliderId)]
        IWebElement HomeSlider;

        //This shows how the WaitForElements should be structured.
        //Selenium tends to be friendly with the WebDriverWait.Until on 'By' clauses, but doesn't
        //work so great with webelements directly.
        //This implementation works around that limitation by adding all id/xpaths/whatever identifier is used
        //as a const, so a 'By' can be easily created for all used IWebElements while still using
        //the [FindsBy] attribute
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
