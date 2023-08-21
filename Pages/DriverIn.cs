using Newtonsoft.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.DevTools.V113.Page;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcomerceTesting.Pages
{

    
    public class DriverIn 
    {
        IWebDriver d;
           

        public  IWebDriver DriverInIt()
        {
            string json = File.ReadAllText("C:\\Users\\SHIVARAJ GUTTEDAR\\source\\repos\\EcomerceTesting\\Properties.json");
            dynamic config = JsonConvert.DeserializeObject(json);
            String url = config.url;
            String browser = config.browser;

            if (d == null)
            {
                if (browser.Equals("chrome"))
                {
                    d = new ChromeDriver();
                }
                else if (browser.Equals("firefox"))
                {
                    d = new FirefoxDriver();
                }

                else if (browser.Equals("edge"))
                {
                    d = new EdgeDriver();
                }
                d.Url = url;
                d.Manage().Window.Maximize();
                d.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

                
            }

            return d;
        }
    }
}
