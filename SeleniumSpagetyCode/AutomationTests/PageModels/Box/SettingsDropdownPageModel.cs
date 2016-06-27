using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels
{
    public class SettingsDropdownPageModel : PageModel
    {
        [FindsBy(How = How.XPath, Using = "//div[@role='menu']/div/div[8]/div")]
        public IWebElement SettingsOption { get; set; }
        [FindsBy(How = How.CssSelector, Using = "//div[@role='menu']/div/div[9]/div")]
        public IWebElement ThemesTab { get; set; }
    }
}