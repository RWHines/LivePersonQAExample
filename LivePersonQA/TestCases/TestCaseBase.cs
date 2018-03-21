using LivePersonQA.Framework;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace LivePersonQA.TestCases
{
    class TestCaseBase
    {
        protected WebDriver Driver;

        [OneTimeSetUp]
        public void Initialize()
        {
            Driver = WebDriverBuilder.GetWebDriver(Browser.CHROME);
        }

        [OneTimeTearDown]
        public void EndTest()
        {
            Driver.Close();
        }

    }
}