using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels.Shortcuts
{
    public class AddLabelPageModel : PageModel
    {
        [FindsBy(How = How.XPath, Using = "//div[@role='alertdialog']/div[2]/input")]
        public IWebElement LabelNameInput { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@role='alertdialog']/div[2]/div[2]/input")]
        public IWebElement NestUnderCheck { get; set; }
        [FindsBy(How = How.XPath, Using = "//div[@role='alertdialog']/div[2]/select")]
        public IWebElement NestUnderSelect { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@name='ok']")]
        public IWebElement ButtonOk { get; set; }
    }
}