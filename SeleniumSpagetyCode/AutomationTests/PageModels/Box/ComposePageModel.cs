using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels
{
    public class ComposePageModel : PageModel
    {
        [FindsBy(How = How.XPath, Using = "")]
        public IWebElement To { get; set; }
        [FindsBy(How = How.XPath, Using = "//input[@name='subjectbox']")]
        public IWebElement Subject { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@role='textbox']")]
        public IWebElement MessageBody { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[text()='Send']")]
        public IWebElement SendButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@data-tooltip='Attach files']/div/div/div")]
        public IWebElement AddAttachmentButton { get; set; }
    }
}