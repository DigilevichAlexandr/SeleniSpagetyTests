using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels
{
    public class InboxPageModel : PageModel
    {
        [FindsBy(How = How.XPath, Using = "//a[starts-with(@href,'https://mail.google.com/mail/u/0/#inbox')]")]
        public IWebElement Inbox { get; set; }
        [FindsBy(How = How.XPath, Using = "div[@role='tabpanel'][@aria-labelledby=':37']/div[2]/div/table/tbody/tr[1]")]
        public IWebElement FirstEmailRowElement { get; set; }
    }
}