using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationTests.Constants;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace AutomationTests.Extentions
{
    public static class WebDriverExtensions
    {

        public static void WaitForAjax(this IWebDriver webDriver)
        {
            const string jsCommand = "if (typeof jQuery != 'undefined') { return (jQuery.active === 0) } else { return true }";

            WaitExecuteScriptCatchUnexpectedError(webDriver, jsCommand);
        }

        public static TResult WaitUntil<TResult>(this IWebDriver webDriver, Func<IWebDriver, TResult> action, Type[] exceptionTypes)
        {
            var waiter = webDriver.GetWaiter();
            waiter.IgnoreExceptionTypes(exceptionTypes);

            return waiter.Until(action);
        }

        private static WebDriverWait GetWaiter(this IWebDriver webDriver)
        {
            return webDriver.GetWaiter(AutomationTestsConstants.LongOperationTimeoutInSeconds);
        }

        private static WebDriverWait GetWaiter(this IWebDriver webDriver, int numberOfSeconds)
        {
            return new WebDriverWait(webDriver, TimeSpan.FromSeconds(numberOfSeconds));
        }

        private static void WaitExecuteScriptCatchUnexpectedError(IWebDriver webDriver, string jsCommand)
        {
            webDriver.WaitUntil(d => (bool)(d as IJavaScriptExecutor).ExecuteScript(jsCommand), new[] { typeof(InvalidOperationException) });
        }
    }
}
