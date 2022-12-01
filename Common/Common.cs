using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.IO;
using System.Net;
using System.Reflection;

namespace emsisoft_task_selenium
{
    internal class Common
    {

        public static string bin_dir = System.IO.Directory.GetCurrentDirectory();
        public static string home_dir = Directory.GetParent(bin_dir).Parent.FullName;
        public static string download_directory = home_dir + "\\downloads\\";

        public static IWebDriver GetChromeDriver()
        { 
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments("headless");
            var path = home_dir + "\\drivers\\chromedriver.exe";
            IWebDriver driver = new ChromeDriver(path, chromeOptions);
            driver.Manage().Window.Maximize();

            return driver;
        }

        public static string GetFileNameFromUrl(string url)
        {
            string[] array = url.Split('/');
            return array[array.Length - 1];
        }

        public static void DownloadFile(IWebElement webElement)
        {
            var client = new WebClient();
            string url = webElement.GetAttribute("href");
            System.IO.Directory.CreateDirectory(download_directory);
            client.DownloadFile(url, download_directory + GetFileNameFromUrl(url));
        }
    }
}
