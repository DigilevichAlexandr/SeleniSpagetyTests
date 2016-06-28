using System;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Threading;
using AutomationTests.Constants;
using AutomationTests.Extentions;
using AutomationTests.PageModels;
using AutomationTests.PageModels.Settings;
using OpenQA.Selenium;

namespace AutomationTests.PageRouters
{
    public class BoxRouter
    {
        private IWebDriver _driver;



        private LogOnPageModel _logonPageModel;
        private BoxPageModel _boxPageModel;
        private ComposePageModel _composePageModel;
        private RoundButtonPageModel _roundButtonPageModel;
        private InboxPageModel _inboxPageModel;
        private SettingsDropdownPageModel _settingsDropdownPageModel;
        private SettingsPageModel _settingsPageModel;

        public BoxRouter()
        {
            _driver = PropertiesCollection.Driver;
            _boxPageModel = new BoxPageModel();
            _logonPageModel = new LogOnPageModel();
            _roundButtonPageModel = new RoundButtonPageModel();
            _settingsPageModel = new SettingsPageModel();
            _settingsDropdownPageModel = new SettingsDropdownPageModel();
            _composePageModel = new ComposePageModel();
            _inboxPageModel = new InboxPageModel();
        }

        public void Logout()
        {
            _boxPageModel.RoundWithYourLetter.Click();
            _roundButtonPageModel.SignOutButton.Click();
            _logonPageModel.ChoseAnotherAccount.Click();
        }

        public void Forwarding()
        {
            _boxPageModel.Settings.Click();
            _settingsDropdownPageModel.SettingsOption.Click();
            _driver.WaitForAjax();
            _driver.Navigate().GoToUrl(AutomationTestsConstants.ForvardingTab);
            ////_settingsPageModel.Forwarding.Click();
        }

        public void Send(string to, string subject, string message, string attachment = null)
        {
            _boxPageModel.ComposeButton.Click();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            _composePageModel.To.SendKeys(to);
            _composePageModel.Subject.SendKeys(subject);
            _composePageModel.MessageBody.SendKeys(message);
            if (string.IsNullOrEmpty(attachment))
            {
                // TO DO
            }

            _composePageModel.SendButton.Click();
            Thread.Sleep(5000);
        }

        public bool MessageIsInTrash(string name)
        {
            _driver.Navigate().GoToUrl("https://mail.google.com/mail/u/0/#trash");
            return
                _driver.FindElements(
                    By.XPath(
                        "//td[text()='No conversations in the Trash. Who needs to delete when you have so much storage?!']"))
                    .Count == 0
                && name.Equals(_inboxPageModel.FirstEmailRowElement.FindElement(By.XPath(AutomationTestsConstants.ItemName)).Text);
        }

        public bool MessageIsInInbox(string name)
        {
            _driver.Navigate().GoToUrl("https://mail.google.com/mail/u/0/#inbox");
            return
                _driver.FindElements(
                    By.XPath(
                        "//td[text()='Your Primary tab is empty.']"))
                    .Count == 0
                && name.Equals(_inboxPageModel.FirstEmailRowElement.FindElement(By.XPath(AutomationTestsConstants.ItemName)).Text);
        }

        public bool MessageMarkedUsImportant()
        {
            // TO DO
            return true; 
        }

        public void NavigateSettings()
        {
            _boxPageModel.Settings.Click();
            _settingsDropdownPageModel.SettingsOption.Click();
        }
    }
}