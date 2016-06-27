using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels
{
    class BoxPageModel : PageModel
    {
        [FindsBy(How = How.XPath, Using = "//div[@role='button'][@gh='cm']")]
        public IWebElement ComposeButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[starts-with(@title,'Google Account:')]/span")]
        public IWebElement RoundWithYourLetter { get; set; }
        [FindsBy(How = How.XPath, Using = "//td/div[@role='checkbox']/div")]
        public IWebElement CheckFirstEmail { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[starts-with(@tooltip, 'Report spam')]/div/div")]
        public IWebElement ReportSpamButtom { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@role='navigation']/div/div/span[@role='button'][@gh='mll']/span")]
        public IWebElement More { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[starts-with(@title,'Spam')]")]
        public IWebElement Spam { get; set; }
        //for mazila "//div[3]/div[1]/div[2]/div[2]/div[@data-tooltip='Settings']/div[1]"
        [FindsBy(How = How.XPath, Using = "//div[1]/div[1]/div[2]/div[2]/div[@data-tooltip='Settings']/div[1]")] 
        public IWebElement Settings { get; set; }
    }
}
