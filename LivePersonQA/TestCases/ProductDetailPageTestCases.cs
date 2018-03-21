using LivePersonQA.Framework.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePersonQA.TestCases
{
    class ProductDetailPageTestCases : TestCaseBase
    {

        [Test]
        public void DetailPageValidation()
        {
            string productId = "3";

            ProductPage detailsPage = (ProductPage) Driver.NavigateToPage(typeof(ProductPage), productId);

            IWebElement productName = detailsPage.GetProductName();
            Assert.IsNotEmpty(productName.Text, String.Format("Product {0} missing name.", productId));
            Console.Out.WriteLine(String.Format("Found product name {0} for product {1}", productName.Text, productId));

            IWebElement productCondition = detailsPage.GetProductCondition();
            try
            {
                IWebElement condition = productCondition.FindElement(By.ClassName("editable"));
                Assert.IsNotEmpty(condition.Text, String.Format("Product {0} missing condition.", productId));
                Console.Out.WriteLine(String.Format("Found product condition {0} for product {1}", condition.Text, productId));
            }
            catch (NotFoundException e)
            {
                Assert.Fail(String.Format("Condition missing for product {0}", productId));
            }

            IWebElement productDescription = detailsPage.GetProductDescription();
            Assert.IsNotEmpty(productDescription.Text, String.Format("Product {0} missing description.", productId));
            Console.Out.WriteLine(String.Format("Found product description {0} for product {1}", productDescription.Text, productId));
        }
    }
}
