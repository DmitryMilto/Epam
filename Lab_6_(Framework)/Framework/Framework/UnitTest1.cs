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
    public class UnitTest1
    {
        static IWebDriver driver;
        
        //test login error polity
        [TestMethod]
        public void LoginTextPolity()
        {
            driver = Pages.LoginPage.Instance();
            Pages.LoginPage.URL();
            Pages.LoginPage.LoginNoPolity("lbvf", "lbvf", "dfg@fvdf.rt", "dfdfs123");
            Assert.AreEqual("Bitte bestätigen Sie, dass Sie den Geschäftsbedingungen und der Datenschutzrichtlinie zustimmen.", Pages.LoginPage.ErrorPolity, "Error");
        }
        //test email error email
        [TestMethod]
        public void LoginTextEMail()
        {
            driver = Pages.LoginPage.Instance();
            Pages.LoginPage.URL();
            Pages.LoginPage.LoginEMail("lbvf", "lbvf", "dfg@", "dfdfs123");
            Assert.AreEqual("Bitte geben Sie eine gültige E-Mail-Adresse ein.", Pages.LoginPage.ErrorEMail, "Error");
        }
        //регестрация без ошибок
        [TestMethod]
        public void LoginTextOk()
        {
            driver = Pages.LoginPage.Instance();
            Pages.LoginPage.URL();
            Pages.LoginPage.LoginEMail("Dimasik", "Ananasik", "hello@gmail.com", "DimAsik070");
            Assert.IsTrue(Pages.LoginPage.Ok);
        }
        //тест в одну сторону с ошибкой
        [TestMethod]
        public void FlugerOneTextError()
        {
            driver = Pages.FlugerPage.Instance();
            Pages.FlugerPage.URL();
            Pages.FlugerPage.NurHinflugError("Minsk, Weißrussland (MSQ-Minsk Intl.)", "Minsk, Germany (SXF-Schoenefeld)", 2, 7);
            Assert.AreEqual("Bitte korrigieren Sie den Fehler.", Pages.FlugerPage.Error);
        }
        //тест в одну сторону без ошибки
        [TestMethod]
        public void FlugerOneTextOk()
        {
            driver = Pages.FlugerPage.Instance();
            Pages.FlugerPage.URL();
            Pages.FlugerPage.NurHinflugOk("Minsk, Weißrussland (MSQ-Minsk Intl.)", "Berlin, Germany (SXF-Schoenefeld)", 2, 7);
            Thread.Sleep(1000);
            Assert.IsTrue(Pages.FlugerPage.Ok);
        }
        // тест туда-обратно с ошибкой
        [TestMethod]
        public void FlugerNurRuckTextError()
        {
            driver = Pages.FlugerPage.Instance();
            Pages.FlugerPage.URL();
            Pages.FlugerPage.NurRuckflugError("Minsk, Weißrussland (MSQ-Minsk Intl.)", 2, 7);
            Assert.AreEqual("Bitte korrigieren Sie den Fehler.", Pages.FlugerPage.Error);
        }
        // тест туда-обратно без ошибки
        [TestMethod]
        public void FlugerNurRuckTextOk()
        {
            driver = Pages.FlugerPage.Instance();
            Pages.FlugerPage.URL();
            Pages.FlugerPage.NurRuckflugOk("Minsk, Weißrussland (MSQ-Minsk Intl.)", "Berlin, Germany (SXF-Schoenefeld)", 2, 7);
            Thread.Sleep(1000);
            Assert.IsTrue(Pages.FlugerPage.Ok);
        }
        //множественный машрут, ошибка
        [TestMethod]
        public void FlugerMultiTextError()
        {
            driver = Pages.FlugerPage.Instance();
            Pages.FlugerPage.URL();
            Pages.FlugerPage.MiltuFluError("Minsk, Weißrussland (MSQ-Minsk Intl.)", "Berlin, Germany (SXF-Schoenefeld)", 2, 7);
            Assert.AreEqual("Bitte korrigieren Sie den Fehler.", Pages.FlugerPage.Error);
        }
        //множественный машрут, без ошибок
        [TestMethod]
        public void FlugerMultiTextOk()
        {
            driver = Pages.FlugerPage.Instance();
            Pages.FlugerPage.URL();
            Pages.FlugerPage.MiltuFluOk("Minsk, Weißrussland (MSQ-Minsk Intl.)", "Berlin, Germany (SXF-Schoenefeld)", "Rom, Italien (FCO)", 2, 7);
            Thread.Sleep(1000);
            Assert.IsTrue(Pages.FlugerPage.Ok);
        }
        //бронь отеля с ошибкой
        [TestMethod]
        public void HotelError()
        {
            driver = Pages.HotelsPage.Instance();
            Pages.HotelsPage.URL();
            Pages.HotelsPage.HotelErr("Minsk, Birliyn", 1, 2, 0);
            Assert.AreEqual("Bitte korrigieren Sie den Fehler.", Pages.HotelsPage.NameError);
        }
        //бронь отеля с ошибкой
        [TestMethod]
        public void HotelOk()
        {
            driver = Pages.HotelsPage.Instance();
            Pages.HotelsPage.URL();
            Pages.HotelsPage.HotelErr("Minsk, Belarus", 1, 2, 0);
            Thread.Sleep(1000);
            Assert.IsTrue(Pages.HotelsPage.OkResult);
        }
        //auto
        [TestMethod]
        public void AutoSearch()
        {
            driver = Pages.AutoPage.Instance();
            Pages.AutoPage.URL();
            Pages.AutoPage.Auto("Minsk, Belarus", "Minsk", 4, "1100AM");
            Thread.Sleep(1000);
            Assert.IsTrue(Pages.AutoPage.Results);
        }
        //auto с дополнительными
        [TestMethod]
        public void AdditionallyAutoSearch()
        {
            driver = Pages.AutoPage.Instance();
            Pages.AutoPage.URL();
            Pages.AutoPage.AdditionallyAuto("Minsk, Belarus", "Minsk", 4, "1100AM", "EP");
            Thread.Sleep(1000);
            Assert.IsTrue(Pages.AutoPage.Results);
        }
        //очистка
        [TestCleanup]
        public void Cleanup()
        {
            driver.Quit();
            driver = null;
            foreach (var process in Process.GetProcessesByName("geckodriver"))
            {
                process.Kill();
            }
        }
    }
}
