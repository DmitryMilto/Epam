using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Framework.Pages
{
    public static class FlugerPage
    {
        static IWebDriver driver;
        private static string url = "https://www.ebookers.ch/Fluege";

        private static By NurFluger = By.Id("tab-flight-tab");

        private static By Roundtrip = By.Id("flight-type-roundtrip-label");
        private static By OneWay = By.Id("flight-type-one-way-label");
        private static By MultiDest = By.Id("flight-type-multi-dest-label");

        private static By Origin = By.Id("flight-origin");
        private static By Destination = By.Id("flight-destination");

        private static By DataInit = By.Id("flight-departing");
        private static By DataFinich = By.Id("flight-returning");

        private static By Man = By.Id("flight-adults");
        private static By Kinder = By.Id("flight-children");

        private static By SerchButtom = By.Id("search-button");

        private static By Errors = By.ClassName("alert-title");

        private static By Origin2 = By.Id("flight-0-origin");
        private static By Destination2 = By.Id("flight-0-destination");
        private static By DataInit2 = By.Id("flight-0-departing");

        private static By Origin3 = By.Id("flight-1-origin");
        private static By Destination3 = By.Id("flight-1-destination");
        private static By DataInit3 = By.Id("flight-1-departing");

        private static By AddFlight = By.Id("add-another-flight");

        private static By FlightContainer = By.Id("flight-listing-container");

        private static DateTime dateTime = DateTime.Today;

        public static IWebDriver Instance()
        {
            driver = new ChromeDriver(@"D:\Учёба\7 семестр\EPAM\Lab_4_(UnitTest)\Lab_4_(UnitTest)\bin\Debug");
            driver.Manage().Window.Maximize();
            return driver;
        }
        public static void URL()
        {
            driver.Navigate().GoToUrl(url);
        }
        public static void NurHinflugError(string initairport, string finitairipr,int manKol ,int data)
        {
            driver.FindElement(OneWay).Click();
            driver.FindElement(Origin).SendKeys(initairport);
            driver.FindElement(Destination).SendKeys(finitairipr);
            driver.FindElement(DataInit).SendKeys(dateTime.AddDays(data).ToString());
            driver.FindElement(Man).SendKeys(manKol.ToString());
            driver.FindElement(SerchButtom).Click();
        }
        public static void NurHinflugOk(string initairport, string finitairipr, int manKol, int data)
        {
            driver.FindElement(OneWay).Click();
            driver.FindElement(Origin).SendKeys(initairport);
            driver.FindElement(Destination).SendKeys(finitairipr);
            driver.FindElement(DataInit).SendKeys(dateTime.AddDays(data).ToString());
            driver.FindElement(Man).SendKeys(manKol.ToString());
            driver.FindElement(SerchButtom).Click();
        }
        public static void NurRuckflugError(string initairport, int manKol, int data)
        {
            driver.FindElement(Roundtrip).Click();
            driver.FindElement(Origin).SendKeys(initairport);
            driver.FindElement(Destination).SendKeys(initairport);
            driver.FindElement(DataInit).SendKeys(dateTime.AddDays(data).ToString());
            driver.FindElement(DataFinich).SendKeys(dateTime.AddDays(data).ToString());
            driver.FindElement(Man).SendKeys(manKol.ToString());
            driver.FindElement(SerchButtom).Click();
        }
        public static void NurRuckflugOk(string initairport, string finitairipr, int manKol, int data)
        {
            driver.FindElement(Roundtrip).Click();
            driver.FindElement(Origin).SendKeys(initairport);
            driver.FindElement(Destination).SendKeys(finitairipr);
            driver.FindElement(DataInit).SendKeys(dateTime.AddDays(data).ToString());
            driver.FindElement(DataFinich).SendKeys(dateTime.AddDays(data+1).ToString());
            driver.FindElement(Man).SendKeys(manKol.ToString());
            driver.FindElement(SerchButtom).Click();
        }
        public static void MiltuFluError(string initairport, string finitairipr, int manKol, int data)
        {
            driver.FindElement(MultiDest).Click();

            driver.FindElement(Origin).SendKeys(initairport);
            driver.FindElement(Destination).SendKeys(finitairipr);
            driver.FindElement(DataInit).SendKeys(dateTime.AddDays(data).ToString());

            driver.FindElement(Man).SendKeys(manKol.ToString());

            driver.FindElement(Origin2).SendKeys(finitairipr);
            driver.FindElement(Destination2).SendKeys(initairport);
            driver.FindElement(DataInit2).SendKeys(dateTime.AddDays(data + 1).ToString());

            driver.FindElement(AddFlight).Click();

            driver.FindElement(Origin3).SendKeys(initairport);
            driver.FindElement(Destination3).SendKeys(finitairipr);
            driver.FindElement(DataInit3).SendKeys(dateTime.AddDays(data).ToString());

            driver.FindElement(SerchButtom).Click();
        }
        public static void MiltuFluOk(string initairport, string finitairipr, string finitairipr2, int manKol, int data)
        {
            driver.FindElement(MultiDest).Click();

            driver.FindElement(Origin).SendKeys(initairport);
            driver.FindElement(Destination).SendKeys(finitairipr);
            driver.FindElement(DataInit).SendKeys(dateTime.AddDays(data).ToString());

            driver.FindElement(Man).SendKeys(manKol.ToString());

            driver.FindElement(Origin2).SendKeys(finitairipr);
            driver.FindElement(Destination2).SendKeys(finitairipr2);
            driver.FindElement(DataInit2).SendKeys(dateTime.AddDays(data + 1).ToString());

            driver.FindElement(SerchButtom).Click();
        }
        public static string Error
        {
            get { return driver.FindElement(Errors).Text; }
        }
        public static bool Ok
        {
            get { return driver.FindElement(FlightContainer).Enabled; }
        }
    }
}
