using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using System.Diagnostics;
using System.Threading;

namespace Framework
{
    [TestClass]
    public class AutomationSites
    {
        //static IWebDriver driver;
        string firsname = "Lewiohan";
        string lastname = "Demons";
        string invalidEmail = "lewoihan.com";
        string email = "lewiohan@demons.com";
        string password = "LewioDems666";

        //test with error on the page with authorization
        [TestMethod]
        public void LoginTextPolity()
        {
            Pages.LoginPage.URL();
            Pages.LoginPage.LoginNoPolity(firsname, lastname, email, password);
            Assert.AreEqual("Bitte bestätigen Sie, dass Sie den Geschäftsbedingungen und der Datenschutzrichtlinie zustimmen.", Pages.LoginPage.ErrorPolity, "Error");
        }
        //test with an error in the wrong spelled mail
        [TestMethod]
        public void LoginTextEMail()
        {
            Pages.LoginPage.URL();
            Pages.LoginPage.LoginEMail(firsname, lastname, invalidEmail, password);
            Assert.AreEqual("Bitte geben Sie eine gültige E-Mail-Adresse ein.", Pages.LoginPage.ErrorEMail, "Error");
        }
        string fromAirport = "Minsk, Weißrussland (MSQ-Minsk Intl.)";
        string beforeAirportError = "Minsk, Germany (SXF-Schoenefeld)";
        string beforeAirport = "Berlin, Germany (SXF-Schoenefeld)";
        string additionalAirport = "Rom, Italien (FCO)";
        int numberAdults = 2;
        int date = 2;
        //registrations without errors
                [TestMethod]
        public void LoginTextOk()
        {
            Pages.LoginPage.URL();
            Pages.LoginPage.LoginEMail(firsname, lastname, email, password);
            Assert.IsTrue(Pages.LoginPage.Ok);
            Pages.FlugerPage.Close();
        }
        //test: one-way flight with an error
        [TestMethod]
        public void FlugerOneTextError()
        {
            Pages.FlugerPage.URL();
            Pages.FlugerPage.NurHinflugError(fromAirport, beforeAirportError, numberAdults, date);
            Assert.AreEqual("Bitte korrigieren Sie den Fehler.", Pages.FlugerPage.Error);
            Pages.FlugerPage.Close();
        }
        //test: one-way flight
        [TestMethod]
        public void FlugerOneTextOk()
        {
            Pages.FlugerPage.URL();
            Pages.FlugerPage.NurHinflugOk(fromAirport, beforeAirport, numberAdults, date);
            Thread.Sleep(1000);
            Assert.IsTrue(Pages.FlugerPage.Ok);
            Pages.FlugerPage.Close();
        }
        //test: round trip with an error
                [TestMethod]
        public void FlugerNurRuckTextError()
        {
            Pages.FlugerPage.URL();
            Pages.FlugerPage.NurRuckflugError(fromAirport, numberAdults, date);
            Assert.AreEqual("Bitte korrigieren Sie den Fehler.", Pages.FlugerPage.Error);
        }
        //test: round trip
        [TestMethod]
        public void FlugerNurRuckTextOk()
        { 
            Pages.FlugerPage.URL();
            Pages.FlugerPage.NurRuckflugOk(fromAirport, beforeAirport, numberAdults, date);
            Thread.Sleep(1000);
            Assert.IsTrue(Pages.FlugerPage.Ok);
        }
        //test: multiple route with error
                [TestMethod]
        public void FlugerMultiTextError()
        {
            Pages.FlugerPage.URL();
            Pages.FlugerPage.MiltuFluError(fromAirport, beforeAirport, numberAdults, date);
            Assert.AreEqual("Bitte korrigieren Sie den Fehler.", Pages.FlugerPage.Error);
        }
        //test: multiple route
                [TestMethod]
        public void FlugerMultiTextOk()
        {
            Pages.FlugerPage.URL();
            Pages.FlugerPage.MiltuFluOk(fromAirport, beforeAirport, additionalAirport, numberAdults, date);
            Thread.Sleep(1000);
            Assert.IsTrue(Pages.FlugerPage.Ok);
        }
        string wrongСountry = "Minsk, Birliyn";
        string country = "Minsk, Belarus";
        int numberRooms = 1;
        int amountChildren = 0;

        //test: hotel booking with an error
                [TestMethod]
        public void HotelError()
        {
            Pages.HotelsPage.URL();
            Pages.HotelsPage.HotelErr(wrongСountry, numberRooms, numberAdults, amountChildren);
            Assert.AreEqual("Bitte korrigieren Sie den Fehler.", Pages.HotelsPage.NameError);
        }
        //test: hotel booking
        [TestMethod]
        public void HotelOk()
        {
            Pages.HotelsPage.URL();
            Pages.HotelsPage.HotelErr(country, numberRooms, numberAdults, amountChildren);
            Thread.Sleep(1000);
            Assert.IsTrue(Pages.HotelsPage.OkResult);
            Pages.HotelsPage.Close();
        }
        string time = "1100AM";
        string type = "EP";
        //auto
        [TestMethod]
        public void AutoSearch()
        {
            Pages.AutoPage.URL();
            Pages.AutoPage.Auto(country, "Minsk", date, time);
            Thread.Sleep(1000);
            Assert.IsTrue(Pages.AutoPage.Results);
        }
        //auto с дополнительными
        [TestMethod]
        public void AdditionallyAutoSearch()
        {
            Pages.AutoPage.URL();
            Pages.AutoPage.AdditionallyAuto(country, "Minsk", date, time, type);
            Thread.Sleep(1000);
            Assert.IsTrue(Pages.AutoPage.Results);
        }
        //clear
        [TestCleanup]
        public void Cleanup()
        {
            foreach (var process in Process.GetProcessesByName("chromedriver"))
            {
                process.Kill();
            }
        }
    }
}
