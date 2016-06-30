using System.Linq;
using System.Threading;
using OpenQA.Selenium;

namespace AutomationTests.Helpers
{
    public static class FiltersHelper
    {
        public const string DeleteXpath = "//tr/td[3]/span[2][@idlink]";

        public static void DeletFilters(IWebDriver driver)
        {
            while (driver.FindElements(By.XPath(DeleteXpath)).Any())
            {
                Thread.Sleep(3000);
                driver.FindElement(By.XPath(DeleteXpath)).Click();
                driver.FindElement(By.XPath(ForwardingHelper.OkXpath)).Click();
                driver.Navigate().Refresh();
                CommonHelper.AcceptPopap();
            }
        }
    }
}