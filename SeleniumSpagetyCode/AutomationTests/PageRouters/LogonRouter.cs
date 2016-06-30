using System;
using AutomationTests.Extentions;
using AutomationTests.Models;
using AutomationTests.PageModels;
using OpenQA.Selenium;

namespace AutomationTests.PageRouters
{
    public class LogonRouter
    {
        private IWebDriver _driver;

        private LogOnPageModel _logonPageModel;

        public LogonRouter()
        {
            _driver = PropertiesCollection.Driver;
            _logonPageModel = new LogOnPageModel();
        }

        public void LogOn(User user)
        {
            _logonPageModel.Email.SendKeys(user.Address);
            _logonPageModel.Next.Click();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            _logonPageModel.Password.SendKeys(user.Password);
            _logonPageModel.SignIn.Click();
            _driver.WaitForAjax();
        }
    }
}