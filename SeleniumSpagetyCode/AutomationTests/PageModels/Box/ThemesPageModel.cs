using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels
{
    public class ThemesPageModel:PageModel
    {
        [FindsBy(How = How.XPath, Using = "//div/div[3][@role='option']")]
        public IWebElement BeachImage { get; set; }
    }
}