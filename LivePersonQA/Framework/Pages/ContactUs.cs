using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePersonQA.Framework.Pages
{
    class ContactUs : Header<ContactUs>
    {
        const String _headingId = "id_contact";
        [FindsBy(How = How.Id, Using = _headingId)]
        IWebElement HeadingDropDown;

        const String _emailId = "email";
        [FindsBy(How = How.Id, Using = _emailId)]
        IWebElement EmailTextBox;

        const String _orderId = "id_order";
        [FindsBy(How = How.Id, Using = _orderId)]
        IWebElement OrderTextBox;

        const String _messageId = "message";
        [FindsBy(How = How.Id, Using = _messageId)]
        IWebElement MessageTextBox;

        const String _submitId = "submitMessage";
        [FindsBy(How = How.Id, Using = _submitId)]
        IWebElement SubmitButton;

        public ContactUs(WebDriver WebDriver) : base(WebDriver)
        {
            WaitForElements.Add(By.Id(_emailId));
            WaitForElements.Add(By.Id(_orderId));
            WaitForElements.Add(By.Id(_messageId));
            WaitForElements.Add(By.Id(_submitId));
        }

        public override string GetUrl()
        {
            return "http://automationpractice.com/index.php?controller=contact";
        }

        public override ContactUs NavigateToPage(WebDriver webDriver)
        {
            return (ContactUs)NavigateToPage(this);
        }

        public void ChooseHeading(string selection)
        {
            SelectElement heading = new SelectElement(HeadingDropDown);
            heading.SelectByText(selection);
        }

        public void EnterEmail(string text)
        {
            EmailTextBox.SendKeys(text);
        }

        public void EnterMessage(string text)
        {
            MessageTextBox.SendKeys(text);
        }

        public void ClickSend()
        {
            SubmitButton.Click();
        }

        public IWebElement GetSuccessMessage()
        {
            By successMessagelocator = By.ClassName("alert-success");

            WebDriverWait wait = new WebDriverWait(WebDriver.GetWebDriver(), new TimeSpan(0, 0, 10));
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(successMessagelocator));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new NoSuchElementException("Error locating failure message after timeout.", e);
            }
    
            return WebDriver.GetWebDriver().FindElement(successMessagelocator);
        }

        public IWebElement GetFailMessage()
        {
            By failureMessagelocator = By.ClassName("alert-danger");

            WebDriverWait wait = new WebDriverWait(WebDriver.GetWebDriver(), new TimeSpan(0, 0, 10));
            try
            {
                wait.Until(ExpectedConditions.ElementIsVisible(failureMessagelocator));
            }
            catch (WebDriverTimeoutException e)
            {
                throw new NoSuchElementException("Error locating failure message after timeout.", e);
            }
            



            return WebDriver.GetWebDriver().FindElement(failureMessagelocator);
        }
    }
}
