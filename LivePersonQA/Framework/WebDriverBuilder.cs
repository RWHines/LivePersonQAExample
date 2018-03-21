using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePersonQA.Framework
{

    enum Browser
    {
        CHROME,
        FIREFOX
    }

    static class WebDriverBuilder
    {

        public static WebDriver GetWebDriver(Browser browser)
        {

            WebDriver webDriver;

            switch (browser)
            {
                case Browser.CHROME:
                    webDriver = new WebDriver(new ChromeDriver());
                    break;
                case Browser.FIREFOX:
                    webDriver = new WebDriver(new FirefoxDriver());
                    break;
                default:
                    throw new Exception(String.Format("Browser {0} not implemented", browser));

            }

            return webDriver;
        }

    }
}
