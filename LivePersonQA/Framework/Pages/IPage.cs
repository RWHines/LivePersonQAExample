using LivePersonQA.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LivePersonQA.Framework.Pages
{
    interface IPage
    {
        String GetUrl();

        IPage NavigateToPage(IPage page);

        IPage NavigateToPage(IPage page, String pageCode);
    }
}
