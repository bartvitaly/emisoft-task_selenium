using OpenQA.Selenium;

namespace emsisoft_task_selenium
{
    class DownloadPage
    {
        public static string windows_installation_file = "EmsisoftAntiMalwareWebSetup.exe";

        private IWebDriver driver;
        public static By web_installer = By.XPath("//a[text()='Web installer']");

        public DownloadPage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
