using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels.Settings
{
    public class FiltersPageModel
    {
        [FindsBy(How = How.XPath, Using = "//table[@role='list']/tbody/tr[9]/td/span[1]")]
        public IWebElement CreateFilterButton { get; set; }

        [FindsBy(How = How.XPath, Using = "//div/div[2]/span[2]/input[@role='combobox']")]
        public IWebElement FromInput { get; set; }
        [FindsBy(How = How.XPath, Using = "//div/div[7]/span/input[@type='checkbox']")]
        public IWebElement HasAttachmentOption { get; set; }
        [FindsBy(How = How.XPath, Using = "//div/div[9]/div[2][@role='link']")]
        public IWebElement CreateThisSearchFilter { get; set; }
        [FindsBy(How = How.XPath, Using = "//button[@name='ok']")]
        public IWebElement FilterCreateOkButton { get; set; }
        [FindsBy(How = How.XPath, Using = "//div/div[6]/input[@type='checkbox']")]
        public IWebElement DeleteItCheck { get; set; }
        [FindsBy(How = How.XPath, Using = "//div/div[9]/input[@type='checkbox']")]
        public IWebElement MarkimportantCheck { get; set; }
        [FindsBy(How = How.XPath, Using = "//div/div[2]/div[5]/div[@role='button']")]
        public IWebElement CreateFilterPopupButton { get; set; }
    }
}