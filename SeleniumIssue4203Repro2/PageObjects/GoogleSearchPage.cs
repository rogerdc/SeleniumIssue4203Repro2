using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumIssue4203Repro2.PageObjects
{
    public class GoogleSearchPage
    {
        [FindsBy(How = How.Id, Using = "lst-ib")]
        private IWebElement SearchBox { get; set; }

        public void Search(string Query)
        {
            SearchBox.SendKeys(Query);
            SearchBox.Submit();
        }
    }
}
