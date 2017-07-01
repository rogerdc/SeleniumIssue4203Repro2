using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumIssue4203Repro2.PageObjects
{
    public class BingResultsPage
    {
        [FindsBy(How = How.Id, Using = "sb_form_q")]
        private IWebElement SearchBox { get; set; }

        [FindsBy(How = How.Id, Using = "sb_form_go")]
        private IWebElement SubmitSearch { get; set; }

        public void Search(string Query)
        {
            SearchBox.SendKeys(Query);
            SubmitSearch.Click();
        }
    }
}
