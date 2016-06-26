﻿using System;
using AutomationTests.Extentions;
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

        public void LogOn(string email, string password)
        {
            _logonPageModel.Email.SendKeys(email);
            _logonPageModel.Next.Click();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            _logonPageModel.Password.SendKeys(password);
            _logonPageModel.SignIn.Click();
            _driver.WaitForAjax();
        }


    }
}