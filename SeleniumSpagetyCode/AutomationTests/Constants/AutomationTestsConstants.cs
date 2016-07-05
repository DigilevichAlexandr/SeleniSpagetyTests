namespace AutomationTests.Constants
{
    public static class AutomationTestsConstants
    {
        public static string GmailAddres = "https://mail.google.com/";

        public const int OperationTimeoutInSeconds = 10;
        public const int LongOperationTimeoutInSeconds = 60;

        public const string GeneratedFilePath = "file.mp4";

        public const string UserName1 = "digilevichuser1@gmail.com";
        public const string Password = "qrweafsd1423";

        public const string UserName2 = "digilevichuser2@gmail.com";
        public const string UserName3 = "digilevichuser3@gmail.com";

        public const string TestFilesName = "testfile.txt";
        public const string TestFilePath = @"D:\";

        public const string Subject = "test";
        public const string MessageText = "Hello, {0}.";
        public const string SenderName = "jason todd";

        public const string ItemName = "td[4]/div/span";
        public const string ItemDiscription = "td[5]/div/span[2]";
        public const string FirstItemName = "//div[@gh='tl']/div[1]/div[1]/table/tbody/tr[1]/td[4]/div/span";
        public const string IboxFirstItemName = "//div[@role='tabpanel']/div[2]/div/table/tbody/tr[1]/td[4]/div[2]/span";
        public const string PopupOkButtonXpath = "//button[@name='ok']";
        public const string PopupCloseButtonXpath = "//span[@aria-label='Close']";
        public const string TopVacationXpath = "//a[@target='_top']/../../../div[3]/div/div";
        public const string ColorsXpath = "//td[@role='gridcell']/div[starts-with(@title,'RGB')]";
        public const string MyShortcutSquareXpath = "//a[starts-with(@title, '{0}')]/../../../div[3]/div";
        public const string LabelXpath = "//a[@title='{0}']";


        public const string SettingsUrl = "https://mail.google.com/mail/#settings/general";
        public const string ForwardingUrl = "https://mail.google.com/mail/#settings/fwdandpop";
        public const string ChoseAnAccountUrl = "https://accounts.google.com/SignOutOptions?hl=en&continue=https://mail.google.com/mail&service=mail";
        public const string FiltersUrl = "https://mail.google.com/mail/#settings/filters";
        public const string StarredUrl = "https://mail.google.com/mail/u/0/#starred?compose=new";
        public const string SentUrl = "https://mail.google.com/mail/u/0/#sent";
        public const string LabelsUrl = "https://mail.google.com/mail/u/0/#settings/labels";

        public const string SignatureText = "TestSignature";
        public const string VacationDate = "July 10, 2016";
        public const string VacationText = "summer vacation";
        public const string SlashTwoDots = "/..";
        public const string Span = "/span";
        public const string TwoSlashOption = "//option";

        public const string LabelName = "My shortcut";
        public const string NestedLabelName = "My inserted shortcut";

        public enum LabelColors
        {
            Non = 1,
            Red = 11,
            Green = 23
        }
    }
}