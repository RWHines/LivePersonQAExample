using System;
using System.Collections.Generic;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace LivePersonQA.Framework.Pages
{
    /// <summary>
    /// Base class for all webpages. Implments navigation and element waits to ensure pages load properly. 
    /// Generics weren't really used at this stage, but would be used later in a more robust framework.
    /// </summary>
    abstract class PageBase<T> : IPage
    {
        protected WebDriver WebDriver;
        
        //List of all elements to be checked for to verify a page has loaded, these are added to in a child page's constructor
        protected List<By> WaitForElements = new List<By>();

        public PageBase(WebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
            PageFactory.InitElements(WebDriver.GetWebDriver(), this);
        }

        public abstract string GetUrl();

        public abstract T NavigateToPage(WebDriver webDriver);
        public T NavigateToPage(WebDriver webDriver, string pageCode)
        {
            return NavigateToPage(webDriver);
        }

        //Waits for certain elements to be active on page to ensure page load
        protected void WaitForPage()
        {
            WebDriverWait wait = new WebDriverWait(WebDriver.GetWebDriver(), new TimeSpan(0, 0, 10));

            foreach (By element in WaitForElements)
            {
                try
                {
                    wait.Until(ExpectedConditions.ElementIsVisible(element));
                }
                catch (WebDriverTimeoutException e)
                {
                    throw new WebDriverTimeoutException(String.Format("Timed out waiting for element {0}", element.ToString()), e);
                }
                
            }
        }

        public IPage NavigateToPage(IPage page)
        {
            return NavigateToPage(page, "");
        }

        
        //Sets webdriver url to page and waits for elements
        public IPage NavigateToPage(IPage page, string pageCode)
        {
            WebDriver.GetWebDriver().Url = String.Format(GetUrl(), pageCode);
            WaitForPage();

            return page;
        }
    }
}
