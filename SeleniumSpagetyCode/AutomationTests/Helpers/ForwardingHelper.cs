using System.Linq;
using AutomationTests.Constants;
using AutomationTests.Extentions;
using NUnit.Framework;
using OpenQA.Selenium;

namespace AutomationTests.Helpers
{
    public static class ForwardingHelper
    {
        public const string RemoveXpath = "//span[@act='removeAddr']";
        public const string OkXpath = "//button[@name='ok']";

        public static void DeletAddreses(IWebDriver driver)
        {
            while (driver.FindElements(By.XPath("//tbody/tr[1]/td[2]/span/select[1]/option[2]")).Any())
            {
                var mails = driver.FindElement(By.XPath("//tbody/tr[1]/td[2]/span/select[1]"));
                mails.Click();
                mails.SendKeys(Keys.ArrowDown + Keys.ArrowDown + Keys.Enter);
                driver.FindElement(By.XPath(OkXpath)).Click();
                driver.Navigate().Refresh();
                CommonHelper.AcceptPopap();
            }

            while (driver.FindElements(By.XPath(RemoveXpath)).Any())
            {
                driver.FindElement(By.XPath(RemoveXpath)).Click();
                driver.FindElement(By.XPath(OkXpath)).Click();
                driver.Navigate().Refresh();
                CommonHelper.AcceptPopap();
            }
        }
    }
}