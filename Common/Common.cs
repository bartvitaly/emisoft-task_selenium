using OpenQA.Selenium;
using System.Net;

namespace emsisoft_task_selenium
{
    internal class Common
    {

        public static string getFileNameFromUrl(string url)
        {
            string[] array = url.Split('/');
            return array[array.Length - 1];
        }

        public static void downloadFile(IWebElement webElement)
        {
            var client = new WebClient();
            string url = webElement.GetAttribute("href");
            client.DownloadFile(url, getFileNameFromUrl(url));
        }
    }
}
