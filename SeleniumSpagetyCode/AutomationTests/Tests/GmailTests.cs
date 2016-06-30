using System;
using System.Linq;
using System.Threading;
using AutomationTests.Constants;
using AutomationTests.Extentions;
using AutomationTests.Helpers;
using AutomationTests.Models;
using AutomationTests.PageModels;
using AutomationTests.PageModels.Settings;
using AutomationTests.PageRouters;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AutomationTests.Tests
{
    public class GmailTests : BaseTest
    {
        private LogonRouter _logonRouter;
        private BoxRouter _boxRouter;
        private BoxPageModel _boxPageModel;
        private ComposePageModel _composePageModel;
        private ThemesPageModel _themesPageModel;
        private User _user1;
        private User _user2;
        private User _user3;
        private Letter _letter;

        [TestFixtureSetUp]
        public override void FixtureSetup()
        {
            base.FixtureSetup();

            _logonRouter = new LogonRouter();
            _boxRouter = new BoxRouter();
            _composePageModel = new ComposePageModel();
            _boxPageModel = new BoxPageModel();
            _themesPageModel = new ThemesPageModel();
            _user1 = new User() { Address = AutomationTestsConstants.UserName1, Password = AutomationTestsConstants.Password };
            _user2 = new User() { Address = AutomationTestsConstants.UserName2, Password = AutomationTestsConstants.Password };
            _user3 = new User() { Address = AutomationTestsConstants.UserName3, Password = AutomationTestsConstants.Password };
            _letter = new Letter()
            {
                To = _user2.Address,
                Subject = AutomationTestsConstants.Subject,
                MessageBody = String.Format(AutomationTestsConstants.MessageText, _user2.Address)
            };

            CommonHelper.NavigateGmail();
        }
        
        [Test]
        public void SendingMessage_Test()
        {
            _logonRouter.LogOn(_user1);
            _boxRouter.Send(_user2, _letter);
            _boxRouter.SwitchAccountTo(_user2);
            _boxRouter.MarkAsSpamFirstMessage();
            _boxRouter.NavigateToSpamFolder();
            var actualName = _boxRouter.GetFirstMessageSenderName();
            Assert.AreEqual(AutomationTestsConstants.SenderName,actualName);
        }

        [Test]
        public void Forward_Test()
        {
            _logonRouter.LogOn(_user2);
            _boxRouter.AddForwardAddress(AutomationTestsConstants.UserName3);
            _boxRouter.SwitchAccountTo(_user3);
            _boxRouter.AcceptForwarding();
            _boxRouter.SwitchAccountTo(_user2);
            _boxRouter.AddFilter(AutomationTestsConstants.UserName1);
            _boxRouter.SwitchAccountTo(_user1);
            _boxRouter.Send(_user2, _letter);
            _boxRouter.SwitchAccountTo(_user2);
            Assert.IsTrue(_boxRouter.MessageIsInTrash(AutomationTestsConstants.SenderName));
            _boxRouter.Logout();
        }

        [Test]
        public void MailWithAttachment_Test()
        {
            _boxRouter.NavigateSettings();
        }

        [Test]
        public void Themes_Test()
        {
            _logonRouter.LogOn(_user1);
            Driver.WaitForAjax();
            _boxRouter.NavigateSettings();
            _themesPageModel.BeachImage.Click();
        }

        [Test]
        public void SendMailWithAttachment_Test()
        {
            _logonRouter.LogOn(_user1);
            _boxPageModel.ComposeButton.Click();
            _composePageModel.To.SendKeys(AutomationTestsConstants.UserName1);
            Actions actions = new Actions(Driver);
            actions.MoveToElement(_composePageModel.AddAttachmentButton, 1, 1).Perform();
        }

        [Test]
        public void CreateShortcut_Test()
        {

        }

        [Test]
        public void ChengeShortcut_Test()
        {

        }

        [Test]
        public void DeleteShortcut_Test()
        {

        }

        [Test]
        public void MarkAsNotSpam_Test()
        {

        }

        [Test]
        public void ChengingSignature_Test()
        {

        }

        [Test]
        public void CheckStarSellection_Test()
        {

        }

        [Test]
        public void CheckVacation_Test()
        {

        }
    }
}