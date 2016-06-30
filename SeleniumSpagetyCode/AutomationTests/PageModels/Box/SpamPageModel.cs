using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels
{
    public class SpamPageModel : PageModel
    {
        [FindsBy(How = How.XPath, Using = "//div[@gh='mtb']/div/div/div/div/div[1]/span[@role='checkbox']/div[@role='presentation']")]
        public IWebElement SelectAllCheckbox { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@act='18']")]
        public IWebElement NotSpamButton { get; set; }
    }
}