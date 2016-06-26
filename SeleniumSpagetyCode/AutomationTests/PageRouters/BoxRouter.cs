using System;
using System.Net.Mail;
using System.Threading;
using AutomationTests.Constants;
using AutomationTests.Extentions;
using AutomationTests.PageModels;
using OpenQA.Selenium;

namespace AutomationTests.PageRouters
{
    public class BoxRouter
    {
        private IWebDriver _driver;

        private BoxPageModel _boxPageModel;
        private LogOnPageModel _logonPageModel;

        public BoxRouter()
        {
            _driver = PropertiesCollection.Driver;
            _boxPageModel = new BoxPageModel();
            _logonPageModel = new LogOnPageModel();
        }

        public void Logout()
        {
            _boxPageModel.RoundWithYourLetter.Click();
            _boxPageModel.SignOutButton.Click();
            _logonPageModel.ChoseAnotherAccount.Click();
        }

        public void Forwarding()
        {
            _boxPageModel.Settings.Click();
            _boxPageModel.SettingsOption.Click();
            _driver.WaitForAjax();
            _boxPageModel.Forwarding.Click();
        }

        public void Send(string to, string subject, string message, string attachment = null)
        {
            _boxPageModel.ComposeButton.Click();
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            _boxPageModel.To.SendKeys(to);
            _boxPageModel.Subject.SendKeys(subject);
            _boxPageModel.MessageBody.SendKeys(message);
            if (string.IsNullOrEmpty(attachment))
            {
                // TO DO
            }

            _boxPageModel.SendButton.Click();
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
                && name.Equals(_boxPageModel.FirstMessageSender.Text);
        }

        public bool MessageIsInInbox(string name)
        {
            _driver.Navigate().GoToUrl("https://mail.google.com/mail/u/0/#inbox");
            return
                _driver.FindElements(
                    By.XPath(
                        "//td[text()='Your Primary tab is empty.']"))
                    .Count == 0
                && name.Equals(_boxPageModel.InboxFirstMessageSender.Text);
        }

        public bool MessageMarkedUsImportant()
        {
            // TO DO
            return true; 
        }

        public void NavigateSettings()
        {
            _boxPageModel.Settings.Click();
            _boxPageModel.SettingsOption.Click();
        }
    }
}