using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels
{
    public class InboxPageModel : PageModel
    {
        [FindsBy(How = How.XPath, Using = "//a[starts-with(@href,'https://mail.google.com/mail/u/0/#inbox')]")]
        public IWebElement Inbox { get; set; }
        [FindsBy(How = How.XPath, Using = "//span[@email]")]
        public IWebElement FirstEmailRowElement { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[1]/div/table/tbody/tr[1]/td[4]/div[2]/span")]
        public IWebElement FirstEmailRowElementInSpam { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[1]/div/table/colgroup/../tbody/tr[1]")]
        public IWebElement FirstEmailRow { get; set; }
    }
}