﻿using UITests.Steps;
using System.Linq;
using TechTalk.SpecFlow;
using System;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using System.IO;
using OpenQA.Selenium.Support.Extensions;

namespace UITests.Utilities
{
    [Binding]
    public class Hooks : BaseClass
    {
        readonly string currentDirectory = Directory.GetParent(NUnit.Framework.TestContext.CurrentContext.TestDirectory).Parent.FullName;

        [BeforeScenario]
        public void BeforeScenario()
        {
            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("Chrome"))
            {
                Driver = DriverFactory.InitiateWebDriver(CommonConstants.DriverSettings.ChromeBrowser);
            }
            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("Edge"))
            {
                Driver = DriverFactory.InitiateWebDriver(CommonConstants.DriverSettings.EdgeBrowser);
            }
            if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("FireFox"))
            {
                Driver = DriverFactory.InitiateWebDriver(CommonConstants.DriverSettings.FireFoxBrowser);
            }
            else if (ScenarioContext.Current.ScenarioInfo.Tags.Contains("Headless"))
            {
                Driver = DriverFactory.InitiateWebDriver(CommonConstants.DriverSettings.HeadlessBrowser);
            }
        }

        [AfterScenario]
        public void AfterScenario()
        {
            if (NUnit.Framework.TestContext.CurrentContext.Result.Outcome != ResultState.Success)
            {
                var dir = $@"{currentDirectory}/Screenshots";
                Directory.CreateDirectory(dir);
                string pathfile = Path.Combine(currentDirectory + @"//Screenshots", "Screenshot" + "_" + DateTime.Now.ToString("(dd_MMMM_hh_mm_ss_tt).JPG"));
                var screenshot = Driver.TakeScreenshot();
                screenshot.SaveAsFile(pathfile, ScreenshotImageFormat.Jpeg);
            }
            else
            {
                Console.WriteLine("Test has passed");
            }
            Driver.Close();
            Driver.Quit();
            Driver.Dispose();
        }
    }
}