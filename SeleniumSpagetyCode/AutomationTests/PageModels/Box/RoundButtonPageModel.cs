using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels
{
    public class RoundButtonPageModel:PageModel
    {
        [FindsBy(How = How.XPath, Using = "/html/body/div[7]/div[3]/div/div[1]/div[4]/div[1]/div[1]/div[1]/div[2]/div[4]/div[2]/div[3]/div[2]/a")]
        public IWebElement SignOutButton { get; set; }
    }
}