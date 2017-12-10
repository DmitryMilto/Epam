using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Driver
{
    public static class DriverInstance
    {
        private static IWebDriver driver;

        //private static DriverInstance() { }

        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = new FirefoxDriver(@"D:\Учёба\7 семестр\EPAM\Lab_5_(Framework)\Framework\Framework\DriverBinaries");
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseBrowser()
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
