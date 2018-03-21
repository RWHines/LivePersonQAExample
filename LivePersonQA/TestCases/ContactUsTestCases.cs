using LivePersonQA.Framework.Pages;
using NUnit.Framework;

namespace LivePersonQA.TestCases
{
    class ContactUsTestCases : TestCaseBase
    {
        //Validate field requirements for Test 4
        [Test]
        public void SubmitContactMessage()
        {
            ContactUs contactUsPage = (ContactUs)Driver.NavigateToPage(typeof(ContactUs));

            contactUsPage.ClickSend();
            contactUsPage.GetFailMessage();

            contactUsPage.ChooseHeading("Customer service");
            contactUsPage.ClickSend();
            contactUsPage.GetFailMessage();

            contactUsPage.EnterEmail("test@test.com");
            contactUsPage.ClickSend();
            contactUsPage.GetFailMessage();

            contactUsPage.EnterMessage("test message");
            contactUsPage.ClickSend();
            contactUsPage.GetSuccessMessage();
        }
    }
}
