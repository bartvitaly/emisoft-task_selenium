using OpenQA.Selenium;
using System;

namespace emsisoft_task_selenium
{
    internal class DownloadPage
    {
        String url = "/download-installation/";

        private IWebDriver driver;
        public IWebElement web_installer;

        public DownloadPage(IWebDriver driver)
        {
            this.driver = driver;
            web_installer = this.driver.FindElement(By.XPath("//a[text()='Web installer']"));
        }
    }
}
