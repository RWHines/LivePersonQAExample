using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;

namespace LivePersonQA.Framework.Pages
{
    /// <summary>
    /// Class to hold shared header elements. This would be followed by a footer class for footer elements, but those aren't used in the example tests.
    /// </summary>
    abstract class Header<T> : PageBase<T>
    {
        const String _searchId = "search_query_top";
        [FindsBy(How = How.Id, Using = _searchId)]
        IWebElement Search;

        const String _searchButton = "submit_search";
        [FindsBy(How = How.Name, Using = _searchButton)]
        IWebElement SearchButton;

        public Header(WebDriver WebDriver) : base(WebDriver)
        {
            WaitForElements.Add(By.Id(_searchId));
            WaitForElements.Add(By.Name(_searchButton));
        }

        public void EnterSearchQuery(String query)
        {
            Search.Click();
            Search.SendKeys(query);
        }

        public SearchResultsPage ClickSearch()
        {
            SearchButton.Click();
            return new SearchResultsPage(WebDriver);
        }
    }
}
