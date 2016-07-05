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
        [FindsBy(How = How.XPath, Using = "//div[starts-with(@data-tooltip, 'Report spam')]")]
        public IWebElement ReportSpamButtom { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@role='navigation']/div/div/span[@role='button'][@gh='mll']/span")]
        public IWebElement More { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[starts-with(@title,'Spam')]")]
        public IWebElement Spam { get; set; }
        //for mazila "//div[3]/div[1]/div[2]/div[2]/div[@data-tooltip='Settings']/div[1]"
        [FindsBy(How = How.XPath, Using = "//div[@gh='s']/div[@data-tooltip='Settings']/div[1]")] 
        public IWebElement Settings { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[1][@title='Not starred']")]
        public IWebElement Star { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@target='_top']/../../../div[3]/div/div/span[1]")]
        public IWebElement VacationDateOnTop { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@title='My shortcut']/../../../div[3]")]
        public IWebElement MyShortcutRightTriangle { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[starts-with(@title, 'My inserted shortcut')]/../../../div[3]")]
        public IWebElement MyNestedShortcutRightTriangle { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@title='My inserted shortcut']/../../../..")]
        public IWebElement MyNestedShortcut { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[14][@role='menuitem']/div")]
        public IWebElement AddSublabel { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@title='Collapse label: My shortcut']")]
        public IWebElement MyShortcutLeftTriangle { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[@title='My inserted shortcut']")]
        public IWebElement NestedLabel { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[starts-with(@style,'opacity: 1')]")]
        public IWebElement Background { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@style='display: none;']/div[@data-tooltip='Delete']")]
        public IWebElement DeleteMessageButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@name='ok']")]
        public IWebElement ButtonOk { get; set; }

    }
}
