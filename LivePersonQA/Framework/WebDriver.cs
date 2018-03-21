using LivePersonQA.Framework.Pages;
using OpenQA.Selenium;
using System;

namespace LivePersonQA.Framework
{

    /// <summary>
    /// Helper class hide direct IWebDriver access from tests
    /// </summary>
    class WebDriver
    {
        private IWebDriver _webDriver;

        public WebDriver(IWebDriver webDriver)
        {
            this._webDriver = webDriver;
        }

        internal IWebDriver GetWebDriver()
        {
            return _webDriver;
        }

        public IPage NavigateToPage(Type pageType)
        {
            return NavigateToPage(pageType, "");
        }

        public IPage NavigateToPage(Type pageType, String code)
        {
            Object[] args = { this };
            IPage page = (IPage)Activator.CreateInstance(pageType, args);
            page.NavigateToPage(page, code);
            return page;
        }

        public void Close()
        {
            _webDriver.Close();
        }
    }
}
