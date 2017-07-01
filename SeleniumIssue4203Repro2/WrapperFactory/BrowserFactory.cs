using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.IE;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;

namespace SeleniumIssue4203Repro2.WrapperFactory
{
    class BrowserFactory
    {
        private static readonly IDictionary<string, IWebDriver> Drivers = new Dictionary<string, IWebDriver>();
        private static readonly IDictionary<string, WebDriverWait> Waits = new Dictionary<string, WebDriverWait>();
        private static IWebDriver driver;
        private static WebDriverWait wait;

        public static IWebDriver Driver
        {
            get
            {
                return driver;
            }
            private set
            {
                driver = value;
            }
        }

        public static WebDriverWait Wait
        {
            get
            {
                if (wait == null)
                    throw new NullReferenceException("The Wait instance was not initialized. You should first call the method InitBrowser.");
                return wait;
            }
            private set
            {
                wait = value;
            }
        }

        public static void InitBrowser(string browserName)
        {
            switch (browserName)
            {
                case "Firefox":
                    if (Driver == null)
                    {
                        driver = new FirefoxDriver();
                        Drivers.Add("Firefox", Driver);
                        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.Timeout));
                        Waits.Add("Firefox", Wait);
                    }
                    break;

                case "IE":
                    if (Driver == null)
                    {
                        driver = new InternetExplorerDriver();
                        Drivers.Add("IE", Driver);
                        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.Timeout));
                        Waits.Add("IE", Wait);
                    }
                    break;

                case "Chrome":
                    if (Driver == null)
                    {
                        driver = new ChromeDriver();
                        Drivers.Add("Chrome", Driver);
                        wait = new WebDriverWait(driver, TimeSpan.FromSeconds(Properties.Settings.Default.Timeout));
                        Waits.Add("Chrome", Wait);
                    }
                    break;
            }
        }

        public static void LoadApplication(string url)
        {
            Driver.Url = url;
        }

        public static void CloseAllDrivers()
        {
            foreach (var key in Drivers.Keys)
            {
                Waits[key] = null;
                Drivers[key].Close();
                Drivers[key].Quit();
            }
        }
    }
}