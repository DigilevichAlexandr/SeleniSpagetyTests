using System;
using System.Linq;
using System.Threading;
using AutomationTests.Constants;
using AutomationTests.Extentions;
using AutomationTests.Helpers;
using AutomationTests.PageModels;
using AutomationTests.PageRouters;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTests.Tests
{
    public class GmailTests : BaseTest
    {
        private LogonRouter _logonRouter;
        private BoxRouter _boxRouter;

        private LogOnPageModel _logonPageModel;
        private BoxPageModel _boxPageModel;

        [TestFixtureSetUp]
        public override void FixtureSetup()
        {
            base.FixtureSetup();

            _logonRouter = new LogonRouter();
            _boxRouter = new BoxRouter();

            _logonPageModel = new LogOnPageModel();
            _boxPageModel = new BoxPageModel();
            CommonHelper.NavigateGmail();
        }

        [Test]
        public void SendingMessage_Test()
        {
            _logonRouter.LogOn(AutomationTestsConstants.UserName1, AutomationTestsConstants.Password);
            _boxRouter.Send(AutomationTestsConstants.UserName2, "test", "Hello user2");
            _boxRouter.Logout();
            _logonPageModel.AddAnotherAccount.Click();
            _logonRouter.LogOn(AutomationTestsConstants.UserName2, AutomationTestsConstants.Password);
            ////_boxPageModelpageModel.CheckFirstEmail.Click();
            ////_boxPageModelpageModel.ReportSpamButtom.Click();
            _boxPageModel.More.Click();
            Driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            _boxPageModel.Spam.Click();
            var actualName = _boxPageModel.FirstEmailSender.Text;
            var actualTime = _boxPageModel.FirstEmailDateTime.Text;
            var name = "jason todd";
            Assert.AreEqual(actualName, name);
        }

        [Test]
        public void Forvard_Test()
        {
            _logonRouter.LogOn(AutomationTestsConstants.UserName2, AutomationTestsConstants.Password);
            _boxRouter.Forwarding();
            _boxPageModel.AddForwardingAddress.Click();
            _boxPageModel.ForwardingAddressInput.SendKeys(AutomationTestsConstants.UserName3);
            _boxPageModel.ForwardingNextButton.Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.ToList().Last());
            _boxPageModel.ProceedButton.Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.ToList().First());
            _boxPageModel.ForwardingOkButton.Click();
            _boxRouter.Logout();
            _logonRouter.LogOn(AutomationTestsConstants.UserName3, AutomationTestsConstants.Password);
            _boxPageModel.FirstEmailDiscription.Click();
            Driver.WaitForAjax();
            Driver.SwitchTo().Window(Driver.WindowHandles.ToList().Last());
            _boxPageModel.ForwardingConfirmButton.Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.ToList().First());
            _boxRouter.Logout();
            _logonRouter.LogOn(AutomationTestsConstants.UserName2, AutomationTestsConstants.Password);
            _boxRouter.Forwarding();
            _boxPageModel.ForwardingSaveChangesButton.Click();
            _boxPageModel.FiltersTab.Click();
            _boxPageModel.CreateFilterButton.Click();
            _boxPageModel.FromInput.SendKeys(AutomationTestsConstants.UserName1);
            _boxPageModel.HasAttachmentOption.Click();
            _boxPageModel.CreateThisSearchFilter.Click();
            _boxPageModel.FilterCreateOkButton.Click();
            _boxPageModel.DeleteItCheck.Click();
            _boxPageModel.MarkimportantCheck.Click();
            _boxPageModel.CreateFilterPopupButton.Click();
            _boxRouter.Logout();
            _logonRouter.LogOn(AutomationTestsConstants.UserName1, AutomationTestsConstants.Password);
            _boxRouter.Send(AutomationTestsConstants.UserName2, "whith attachment", "Hello user2", "attachment.txt");// not finished
            _boxRouter.Send(AutomationTestsConstants.UserName2, "whith out attachment", "Hello user2");
            _boxRouter.Logout();
            _logonRouter.LogOn(AutomationTestsConstants.UserName2, AutomationTestsConstants.Password);
            Assert.IsTrue(_boxRouter.MessageIsInTrash("jason todd"));
            Assert.IsTrue(_boxRouter.MessageIsInInbox("jason todd") && _boxRouter.MessageMarkedUsImportant()); // not finished
            _boxRouter.Logout();
            _logonRouter.LogOn(AutomationTestsConstants.UserName3, AutomationTestsConstants.Password);
            Assert.IsTrue(_boxRouter.MessageIsInInbox("jason todd"));
        }

        [Test]
        public void MailWithBoxPage_Test()
        {
            _logonRouter.LogOn(AutomationTestsConstants.UserName1, AutomationTestsConstants.Password);
            _boxRouter.Send(AutomationTestsConstants.UserName2, "whith attachment", "Hello user2", "big_attachment.txt"); // not finished

        }

        [Test]
        public void MailWithAttachment_Test()
        {
            _boxRouter.NavigateSettings();
        }

        [Test]
        public void Themes_Test()
        {
            _logonRouter.LogOn(AutomationTestsConstants.UserName1, AutomationTestsConstants.Password);
            Driver.WaitForAjax();
            _boxRouter.NavigateSettings();
            _boxPageModel.SetThemLink.Click();
            _boxPageModel.BeachImage.Click();
        }

        [Test]
        public void SendMailWithAttachment_Test()
        {

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