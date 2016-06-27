using System;
using System.Linq;
using System.Threading;
using AutomationTests.Constants;
using AutomationTests.Extentions;
using AutomationTests.Helpers;
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

        private LogOnPageModel _logonPageModel;
        private BoxPageModel _boxPageModel;
        private ComposePageModel _composePageModel;
        private RoundButtonPageModel _roundButtonPageModel;
        private InboxPageModel _inboxPageModel;
        private ForwardingPageModel _forwardingPageModel;
        private FiltersPageModel _filtersPageModel;
        private SettingsDropdownPageModel _settingsDropdownPageModel;
        private SettingsPageModel _settingsPageModel;
        private ThemesPageModel _themesPageModel;

        [TestFixtureSetUp]
        public override void FixtureSetup()
        {
            base.FixtureSetup();

            _logonRouter = new LogonRouter();
            _boxRouter = new BoxRouter();
            _composePageModel = new ComposePageModel();
            _roundButtonPageModel = new RoundButtonPageModel();
            _logonPageModel = new LogOnPageModel();
            _boxPageModel = new BoxPageModel();
            _inboxPageModel = new InboxPageModel();
            _forwardingPageModel = new ForwardingPageModel();
            _filtersPageModel = new FiltersPageModel();
            _settingsDropdownPageModel = new SettingsDropdownPageModel();
            _settingsPageModel = new SettingsPageModel();
            _themesPageModel = new ThemesPageModel();
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
            var actualName = _inboxPageModel.FirstEmailRowElement.FindElement(By.XPath(AutomationTestsConstants.ItemName)).Text;
            ////var actualTime = _inboxPageModel.FirstEmailRowElement.FindElement(By.XPath("td[8]/span")).Text;
            var name = "jason todd";
            Assert.AreEqual(actualName, name);
        }

        [Test]
        public void Forvard_Test()
        {
            _logonRouter.LogOn(AutomationTestsConstants.UserName2, AutomationTestsConstants.Password);
            _boxRouter.Forwarding();
            _forwardingPageModel.AddForwardingAddress.Click();
            _forwardingPageModel.ForwardingAddressInput.SendKeys(AutomationTestsConstants.UserName3);
            _forwardingPageModel.ForwardingNextButton.Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.ToList().Last());
            _forwardingPageModel.ProceedButton.Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.ToList().First());
            _forwardingPageModel.ForwardingOkButton.Click();
            _boxRouter.Logout();
            _logonRouter.LogOn(AutomationTestsConstants.UserName3, AutomationTestsConstants.Password);
            _inboxPageModel.FirstEmailRowElement.FindElement(By.XPath(AutomationTestsConstants.ItemDiscription)).Click();
            Driver.WaitForAjax();
            Driver.SwitchTo().Window(Driver.WindowHandles.ToList().Last());
            _forwardingPageModel.ForwardingConfirmButton.Click();
            Driver.SwitchTo().Window(Driver.WindowHandles.ToList().First());
            _boxRouter.Logout();
            _logonRouter.LogOn(AutomationTestsConstants.UserName2, AutomationTestsConstants.Password);
            _boxRouter.Forwarding();
            _forwardingPageModel.ForwardingSaveChangesButton.Click();
            _settingsPageModel.FiltersTab.Click();
            _filtersPageModel.CreateFilterButton.Click();
            _filtersPageModel.FromInput.SendKeys(AutomationTestsConstants.UserName1);
            _filtersPageModel.HasAttachmentOption.Click();
            _filtersPageModel.CreateThisSearchFilter.Click();
            _filtersPageModel.FilterCreateOkButton.Click();
            _filtersPageModel.DeleteItCheck.Click();
            _filtersPageModel.MarkimportantCheck.Click();
            _filtersPageModel.CreateFilterPopupButton.Click();
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
            //_themesPageModel.SetThemLink.Click();
            _themesPageModel.BeachImage.Click();

        }

        [Test]
        public void SendMailWithAttachment_Test()
        {
            _logonRouter.LogOn(AutomationTestsConstants.UserName1, AutomationTestsConstants.Password);
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