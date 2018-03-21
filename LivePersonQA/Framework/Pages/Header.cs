using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePersonQA.Framework.Pages
{
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
