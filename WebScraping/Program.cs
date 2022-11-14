using cloudscribe.HtmlAgilityPack;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;
using System.Text;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using System.Threading.Tasks;
using OpenQA.Selenium.Interactions;
using WebScraping;

namespace MyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IWebDriver driver = new ChromeDriver();

            driver.Navigate().GoToUrl(Setting.Url);

            var rut1 = driver.FindElement(By.Name(Setting.NameRutField1));
            var rut2 = driver.FindElement(By.Name(Setting.NameRutField2));
            var accept = driver.FindElement(By.Name(Setting.NameAcceptField));

            rut1.SendKeys(Setting.Rut1Value);
            rut2.SendKeys(Setting.Rut2Value);

            accept.Submit();

        }
    }
}