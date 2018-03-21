using LivePersonQA.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.ObjectModel;
using System.Net;

namespace LivePersonQA.TestCases
{
    class ProductSearchTestCases : TestCaseBase
    {
        private String _productPriceClass = "product-price";

        //Count number of search result responses for test 1
        [Test]
        public void ResultsCountSummerDress()
        {
            var results = GetSearchResults("Printed Summer Dress");

            Assert.True(results.Count > 0, "Printed Summer Dress returns 0 search results.");
        }

        //Validate result information for test 2
        [Test]
        public void ResultValidateSummerDress()
        {
            var results = GetSearchResults("Printed Summer Dress");

            foreach (IWebElement result in results)
            {
                ValidateSearchResult(result, results.IndexOf(result) + 1);
            }
        }

        private ReadOnlyCollection<IWebElement> GetSearchResults(String searchTerm)
        {
            HomePage homePage = (HomePage)Driver.NavigateToPage(typeof(HomePage));

            homePage.EnterSearchQuery("Printed Summer Dress");
            SearchResultsPage resultsPage = homePage.ClickSearch();

            return resultsPage.GetResults();
        }

        //Test name, price, and image url
        private void ValidateSearchResult(IWebElement element, int position)
        {

            IWebElement rightBlock = element.FindElement(By.ClassName("right-block"));

            try
            {
                IWebElement productName = rightBlock.FindElement(By.ClassName("product-name"));
                Assert.IsNotNull(productName.Text, "Product at position {0} has null name.", position);
                Assert.IsNotEmpty(productName.Text, "Product at position {0} has empty name.", position);
                Console.Out.WriteLine(String.Format("Found name {0} for product at position {1}", productName.Text, position));
            }
            catch (NoSuchElementException e)
            {
                Assert.Fail(String.Format("Product at position {0} does not have a name.", position));
            }

            try
            {
                IWebElement productPrice = rightBlock.FindElement(By.ClassName("product-price"));
                Assert.IsNotNull(productPrice.Text, "Product at position {0} has null price.", position);
                Assert.IsNotEmpty(productPrice.Text, "Product at position {0} has empty price.", position);
                Console.Out.WriteLine(String.Format("Found price {0} for product at position {1}", productPrice.Text, position));
            }
            catch (NoSuchElementException e)
            {
                Assert.Fail(String.Format("Product at position {0} does not have a price.", position));
            }


            IWebElement leftBlock = element.FindElement(By.ClassName("left-block"));

            String imageUrl = "";

            try
            {
                imageUrl = element.FindElement(By.TagName("img")).GetAttribute("src");
                Console.Out.WriteLine(String.Format("Found imageUrl {0} for product at position {1}", imageUrl, position));
            }
            catch (NoSuchElementException e)
            {
                Assert.Fail(String.Format("Product at position {0} does not have an image.", position));
            }

            try
            {
                HttpWebRequest request = WebRequest.Create(imageUrl) as HttpWebRequest;
                request.Method = "HEAD";
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                response.Close();
                Console.Out.WriteLine(String.Format("ImageUrl returned  {0} for product at position {1}", response.StatusCode.ToString(), position));
                Assert.True(response.StatusCode == HttpStatusCode.OK, String.Format("Image URL returned status code {0} at position {1}", response.StatusCode.ToString(), position));
            }
            catch
            {
                Assert.Fail("Failed to query server for image url");
            }

            
        }
    }
}
