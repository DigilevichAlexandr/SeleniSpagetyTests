using System.Linq;
using System.Threading;
using System.Windows.Forms;
using AutomationTests.Constants;
using AutomationTests.Extentions;
using AutomationTests.PageModels;
using AutomationTests.PageModels.Settings;
using AutomationTests.PageModels.Shortcuts;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace AutomationTests.PageRouters
{
    public class MyShortcutMenuRouter
    {
        private IWebDriver _driver;
        private BoxPageModel _boxPageModel;
        private AddLabelPageModel _addLabelPageModel;
        private MyShortcutMenuPageModel _myShortcutMenuPageModel;
        private SetColorPageModel _setColorPageModel;
        private LabelsPageModels _labelsPageModels;

        public MyShortcutMenuRouter()
        {
            _driver = PropertiesCollection.Driver;
            _boxPageModel = new BoxPageModel();
            _addLabelPageModel = new AddLabelPageModel();
            _myShortcutMenuPageModel = new MyShortcutMenuPageModel();
            _setColorPageModel = new SetColorPageModel();
            _labelsPageModels = new LabelsPageModels();
        }

        public void AddLabel(string name)
        {
            _driver.Navigate().GoToUrl(AutomationTestsConstants.LabelsUrl);
            _driver.WaitForAjax();
            _labelsPageModels.CreateLabelButton.Click();
            _addLabelPageModel.LabelNameInput.SendKeys(name);
            _addLabelPageModel.ButtonOk.Click();
            Thread.Sleep(3000);
        }

        public void AddSubLabel(string name)
        {
            _boxPageModel.MyShortcutRightTriangle.Click();
            _boxPageModel.AddSublabel.Click();
            _addLabelPageModel.LabelNameInput.SendKeys(name);
            _addLabelPageModel.NestUnderSelect.Click();
            _addLabelPageModel
                .NestUnderSelect
                .FindElement(By.XPath(string.Format("{0}[@value='{1}']", AutomationTestsConstants.TwoSlashOption, AutomationTestsConstants.LabelName)))
                .Click();
            if (!IsNestUnderChecked())
            {
                _addLabelPageModel.NestUnderCheck.Click();
            }

            _addLabelPageModel.ButtonOk.Click();
            Thread.Sleep(5000);
        }

        public void AddMultipleLabels(int num, string name)
        {
            for (int i = 0; i < num; i++)
            {
                AddSubLabel(string.Format("{0} {1}", name, i));
            }
        }

        public bool IsLabelExists(string name)
        {
            return _driver.FindElements(By.XPath(string.Format(AutomationTestsConstants.LabelXpath, name))).Count == 1;
        }

        public void DeleteLabel(string name)
        {
            _driver.FindElement(By.XPath(string.Format(AutomationTestsConstants.MyShortcutSquareXpath, name))).Click();
            _myShortcutMenuPageModel.Delete.Click();
            _addLabelPageModel.ButtonOk.Click();
        }

        public bool IsLabelColorsCommon()
        {
            var rootColor =
                _driver.FindElement(By.XPath(string.Format(AutomationTestsConstants.MyShortcutSquareXpath, AutomationTestsConstants.LabelName)))
                    .GetBackgroundColor();
            var subLabels =
                _driver.FindElements(
                    By.XPath(string.Format(AutomationTestsConstants.MyShortcutSquareXpath,
                        AutomationTestsConstants.NestedLabelName)));

            foreach (var label in subLabels)
            {
                var color = label.GetBackgroundColor();
                if (!color.Equals(rootColor))
                    return false;
            }

            return true;
        }

        public bool IsNestUnderChecked()
        {
            return _addLabelPageModel.NestUnderCheck.GetAttribute("checked").Equals("true");
        }

        public void DeleteNested()
        {
            //Actions action = new Actions(_driver);
            //action.MoveToElement(_boxPageModel.MyNestedShortcut).Perform();
            //_boxPageModel.MyNestedShortcut.SendKeys(OpenQA.Selenium.Keys.ArrowLeft);
            SendKeys.SendWait(@"{LEFT}");
            _boxPageModel.MyNestedShortcutRightTriangle.Click();
            _myShortcutMenuPageModel.Delete.Click();
            _addLabelPageModel.ButtonOk.Click();
            Thread.Sleep(3000);
        }

        public void ChangeColor(int color)
        {
            ChooseColor(color);
            Thread.Sleep(4000);
        }

        public void ChangeSubtitlesColor(int color)
        {
            ChooseColor(color);
            _setColorPageModel.SetSubtitlesColorOption.Click();
            _setColorPageModel.SetColorButton.Click();
            Thread.Sleep(4000);
        }

        private void ChooseColor(int color)
        {
            _boxPageModel.MyShortcutRightTriangle.Click();
            Actions action = new Actions(_driver);
            action.MoveToElement(_myShortcutMenuPageModel.ChangeColor).Perform();
            Thread.Sleep(2000);
            _driver.FindElements(By.XPath(AutomationTestsConstants.ColorsXpath))[color].Click();
        }
    }
}