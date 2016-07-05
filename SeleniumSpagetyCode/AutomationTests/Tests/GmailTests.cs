using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
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
        private SettingsRouter _settingsRouter;
        private MyShortcutMenuRouter _myShortcutMenuRouter;
        private User _user1;
        private User _user2;
        private User _user3;
        private Letter _letter1;
        private Letter _letter2;

        [TestFixtureSetUp]
        public override void FixtureSetup()
        {
            base.FixtureSetup();

            _logonRouter = new LogonRouter();
            _boxRouter = new BoxRouter();
            _composePageModel = new ComposePageModel();
            _boxPageModel = new BoxPageModel();
            _themesPageModel = new ThemesPageModel();
            _settingsRouter = new SettingsRouter();
            _myShortcutMenuRouter = new MyShortcutMenuRouter();
            _user1 = new User() { Address = AutomationTestsConstants.UserName1, Password = AutomationTestsConstants.Password };
            _user2 = new User() { Address = AutomationTestsConstants.UserName2, Password = AutomationTestsConstants.Password };
            _user3 = new User() { Address = AutomationTestsConstants.UserName3, Password = AutomationTestsConstants.Password };
            _letter1 = new Letter()
            {
                To = _user1.Address,
                Subject = AutomationTestsConstants.Subject,
                MessageBody = String.Format(AutomationTestsConstants.MessageText, _user1.Address)
            };
            _letter2 = new Letter()
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
            _boxRouter.Send(_letter2);

            _boxRouter.SwitchAccountTo(_user2);
            _boxRouter.MarkFirstMessageAsSpam();
            _boxRouter.NavigateToSpamFolder();

            var actualName = _boxRouter.GetFirstMessageSenderNameFromSpam();
            Assert.AreEqual(AutomationTestsConstants.SenderName, actualName);
            _boxRouter.ClearSpam();
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
            _boxRouter.Send(_letter2);

            _boxRouter.SwitchAccountTo(_user2);
            Assert.IsTrue(_boxRouter.MessageIsInTrash(AutomationTestsConstants.SenderName));
            _boxRouter.Logout();
        }

        //[Test]
        //public void MailWithAttachment_BigFile_Test()
        //{
        //    _logonRouter.LogOn(_user1);
        //    CommonHelper.GenerateFile(AutomationTestsConstants.TestFilesName, 25);
        //    _boxRouter.Send(_letter1, AutomationTestsConstants.TestFilesName);

        //}

        [Test]
        public void Themes_Test()
        {
            _logonRouter.LogOn(_user1);
            var imgBefore = _boxPageModel.Background.GetAttribute("style");
            _boxRouter.NavigateToPickImage();
            _themesPageModel.BeachImage.Click();
            Thread.Sleep(2000);
            var imgAfter = _boxPageModel.Background.GetAttribute("style");
            Assert.False(imgBefore.Equals(imgAfter));
        }

        [Test]
        public void SendMailWithAttachment_Test()
        {
            _logonRouter.LogOn(_user1);
            CommonHelper.GenerateFile(AutomationTestsConstants.TestFilesName, 1);
            _boxRouter.Send(_letter2,AutomationTestsConstants.TestFilesName);
            _boxRouter.NavigateToSent();
            Assert.True(_boxRouter.EmailWhithAttachmentExists());
            _boxRouter.DeleteFirstMessage();
        }

        [Test]
        public void CreateShortcut_Test()
        {
            _logonRouter.LogOn(_user1);
            _myShortcutMenuRouter.AddSubLabel(AutomationTestsConstants.NestedLabelName);
            Assert.True(_boxRouter.IsNestedLabelEsxists());
            _myShortcutMenuRouter.DeleteNested();
        }

        [Test]
        public void EditShortcut_Test()
        {
            _logonRouter.LogOn(_user1);
            _myShortcutMenuRouter.ChangeColor((int)AutomationTestsConstants.LabelColors.Red);
            _myShortcutMenuRouter.AddMultipleLabels(3, AutomationTestsConstants.NestedLabelName);
            _myShortcutMenuRouter.ChangeSubtitlesColor((int) AutomationTestsConstants.LabelColors.Green);
            Assert.True(_myShortcutMenuRouter.IsLabelColorsCommon());
            for (int i = 0; i < 3; i++)
            {
                _myShortcutMenuRouter.DeleteNested();
            }
        }

        [Test]
        public void DeleteShortcut_Test()
        {
            _logonRouter.LogOn(_user1);
            _myShortcutMenuRouter.AddLabel(AutomationTestsConstants.LabelName);
            _myShortcutMenuRouter.AddSubLabel(AutomationTestsConstants.NestedLabelName);
            Assert.True(_myShortcutMenuRouter.IsLabelExists(AutomationTestsConstants.LabelName));
            Assert.True(_myShortcutMenuRouter.IsLabelExists(AutomationTestsConstants.NestedLabelName));
            _myShortcutMenuRouter.DeleteLabel(AutomationTestsConstants.LabelName);
            _myShortcutMenuRouter.DeleteLabel(AutomationTestsConstants.LabelName);
            Assert.False(_myShortcutMenuRouter.IsLabelExists(AutomationTestsConstants.LabelName));
            Assert.False(_myShortcutMenuRouter.IsLabelExists(AutomationTestsConstants.NestedLabelName));
        }

        [Test]
        public void ChangingSignature_Test()
        {
            _logonRouter.LogOn(_user1);
            _boxRouter.NavigateSettings();
            _settingsRouter.SetSignature(AutomationTestsConstants.SignatureText);
            _boxPageModel.ComposeButton.Click();
            var act = _composePageModel.Signature.Text;
            Assert.True(AutomationTestsConstants.SignatureText.Equals(act));
        }

        [Test]
        public void CheckStarSellection_Test()
        {
            _logonRouter.LogOn(_user1);
            _boxPageModel.Star.Click();
            var inbox = _boxRouter.GetFirstMessageSenderName();
            Driver.Navigate().GoToUrl(AutomationTestsConstants.StarredUrl);
            var starred = _boxRouter.GetFirstMessageSenderName();
            Assert.True(inbox.Equals(starred));
        }

        [Test]
        public void CheckVacation_Test()
        {
            _logonRouter.LogOn(_user1);
            _boxRouter.NavigateSettings();
            _settingsRouter.SetVacation(AutomationTestsConstants.VacationDate, AutomationTestsConstants.VacationDate);
            var act = _boxRouter.GetVacationDateFromTop();

            Assert.True(AutomationTestsConstants.VacationDate.Equals(act));
        }

        [TearDown]
        public void TearDown()
        {
            _boxRouter.Logout();
        }
    }
}