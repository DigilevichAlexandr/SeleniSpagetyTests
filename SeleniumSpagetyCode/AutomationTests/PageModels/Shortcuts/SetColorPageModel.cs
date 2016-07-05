using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels.Shortcuts
{
    public class SetColorPageModel:PageModel
    {
        [FindsBy(How = How.XPath, Using = "//div[@role='alertdialog']/div[2]/div[3]/input")]
        public IWebElement SetSubtitlesColorOption { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@role='alertdialog']/div[3]/button[1]")]
        public IWebElement SetColorButton { get; set; }
    }
}