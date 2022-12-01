using OpenQA.Selenium;
using System;

namespace emsisoft_task_selenium
{

    class HomePage
    {
        String url = "/anti-malware-home/";

        IWebDriver driver;
        IWebElement alternative_installation_options;

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
            alternative_installation_options = this.driver.FindElement(By.CssSelector("[href*='download-installation']"));

        }

        public DownloadPage open_download_page()
        {
            alternative_installation_options.Click();
            return new DownloadPage(driver);
        }
    }
}