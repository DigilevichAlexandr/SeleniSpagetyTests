using AutomationTests.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace AutomationTests.PageRouters
{
    public class SettingsRouter
    {
        private IWebDriver _driver;

        public SettingsRouter()
        {
            _driver = PropertiesCollection.Driver;
        }

        public void NavigateForwarding()
        {
            _driver.Navigate().GoToUrl(AutomationTestsConstants.ForwardingUrl);
        }
    }
}