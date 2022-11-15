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
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using Newtonsoft.Json;
using System.Numerics;
using JsonSerializer = System.Text.Json.JsonSerializer;

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

            var items = driver.FindElements(By.ClassName(Setting.ClassName)).Where(p => !p.Text.StartsWith("Los antecedentes") 
                                                                                     && !p.Text.StartsWith("El contribuyente")
                                                                                     && !p.Text.StartsWith("A través de esta"));

            string json = JsonSerializer.Serialize(items);
            File.WriteAllText(@"D:\path.json", json);
        }
    }
}