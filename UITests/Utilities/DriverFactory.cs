using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using NUnit.Framework;

namespace UITests.Utilities
{
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(EdgeDriver))]
    public class DriverFactory
    {
        public static IWebDriver InitiateWebDriver(string browser)
        {
            var chromeOptions = new ChromeOptions();
            chromeOptions.AddArguments(
            "--window-size=1920,1080",
            "--allow-insecure-localhost",
            "--headless",
            "--disable-gpu",
            "--no-sandbox"
         );
            IWebDriver driver = null;
            if (browser.Equals(CommonConstants.DriverSettings.HeadlessBrowser))
            {
                driver = new ChromeDriver(CommonConstants.DriverSettings.BinaryLocationChrome, chromeOptions);
            }
            else if (browser.Equals(CommonConstants.DriverSettings.ChromeBrowser))
            {
                driver = new ChromeDriver(CommonConstants.DriverSettings.BinaryLocationChrome);
            }
            else if (browser.Equals(CommonConstants.DriverSettings.EdgeBrowser))
            {
                driver = new EdgeDriver(CommonConstants.DriverSettings.BinaryLocationEdge);
            }

            //switch(browser)
            //{
            //    case "Headless":

            //        browser.Equals(CommonConstants.DriverSettings.HeadlessBrowser);
            //        driver = new ChromeDriver(CommonConstants.DriverSettings.BinaryLocationChrome, chromeOptions);
            //        break;

            //    case "Chrome":

            //        browser.Equals(CommonConstants.DriverSettings.EdgeBrowser);
            //        driver = new ChromeDriver(CommonConstants.DriverSettings.BinaryLocationEdge);
            //        break;

            //    case "Edge":

            //        browser.Equals(CommonConstants.DriverSettings.ChromeBrowser);
            //        driver = new ChromeDriver(CommonConstants.DriverSettings.BinaryLocationChrome);
            //        break;

            //}

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(CommonConstants.DriverSettings.DefaultWaitTime);
            driver.Manage().Window.Maximize();
            return driver;
        }

    }
}
