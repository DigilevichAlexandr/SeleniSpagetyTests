using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace AutomationTests.PageModels
{
    class LogOnPageModel:PageModel
    {
        [FindsBy(How = How.Id, Using = "Email")]
        public IWebElement Email { get; set; }
        [FindsBy(How = How.Id, Using = "next")]
        public IWebElement Next { get; set; }
        [FindsBy(How = How.Id, Using = "Passwd")]
        public IWebElement Password { get; set; }
        [FindsBy(How = How.Id, Using = "signIn")]
        public IWebElement SignIn { get; set; }
        [FindsBy(How = How.Id, Using = "choose-account-1")]
        public IWebElement User1 { get; set; }
        [FindsBy(How = How.Id, Using = "choose-account-2")]
        public IWebElement User2 { get; set; }
        [FindsBy(How = How.Id, Using = "account-chooser-link")]
        public IWebElement ChoseAnotherAccount { get; set; }
        [FindsBy(How = How.Id, Using = "account-chooser-add-account")]
        public IWebElement AddAnotherAccount { get; set; }
    }
}
