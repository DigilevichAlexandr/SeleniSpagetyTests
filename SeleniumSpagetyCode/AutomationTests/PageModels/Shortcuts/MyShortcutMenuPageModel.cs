using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels.Shortcuts
{
    public class MyShortcutMenuPageModel : PageModel
    {
        [FindsBy(How = How.XPath, Using = "//div[@role='menu']/div[@role='menuitem']/div/span[1]")]
        public IWebElement ChangeColor { get; set; }

        [FindsBy(How = How.XPath, Using = "//div[@role='menu']/div[13][@role='menuitem']")]
        public IWebElement Delete { get; set; }
    }
}