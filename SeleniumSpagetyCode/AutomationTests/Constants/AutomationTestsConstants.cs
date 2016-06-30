namespace AutomationTests.Constants
{
    public static class AutomationTestsConstants
    {
        public static string GmailAddres = "https://mail.google.com/";

        public const int OperationTimeoutInSeconds = 10;
        public const int LongOperationTimeoutInSeconds = 60;

        public const string UserName1 = "digilevichuser1@gmail.com";
        public const string Password = "qrweafsd1423";

        public const string UserName2 = "digilevichuser2@gmail.com";
        public const string UserName3 = "digilevichuser3@gmail.com";

        public const string FilesPath = "Files";

        public const string Subject = "test";
        public const string MessageText = "Hello, {0}.";
        public const string SenderName = "jason todd";

        public const string ItemName = "td[4]/div/span";
        public const string ItemDiscription = "td[5]/div/span[2]";
        public const string FirstItemName = "//div[@gh='tl']/div[1]/div[1]/table/tbody/tr[1]/td[4]/div/span";
        public const string IboxFirstItemName = "//div[@role='tabpanel']/div[2]/div/table/tbody/tr[1]/td[4]/div[2]/span";

        public const string SettingsUrl = "https://mail.google.com/mail/#settings/general";
        public const string ForwardingUrl = "https://mail.google.com/mail/#settings/fwdandpop";
        public const string ChoseAnAccountUrl = "https://accounts.google.com/SignOutOptions?hl=en&continue=https://mail.google.com/mail&service=mail";
        public const string FiltersUrl = "https://mail.google.com/mail/#settings/filters";
    }
}