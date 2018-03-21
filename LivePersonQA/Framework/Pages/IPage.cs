using System;

namespace LivePersonQA.Framework.Pages
{
    /// <summary>
    /// Interface to expose needed methods to WebDriver class for page navigation
    /// </summary>
    interface IPage
    {
        String GetUrl();

        IPage NavigateToPage(IPage page);

        IPage NavigateToPage(IPage page, String pageCode);
    }
}
