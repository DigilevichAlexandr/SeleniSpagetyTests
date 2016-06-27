using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels
{
    public class SettingsPageModel:PageModel
    {
        [FindsBy(How = How.XPath, Using = "//a[starts-with(@href,'https://mail.google.com/mail/u/1/#settings/fwdandpop')]")]
        public IWebElement Forwarding { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[starts-with(@href,'https://mail.google.com/mail/#settings/filters')]")]
        public IWebElement FiltersTab { get; set; }
    }
}