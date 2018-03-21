using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePersonQA.Framework.Pages
{
    class ProductPage : Header<ProductPage>
    {
        const string _productNameXPath = "//*[@id='center_column']/div/div/div[3]/h1";
        [FindsBy(How = How.XPath, Using = _productNameXPath)]
        IWebElement ProductName;

        const string _productConditionId = "product_condition";
        [FindsBy(How = How.Id, Using = _productConditionId)]
        IWebElement ProductCondition;

        const string _productDescriptionId = "short_description_content";
        [FindsBy(How = How.Id, Using = _productDescriptionId)]
        IWebElement ProductDescription;

        public ProductPage(WebDriver WebDriver) : base(WebDriver)
        {
            WaitForElements.Add(By.XPath(_productNameXPath));
            WaitForElements.Add(By.Id(_productConditionId));
            WaitForElements.Add(By.Id(_productDescriptionId));
        }

        public override string GetUrl()
        {
            return "http://automationpractice.com/index.php?id_product={0}&controller=product";
        }

        public override ProductPage NavigateToPage(WebDriver webDriver)
        {
            return (ProductPage)NavigateToPage(this);
        }

        public new ProductPage NavigateToPage(WebDriver webDriver, string pageCode)
        {
            return (ProductPage)NavigateToPage(this, pageCode);
        }

        public IWebElement GetProductName()
        {
            return ProductName;
        }

        public IWebElement GetProductCondition()
        {
            return ProductCondition;
        }

        public IWebElement GetProductDescription()
        {
            return ProductDescription;
        }
    }
}
