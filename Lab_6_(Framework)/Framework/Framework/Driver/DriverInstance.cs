using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework.Driver
{
    public static class DriverInstance
    {
        private static IWebDriver driver;

        //private static DriverInstance() { }
        private static string pachDrivers = @"DriverBinaries";
        public static IWebDriver GetInstance()
        {
            if (driver == null)
            {
                driver = new ChromeDriver(Path.GetFullPath(pachDrivers));
                driver.Manage().Window.Maximize();
            }
            return driver;
        }

        public static void CloseBrowser()
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
