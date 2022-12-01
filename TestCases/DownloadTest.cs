using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Reflection;

namespace emsisoft_task_selenium
{
    class DownloadTest {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = Common.GetChromeDriver();
        }

        [Test]
        public void test()
        {
            driver.Url = "http://emsisoft.com/en/anti-malware-home";

            HomePage home_page = new HomePage(driver);
            DownloadPage download_page = home_page.open_download_page();
            Common.DownloadFile(download_page.web_installer);
        }

        [TearDown] public void stopBrowser()
        {
            driver.Close();
        }
    }
}