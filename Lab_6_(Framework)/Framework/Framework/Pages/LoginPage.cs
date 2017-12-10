using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Diagnostics;
using System.Threading;

namespace Framework.Pages
{
    public static class LoginPage
    {
        static IWebDriver driver;
        private static string url = "https://www.ebookers.ch/user/createaccount?fromheader=true";

        private static readonly By FirsName = By.Id("create-account-firstname");
        private static readonly By LastName = By.Id("create-account-lastname");
        private static readonly By EMail = By.Id("create-account-emailId");
        private static readonly By Password = By.Id("create-account-password");
        private static readonly By TPassword = By.Id("create-account-confirm-password");
        private static readonly By Button = By.Id("create-account-submit-button");

        
        private static readonly By CheckBoxPolicy = By.Id("create-account-expedia-policy");


        private static readonly By ErrorsPolity = By.Id("term-and-conditions-id");
        private static readonly By ErrorsEMail = By.ClassName("errorLink");

        private static readonly By Complete = By.Id("complete-registration-warning-container");
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
        public static void LoginNoPolity(string firsname, string lastname, string email, string password)
        {
            
            driver.FindElement(FirsName).SendKeys(firsname);
            driver.FindElement(LastName).SendKeys(lastname);
            driver.FindElement(EMail).SendKeys(email);
            driver.FindElement(Password).SendKeys(password);
            driver.FindElement(TPassword).SendKeys(password);
            driver.FindElement(Button).Click(); 
        }
        public static void LoginEMail(string firsname, string lastname, string email, string password)
        {

            driver.FindElement(FirsName).SendKeys(firsname);
            driver.FindElement(LastName).SendKeys(lastname);
            driver.FindElement(EMail).SendKeys(email);
            driver.FindElement(Password).SendKeys(password);
            driver.FindElement(TPassword).SendKeys(password);
            driver.FindElement(CheckBoxPolicy).Click();
            Thread.Sleep(100);
            driver.FindElement(Button).Click();
        }
        public static void LoginOk(string firsname, string lastname, string email, string password)
        {

            driver.FindElement(FirsName).SendKeys(firsname);
            driver.FindElement(LastName).SendKeys(lastname);
            driver.FindElement(EMail).SendKeys(email);
            driver.FindElement(Password).SendKeys(password);
            driver.FindElement(TPassword).SendKeys(password);
            driver.FindElement(CheckBoxPolicy).Click();
            driver.FindElement(Button).Click();
        }
        public static string ErrorPolity
        {
            get{ return driver.FindElement(ErrorsPolity).Text; }
        }
        public static string ErrorEMail
        {
            get { return driver.FindElement(ErrorsEMail).Text; }
        }
        public static bool Ok
        {
            get { return driver.FindElement(Complete).Enabled; }
        }
    }
}
