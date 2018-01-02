using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Pages
{
    class HotelsPage
    {
        static IWebDriver driver;
        private static string url = "https://www.ebookers.ch/Hotels";
        private static readonly By Reiseziel = By.Id("hotel-destination");
        private static readonly By Anreise = By.Id("hotel-checkin");
        private static readonly By Abreise = By.Id("hotel-checkout");
        private static readonly By Zimmer = By.Id("hotel-rooms");
        private static readonly By Man = By.Id("hotel-1-adults");
        private static readonly By Kinder = By.Id("hotel-1-children");

        private static readonly By AgeKinder = By.Id("hotel-1-age-select-");

        private static readonly By SearchButton = By.Id("search-button"); 
        //private static readonly By SearchButton = By.ClassName("col search-btn-col");

        private static readonly By Results = By.Id("resultsContainer");

        private static readonly By ErrorTitle = By.ClassName("alert-title no-outline");

        private static readonly DateTime date = DateTime.Today;

        private static Random random = new Random();

        public static void URL()
        {
            driver = Driver.DriverInstance.GetInstance();
            driver.Navigate().GoToUrl(url);
        }
        static bool Babies(int amountChildren)
        {
            return amountChildren <= 6 ? true : false;
        }
        static void childrenAge(int amountChildren)
        {
            for (int i = 1; i <= amountChildren; i++)
            {
                driver.FindElement(By.Id("hotel-1-age-select-" + i)).SendKeys(random.Next(1, 17).ToString());
                Thread.Sleep(1000);
            }
        }
        public static void HotelErr(string namestate, int zimmer, int man, int kinder)
        {
            if (Babies(kinder))
            {
                driver.FindElement(Reiseziel).SendKeys(namestate);
                driver.FindElement(Anreise).SendKeys(date.AddDays(7).ToString());
                driver.FindElement(Abreise).SendKeys(date.AddDays(9).ToString());
                driver.FindElement(Zimmer).SendKeys(zimmer.ToString());
                driver.FindElement(Man).SendKeys(man.ToString());
                driver.FindElement(Kinder).SendKeys(kinder.ToString());
                childrenAge(kinder);
                driver.FindElement(SearchButton).Click();
            }
        }
        public static void HotelOk(string namestate, int zimmer, int man, int kinder)
        {
            if (Babies(kinder))
            {
                driver.FindElement(Reiseziel).SendKeys(namestate);
                driver.FindElement(Anreise).SendKeys(date.AddDays(7).ToString());
                driver.FindElement(Abreise).SendKeys(date.AddDays(9).ToString());
                driver.FindElement(Zimmer).SendKeys(zimmer.ToString());
                driver.FindElement(Man).SendKeys(man.ToString());
                driver.FindElement(Kinder).SendKeys(kinder.ToString());
                childrenAge(kinder);
                driver.FindElement(SearchButton).Click();
            }
        }
        public static string NameError
        {
            get { return driver.FindElement(ErrorTitle).Text; }
        }
        public static bool OkResult
        {
            get { return driver.FindElement(Results).Enabled; }
        }
        public static void Close()
        {
            driver.Quit();
            driver = null;

            foreach (var process in Process.GetProcessesByName("chromedriver"))
            {
                process.Kill();
            }
        }
    }
}
