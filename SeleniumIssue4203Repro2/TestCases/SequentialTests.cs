using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Chrome;
using SeleniumIssue4203Repro2.PageObjects;
using SeleniumIssue4203Repro2.WrapperFactory;

namespace SeleniumIssue4203Repro2.TestCases
{
    class SequentialTests
    {
        [SetUp]
        public void StartDriver()
        {
            BrowserFactory.InitBrowser(Properties.Settings.Default.BrowserName);
        }

        [TearDown]
        public void ShutdownDriver()
        {
            BrowserFactory.CloseAllDrivers();
        }

        [Test]
        public void Test1()
        {
            BrowserFactory.LoadApplication("https://www.google.com");
            BrowserFactory.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("lst-ib")));
            Page.GoogleSearch.Search("Cheese");
            BrowserFactory.Wait.Until(d => d.Title.Contains("Cheese"));
            Assert.That(BrowserFactory.Driver.Title, Does.Contain("Cheese"));
        }

        [Test]
        public void Test2()
        {
            BrowserFactory.LoadApplication("https://www.bing.com");
            BrowserFactory.Wait.Until(ExpectedConditions.ElementToBeClickable(By.Id("sb_form_q")));
            Page.BingSearch.Search("Fromage");
            BrowserFactory.Wait.Until(d => d.Title.Contains("Fromage"));
            Assert.That(BrowserFactory.Driver.Title, Does.Contain("Fromage"));
        }
    }
}
