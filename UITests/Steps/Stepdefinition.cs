using NUnit.Framework;
using UITests.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using UITests.PageObjects;
using Newtonsoft.Json.Linq;
using OpenQA.Selenium.Interactions;
using System;
using UITests.Utilities;
using Newtonsoft.Json;
using System.IO;
using System.Data;
using System.Linq;
using System.Collections.Generic;
using System.Windows;

namespace UITests.Steps
{
    [Binding]
    public class Stepdefinition : BaseClass
    {
        Pageobjects po = new Pageobjects(Driver);
        WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 5));
        JSON read = new JSON();
    }
}
