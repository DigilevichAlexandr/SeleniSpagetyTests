using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels
{
    public class ThemesPageModel:PageModel
    {
        [FindsBy(How = How.CssSelector, Using = "//div/div[11][@role='option']/img")]
        public IWebElement BeachImage { get; set; }
    }
}