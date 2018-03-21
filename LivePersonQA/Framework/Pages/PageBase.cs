using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LivePersonQA.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Support.PageObjects;

namespace LivePersonQA.Framework.Pages
{
    abstract class PageBase<T> : IPage
    {
        protected WebDriver WebDriver;

        protected List<By> WaitForElements = new List<By>();

        public PageBase(WebDriver WebDriver)
        {
            this.WebDriver = WebDriver;
            PageFactory.InitElements(WebDriver.GetWebDriver(), this);
            WaitForPage();
        }

        public abstract string GetUrl();

        public abstract T NavigateToPage(WebDriver webDriver);
        public T NavigateToPage(WebDriver webDriver, string pageCode)
        {
            return NavigateToPage(webDriver);
        }

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

        
        public IPage NavigateToPage(IPage page, string pageCode)
        {
            WebDriver.GetWebDriver().Url = String.Format(GetUrl(), pageCode);
            WaitForPage();

            return page;
        }
    }
}
