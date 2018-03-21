using LivePersonQA.Framework;
using NUnit.Framework;

namespace LivePersonQA.TestCases
{
    /// <summary>
    /// Base class to initialize WebDriver
    /// </summary>
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