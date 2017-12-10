using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Selenium.Contrib.Extensions;
using System;
using OpenQA.Selenium.Support.UI;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Framework.Pages
{
    public static class AutoPage
    {
        static IWebDriver driver;
        private static string url = "https://www.ebookers.ch/mietwagen";

        private static By capPickup = By.Id("car-pickup");
        private static By carDropoff = By.Id("car-dropoff");

        private static By capPickupDate = By.Id("car-pickup-date");
        private static By capPickupTime = By.Id("car-pickup-time");

        private static By carDropoffDate = By.Id("car-dropoff-date");
        private static By carDropoffTime = By.Id("car-dropoff-time");

        private static By searchButton = By.Id("search-button");

        private static By optionsToggle = By.Id("car-options-toggle");
        private static By optionsType = By.Id("car-options-type");
        private static By optionsVendor = By.Id("car-options-vendor");

        private static By infantseat = By.Id("car-options-equipment-infantseat");
        private static By toddlerseatLabel = By.Id("car-options-equipment-toddlerseat-label");
        private static By skirack = By.Id("car-options-equipment-skirack");
        private static By chains = By.Id("car-options-equipment-chains");
        private static By navigation = By.Id("car-options-equipment-navigation-label");

        private static By Result = By.Id("main-results");

        private static DateTime dateTime = DateTime.Now;
        private static DateTime dateTime1 = DateTime.Now;
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
        public static void Auto(string cappickup, string cardropoff, int data, string value)
        {
            driver.FindElement(capPickup).SendKeys(cappickup);
            driver.FindElement(carDropoff).SendKeys(cardropoff);

            driver.FindElement(capPickupDate).SendKeys(dateTime.AddDays(data).ToString("d"));
            Thread.Sleep(1000);
            driver.FindElement(carDropoffDate).Clear();
            driver.FindElement(carDropoffDate).SendKeys(dateTime1.AddDays(data + 5).ToString("d"));

            var selectPickupTime = driver.FindElement(capPickupTime);
            var PickupTime = new SelectElement(selectPickupTime);
            PickupTime.SelectByValue(value);

            
            var selectDropoffTime = driver.FindElement(carDropoffTime);
            var DropoffTime = new SelectElement(selectDropoffTime);
            DropoffTime.SelectByValue(value);

            driver.FindElement(searchButton).Click();
        }
        public static void AdditionallyAuto(string cappickup, string cardropoff, int data, string value, string vendor)
        {
            driver.FindElement(capPickup).SendKeys(cappickup);
            driver.FindElement(carDropoff).SendKeys(cardropoff);

            driver.FindElement(capPickupDate).SendKeys(dateTime.AddDays(data).ToString("d"));
            
            driver.FindElement(carDropoffDate).Clear();
            driver.FindElement(carDropoffDate).SendKeys(dateTime1.AddDays(data + 5).ToString("d"));

            var selectPickupTime = driver.FindElement(capPickupTime);
            var PickupTime = new SelectElement(selectPickupTime);
            PickupTime.SelectByValue(value);


            var selectDropoffTime = driver.FindElement(carDropoffTime);
            var DropoffTime = new SelectElement(selectDropoffTime);
            DropoffTime.SelectByValue(value);

            driver.FindElement(optionsToggle).Click();
            Thread.Sleep(1000);
            Random random = new Random();
            var selectType = driver.FindElement(optionsType);
            var Type = new SelectElement(selectType);
            Type.SelectByValue(random.Next(1,7).ToString());

            var selectVendor = driver.FindElement(optionsVendor);
            var Vendor = new SelectElement(selectVendor);
            Vendor.SelectByValue(vendor);

            Thread.Sleep(1000);
            driver.FindElement(infantseat).Click();
            driver.FindElement(toddlerseatLabel).Click();
            driver.FindElement(skirack).Click();
            driver.FindElement(chains).Click();
            driver.FindElement(navigation).Click();

            driver.FindElement(searchButton).Click();
        }
        public static bool Results
        {
            get { return driver.FindElement(Result).Enabled; }
        }
    }
}
