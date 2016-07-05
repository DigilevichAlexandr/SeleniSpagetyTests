using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels.Settings
{
    public class LabelsPageModels : PageModel
    {
        [FindsBy(How = How.XPath, Using = "//tr[20]/td[@colspan]/div/button")]
        public IWebElement CreateLabelButton { get; set; }
    }
}