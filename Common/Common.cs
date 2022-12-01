using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;
using System.Net;
using System.Reflection;

namespace emsisoft_task_selenium
{
    class Common
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

        public static string get_file_name_from_url(string url)
        {
            string[] array = url.Split('/');
            return array[array.Length - 1];
        }

        public static string download_file(IWebElement webElement)
        {
            var client = new WebClient();
            string url = webElement.GetAttribute("href");
            System.IO.Directory.CreateDirectory(download_directory);

            string file_path = download_directory + get_file_name_from_url(url);
            client.DownloadFile(url, file_path);

            return file_path;
        }

        public static Boolean check_file(string file_path)
        {
            return File.Exists(file_path);
        }

        public static Boolean check_file_not_empty(string file_path)
        {
            return (new FileInfo(file_path).Length != 0);
        }

        public static void remove_file(string file_path)
        {
            if (Common.check_file(file_path)) {
                File.Delete(file_path);
            }
        }
    }
}
