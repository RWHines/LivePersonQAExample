using LivePersonQA.Framework.Pages;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePersonQA.Framework
{
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
