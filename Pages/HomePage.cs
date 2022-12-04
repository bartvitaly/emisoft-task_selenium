using OpenQA.Selenium;

namespace emsisoft_task_selenium
{
    class HomePage
    {
        IWebDriver driver;
        public static By alternative_installation_options = By.CssSelector("[href*='download-installation']");

        public HomePage(IWebDriver driver)
        {
            this.driver = driver;
        }

        public DownloadPage open_download_page()
        {
            driver.FindElement(alternative_installation_options).Click();
            return new DownloadPage(driver);
        }
    }
}