using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels
{
    public class SettingsPageModel:PageModel
    {
        [FindsBy(How = How.XPath, Using = "//a[starts-with(@href,'https://mail.google.com/mail/#settings/fwdandpop')]")]
        public IWebElement Forwarding { get; set; }
        [FindsBy(How = How.XPath, Using = "//a[starts-with(@href,'https://mail.google.com/mail/#settings/filters')]")]
        public IWebElement FiltersTab { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@aria-label='Signature']")]
        public IWebElement Signature { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@guidedhelpid='save_changes_button']/..")]
        public IWebElement SaveChangesButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//tr[22]/td[2]/table/tbody/tr[2]/td[1]/input")]
        public IWebElement VacationOnOption { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@aria-label='Subject']")]
        public IWebElement VacationSubjectInput { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@aria-label='Vacation responder']")]
        public IWebElement VacationTextInput { get; set; }
    }
}