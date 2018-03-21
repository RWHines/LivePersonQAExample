using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace LivePersonQA.Framework.Pages
{
    class SearchResultsPage : PageBase<SearchResultsPage>
    {
        const String _resultsGridId = "center_column";
        [FindsBy(How = How.Id, Using = _resultsGridId)]
        IWebElement ResultsGrid;


        public SearchResultsPage(WebDriver WebDriver) : base(WebDriver)
        {
            WaitForElements.Add(By.Id(_resultsGridId));
        }

        public override string GetUrl()
        {
            return "http://automationpractice.com/index.php?controller=search&orderby=position&orderway=desc&search_query=test&submit_search=";
        }

        public override SearchResultsPage NavigateToPage(WebDriver webDriver)
        {
            return (SearchResultsPage)NavigateToPage(this);
        }

        public ReadOnlyCollection<IWebElement> GetResults()
        {
            ReadOnlyCollection<IWebElement> results;

            if (ResultsGrid.FindElements(By.ClassName("alert-warning")).Count > 0)
            {
                results = new ReadOnlyCollection<IWebElement>(new List<IWebElement>());
            }
            else
            {
                results = ResultsGrid.FindElements(By.ClassName("ajax_block_product"));
            }

            return results;
        }
    }
}