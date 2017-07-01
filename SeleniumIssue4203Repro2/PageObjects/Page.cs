using SeleniumIssue4203Repro2.WrapperFactory;
using OpenQA.Selenium.Support.PageObjects;

namespace SeleniumIssue4203Repro2.PageObjects
{
    public static class Page
    {
        private static T GetPage<T>() where T : new()
        {
            var page = new T();
            PageFactory.InitElements(BrowserFactory.Driver, page);
            return page;
        }

        public static BingResultsPage BingResults
        {
            get { return GetPage<BingResultsPage>(); }
        }

        public static BingSearchPage BingSearch
        {
            get { return GetPage<BingSearchPage>(); }
        }

        public static GoogleResultsPage GoogleResults
        {
            get { return GetPage<GoogleResultsPage>(); }
        }

        public static GoogleSearchPage GoogleSearch
        {
            get { return GetPage<GoogleSearchPage>(); }
        }
    }
}