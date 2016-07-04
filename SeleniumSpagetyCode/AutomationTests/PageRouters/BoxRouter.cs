using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading;
using System.Windows.Forms;
using AutomationTests.Constants;
using AutomationTests.Extentions;
using AutomationTests.Helpers;
using AutomationTests.Models;
using AutomationTests.PageModels;
using AutomationTests.PageModels.Settings;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;

namespace AutomationTests.PageRouters
{
    public class BoxRouter
    {
        private IWebDriver _driver;

        private BoxPageModel _boxPageModel;
        private ComposePageModel _composePageModel;
        private InboxPageModel _inboxPageModel;
        private SettingsRouter _settingsRouter;
        private ChooseAnAccountPageModel _chooseAnAccountPageModel;
        private ForwardingPageModel _forwardingPageModel;
        private FiltersPageModel _filtersPageModel;
        private LogonRouter _logonRouter;
        private SpamPageModel _spamPageModel;

        public BoxRouter()
        {
            _driver = PropertiesCollection.Driver;
            _boxPageModel = new BoxPageModel();
            _composePageModel = new ComposePageModel();
            _inboxPageModel = new InboxPageModel();
            _settingsRouter = new SettingsRouter();
            _chooseAnAccountPageModel = new ChooseAnAccountPageModel();
            _forwardingPageModel = new ForwardingPageModel();
            _filtersPageModel = new FiltersPageModel();
            _logonRouter = new LogonRouter();
            _spamPageModel = new SpamPageModel();
        }

        public void AddForwardAddress(string address)
        {
            Forwarding();
            ForwardingHelper.DeletAddreses(_driver);
            _forwardingPageModel.AddForwardingAddress.Click();
            _forwardingPageModel.ForwardingAddressInput.SendKeys(address);
            _forwardingPageModel.ForwardingNextButton.Click();
            _driver.SwitchTo().Window(_driver.WindowHandles.ToList().Last());
            _forwardingPageModel.ProceedButton.Click();
            _driver.SwitchTo().Window(_driver.WindowHandles.ToList().First());
            _forwardingPageModel.ForwardingOkButton.Click();
            _driver.WaitForAjax();
        }

        public void AddFilter(string address)
        {
            Forwarding();
            _driver.Navigate().GoToUrl(AutomationTestsConstants.FiltersUrl);
            FiltersHelper.DeletFilters(_driver);
            _filtersPageModel.CreateFilterButton.Click();
            _filtersPageModel.FromInput.SendKeys(address);
            _filtersPageModel.HasAttachmentOption.Click();
            _filtersPageModel.CreateThisSearchFilter.Click();
            _filtersPageModel.DeleteItCheck.Click();
            _filtersPageModel.MarkimportantCheck.Click();
            _filtersPageModel.CreateFilterPopupButton.Click();
        }

        public void AcceptForwarding()
        {
            _inboxPageModel.FirstEmailRowElement.Click();
            _forwardingPageModel.ForwardingAcceptLink.Click();
            _driver.WaitForAjax();
            _driver.SwitchTo().Window(_driver.WindowHandles.ToList().Last());
            _forwardingPageModel.ForwardingConfirmButton.Click();
        }

        public void Logout()
        {
            NavigateChooseAnAccount();
            CommonHelper.AcceptPopap();
            _chooseAnAccountPageModel.SignOut.Click();
            var chooseButton = _driver.FindElements(By.Id("account-chooser-link"));
            if (chooseButton.Any())
            {
                chooseButton.First().Click();
            }

            _driver.FindElement(By.Id("account-chooser-add-account")).Click();
        }

        public void Forwarding()
        {
            NavigateSettings();
            _settingsRouter.NavigateForwarding();
        }

        public void Send(User user, Letter letter, string name = null)
        {
            _boxPageModel.ComposeButton.Click();
            FillMessage(user, letter);
            if (!string.IsNullOrEmpty(name))
            {
                AttachFile(name);
                if (IsPopupAppeared())
                {
                    _driver.FindElement(By.XPath(AutomationTestsConstants.PopupCloseButtonXpath)).Click();
                    if (IsPopupAppeared())
                    {
                        _driver.FindElement(By.XPath(AutomationTestsConstants.PopupCloseButtonXpath)).Click();
                    }
                }
            }

            Thread.Sleep(1000);
            _composePageModel.SendButton.Click();
            Thread.Sleep(5000);
        }

        public void FillMessage(User user, Letter letter)
        {
            _driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(10));
            _composePageModel.To.SendKeys(letter.To);
            _composePageModel.Subject.SendKeys(letter.Subject);
            _composePageModel.MessageBody.SendKeys(letter.MessageBody);
        }

        public void AttachFile(string name)
        {
            _composePageModel.AddAttachmentButton.Click();
            Thread.Sleep(3000);

            //for (int i = 0; i < 4; i++)
            //{
            //    SendKeys.SendWait(@"{TAB}");
            //}

            //SendKeys.SendWait(@"+{F10}");
            //for (int i = 0; i < 3; i++)
            //{
            //    SendKeys.SendWait(@"{DOWN}");
            //}

            //SendKeys.SendWait(@"{Enter}");
            //Thread.Sleep(3000);
            //SendKeys.SendWait(@"{BS}");

            //SendKeys.SendWait(AutomationTestsConstants.TestFilePath);
            //SendKeys.SendWait(@"{Enter}");

            //for (int i = 0; i < 8; i++)
            //{
            //    SendKeys.SendWait(@"{TAB}");
            //}

            SendKeys.SendWait(name);
            SendKeys.SendWait(@"{Enter}");
        }

        public bool IsPopupAppeared()
        {
            if (_driver.FindElements(By.XPath(AutomationTestsConstants.PopupCloseButtonXpath)).Any())
            {
                return true;
            }

            return false;
        }

        public void NavigateToSpamFolder()
        {
            _driver.Navigate().GoToUrl("https://mail.google.com/mail/#spam");
            _driver.WaitForAjax();
        }

        public void CleareSpam()
        {
            NavigateToSpamFolder();
            _spamPageModel.SelectAllCheckbox.Click();
            _spamPageModel.NotSpamButton.Click();
        }

        public string GetFirstMessageSenderName()
        {
            return _inboxPageModel.FirstEmailRowElement.GetAttribute("email");
        }

        public string GetFirstMessageSenderNameFromSpam()
        {
            return _inboxPageModel.FirstEmailRowElementInSpam.Text;
        }

        public void SwitchAccountTo(User user)
        {
            Logout();
            _logonRouter.LogOn(user);
        }

        public void MarkFirstMessageAsSpam()
        {
            _boxPageModel.CheckFirstEmail.Click();
            Actions action = new Actions(_driver);
            action.MoveToElement(_driver.FindElement(By.XPath("//div[@gh='mtb']"))).Perform();
            _boxPageModel.ReportSpamButtom.Click();
            _driver.WaitForAjax();
        }

        public bool MessageIsInTrash(string name)
        {
            _driver.Navigate().GoToUrl("https://mail.google.com/mail/u/0/#trash");
            return
                _driver.FindElements(
                    By.XPath(
                        "//td[text()='No conversations in the Trash. Who needs to delete when you have so much storage?!']"))
                    .Count == 0
                && name.StartsWith(_driver.FindElement(By.XPath(AutomationTestsConstants.FirstItemName)).Text);
        }

        public bool MessageIsInInbox(string name)
        {
            _driver.Navigate().GoToUrl("https://mail.google.com/mail/u/0/#inbox");
            return
                _driver.FindElements(
                    By.XPath(
                        "//td[text()='Your Primary tab is empty.']"))
                    .Count == 0
                && name.StartsWith(_driver.FindElement(By.XPath(AutomationTestsConstants.IboxFirstItemName)).Text);
        }

        public bool MessageMarkedUsImportant()
        {
            // TO DO
            return true;
        }

        public void NavigateSettings()
        {
            _driver.Navigate().GoToUrl(AutomationTestsConstants.SettingsUrl);
        }

        public void NavigateChooseAnAccount()
        {
            _driver.Navigate().GoToUrl(AutomationTestsConstants.ChoseAnAccountUrl);
        }

        public void NavigateToPickImage()
        {
            _driver.Navigate().GoToUrl("https://mail.google.com/mail/u/0/?tm=1#inbox/themes");
            _driver.WaitForAjax();
        }

        public string GetVacationDateFromTop()
        {
            var all = _driver.FindElement(By.XPath(string.Format("{0}{1}{2}", AutomationTestsConstants.TopVacationXpath, AutomationTestsConstants.Span, AutomationTestsConstants.SlashTwoDots))).Text;
            var endNow = _driver.FindElement(By.XPath(string.Format("{0}{1}[1]", AutomationTestsConstants.TopVacationXpath, AutomationTestsConstants.Span))).Text;
            var settings = _driver.FindElement(By.XPath(string.Format("{0}{1}[2]", AutomationTestsConstants.TopVacationXpath, AutomationTestsConstants.Span))).Text;
            return all.Replace(endNow, string.Empty).Replace(settings, string.Empty).TrimEnd();
        }
    }
}