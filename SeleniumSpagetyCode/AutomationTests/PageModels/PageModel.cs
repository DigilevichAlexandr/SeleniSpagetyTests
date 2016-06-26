using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels
{
    public class PageModel
    {
        public PageModel()
        {
            PageFactory.InitElements(PropertiesCollection.Driver, this);
        }
    }
}
