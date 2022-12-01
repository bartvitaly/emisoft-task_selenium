using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.IO;

namespace emsisoft_task_selenium
{
    class DownloadTest {

        IWebDriver driver;
        string expected_installation_file_path = Common.download_directory + DownloadPage.windows_installation_file;

        [SetUp]
        public void start_browser()
        {
            driver = Common.GetChromeDriver();
            Common.remove_file(expected_installation_file_path);
        }

        [Test]
        public void test()
        {
            driver.Url = "http://emsisoft.com/en/anti-malware-home";

            HomePage home_page = new HomePage(driver);
            DownloadPage download_page = home_page.open_download_page();
            string file_path = Common.download_file(download_page.web_installer);

            Assert.True(Common.check_file(file_path));
            Assert.True(Common.check_file(expected_installation_file_path));
            Assert.True(Common.check_file_not_empty(expected_installation_file_path));
        }

        [TearDown] public void stop_browser()
        {
            driver.Close();
        }
    }
}