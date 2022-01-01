using NUnit.Framework;
using UITests.Data;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using UITests.PageObjects;
using System;
using System.IO;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;

namespace UITests.Steps
{
    [Binding]
    [TestFixture(typeof(ChromeDriver))]
    [TestFixture(typeof(EdgeDriver))]
    [Parallelizable]
    public class Stepdefinition : BaseClass
    {
        Pageobjects po = new Pageobjects(Driver);
        WebDriverWait wait = new WebDriverWait(Driver, new TimeSpan(0, 0, 5));
        JSON read = new JSON();
        

        [Given(@"I am on the main page")]
        public void GivenIAmOnTheMainPage()
        {
                Driver.Navigate().GoToUrl(read.jsonReader("TestData.json", "url"));
        }

        [Given(@"I want to register")]
        public void GivenIWantToRegister()
        {
            Assert.IsTrue(po.registry.Text.Contains(read.jsonReader("TestData.json", "registry")), "Text does not match as expected");
            po.registry.Click();
           
        }

        [When(@"I add my details")]
        public void WhenIAddMyDetails()
        {
            StreamWriter writer = new StreamWriter("..//username.txt");
            Random rnd = new Random();
            int number = rnd.Next(0, 1000000);
            int num = rnd.Next(0, 26);
            char rc = (char)('A' + num);
            var randomuser = "username" + number + rc + "@gmail.com";
            Assert.IsTrue(po.registry.Text.Contains(read.jsonReader("TestData.json", "registry")), "Text does not match as expected");
            Assert.IsTrue(po.registrytitle.Text.Contains(read.jsonReader("TestData.json", "registrytitle")), "Text does not match as expected");
            Assert.IsTrue(po.loginlbl.Text.Contains(read.jsonReader("TestData.json", "loginlbl")), "Text does not match as expected");
            po.usrtxt.SendKeys(randomuser);
            Assert.IsTrue(po.firstnamelbl.Text.Contains(read.jsonReader("TestData.json", "firstnamelbl")), "Text does not match as expected");
            po.firstnametxt.SendKeys(read.jsonReader("TestData.json", "firstname"));
            Assert.IsTrue(po.lastnamelbl.Text.Contains(read.jsonReader("TestData.json", "lastnamelbl")), "Text does not match as expected");
            po.lastnametxt.SendKeys(read.jsonReader("TestData.json", "lastname"));
            Assert.IsTrue(po.pwdlbl.Text.Contains(read.jsonReader("TestData.json", "pwdlbl")), "Text does not match as expected");
            po.pwdtxt.SendKeys(read.jsonReader("TestData.json", "password"));
            Assert.IsTrue(po.cnfpwdlbl.Text.Contains(read.jsonReader("TestData.json", "cnflbl")), "Text does not match as expected");
            po.cnfpwdtxt.SendKeys(read.jsonReader("TestData.json", "password"));
            Assert.IsTrue(po.submitbtn.Text.Contains(read.jsonReader("TestData.json", "registry")), "Text does not match as expected");
            po.submitbtn.Click();
            writer.Write(randomuser);
            writer.Close();
        }

        [Then(@"I am registered successfully")]
        public void ThenIAmRegisteredSuccessfully()
        {
            Assert.IsTrue(po.cnfmsg.Text.Contains(read.jsonReader("TestData.json", "cnfmsg")), "Text does not match as expected");
        }


        [When(@"I click cancel")]
        public void WhenIClickCancel()
        {
            Assert.IsTrue(po.cancelbtn.Text.Contains(read.jsonReader("TestData.json", "cancelbtn")), "Text does not match as expected");
            po.cancelbtn.Click();
        }

        [Then(@"I am redirected to the main page")]
        [Given(@"I am redirected to the main page")]
        public void ThenIAmRedirectedToTheMainPage()
        {
            Driver.Navigate().GoToUrl(read.jsonReader("TestData.json", "url"));
            Assert.IsTrue(po.brandlbl.Text.Contains(read.jsonReader("TestData.json", "brandlbl")), "Text does not match as expected");
            Assert.IsTrue(po.imgmain.Displayed, "Image does not exist");
            wait.Until(Driver => Driver.FindElement(By.XPath("/html/body/my-app/div/main/my-home/div/div[1]/div/a/img")).Displayed);
            Assert.IsTrue(po.img1.Displayed, "Image does not exist");
            wait.Until(Driver => Driver.FindElement(By.XPath("/html/body/my-app/div/main/my-home/div/div[2]/div/a/img")).Displayed);
            Assert.IsTrue(po.img2.Displayed, "Image does not exist");
            wait.Until(Driver => Driver.FindElement(By.XPath("/html/body/my-app/div/main/my-home/div/div[3]/div/a/img")).Displayed);
            Assert.IsTrue(po.img3.Displayed, "Image does not exist");
            wait.Until(Driver => Driver.FindElement(By.XPath("/html/body/my-app/div/main/my-home/div/div[1]/div/h2")).Displayed);
            Assert.IsTrue(po.txt1.Text.Contains(read.jsonReader("TestData.json", "txt1")), "Text does not match as expected");
            wait.Until(Driver => Driver.FindElement(By.XPath("/html/body/my-app/div/main/my-home/div/div[2]/div/h2")).Displayed);
            Assert.IsTrue(po.txt2.Text.Contains(read.jsonReader("TestData.json", "txt2")), "Text does not match as expected");
            wait.Until(Driver => Driver.FindElement(By.XPath("/html/body/my-app/div/main/my-home/div/div[3]/div/h2")).Displayed);
            Assert.IsTrue(po.txt3.Text.Contains(read.jsonReader("TestData.json", "txt3")), "Text does not match as expected");
            
        }


        [Given(@"I login to the application")]
        public void GivenILoginToTheApplication()
        {
            Assert.IsTrue(po.loginbtn.Text.Contains(read.jsonReader("TestData.json", "logintxt")), "Text does not match as expected");
            StreamReader reader = new StreamReader("..//username.txt");
            var result = reader.ReadToEnd();
            po.loginusrtxt.SendKeys(result);
            po.loginpwdtxt.SendKeys(read.jsonReader("TestData.json", "password"));
            po.loginbtn.Click();
        }

        [Given(@"I select my favorite car")]
        public void GivenISelectMyFavoriteCar()
        {
            wait.Until(Driver => Driver.FindElement(By.XPath("/html/body/my-app/div/main/my-home/div/div[3]/div/a/img")).Displayed);
            Assert.IsTrue(po.img3.Displayed, "Image is not displayed");
            po.img3.Click();
            Assert.IsTrue(po.firstvote.Displayed, "Image is not displayed");
            po.firstvote.Click();
        }


        [When(@"I cast a vote for my favorite car")]
        public void WhenICastAVoteForMyFavoriteCar()
        {
            var i = Driver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[1]/h4/strong")).Text;
            po.votingtxtfield.SendKeys(read.jsonReader("TestData.json", "carvoting"));
            Assert.IsTrue(po.votingbtn.Text.Contains(read.jsonReader("TestData.json", "votetxt")), "Text does not match as expected");
            po.votingbtn.Click();
            wait.Until(Driver => Driver.FindElement(By.CssSelector("p.card-text")).Displayed);
            var j = Driver.FindElement(By.XPath("/html/body/my-app/div/main/my-model/div/div[1]/div[3]/div[2]/div[1]/h4/strong")).Text;
            Assert.Greater(j, i);
        }

        [Then(@"I am able to see the appropriate message")]
        public void ThenIAmAbleToSeeTheAppropriateMessage()
        {
            Assert.IsTrue(po.votingmsg.Text.Contains(read.jsonReader("TestData.json", "votingmsg")), "Text does not match as expected");
        }



        [Given(@"I click on the list of cars")]
        public void GivenIclickonthelistofcars()
        {
            po.img3.Click();
            wait.Until(Driver => Driver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table")).Displayed);
            Assert.IsTrue(po.car.Text.Contains(read.jsonReader("TestData.json", "car1")), "Text does not match as expected");
            Assert.IsTrue(po.model.Text.Contains(read.jsonReader("TestData.json", "model1")), "Text does not match as expected");
            Assert.IsTrue(po.rank.Text.Contains(read.jsonReader("TestData.json", "rank1")), "Text does not match as expected");
            Assert.IsTrue(po.engine.Text.Contains(read.jsonReader("TestData.json", "engine1")), "Text does not match as expected");
        }


        [When(@"I traverse forward through the pages")]
        public void WhenITraverseForwardThroughThePages()
        {
            po.forward.Click();
            wait.Until(Driver => Driver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table")).Displayed);
            
            po.forward.Click();
            wait.Until(Driver => Driver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table")).Displayed);
            
            po.forward.Click();
            wait.Until(Driver => Driver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table")).Displayed);
            
            po.forward.Click();
            wait.Until(Driver => Driver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table")).Displayed);
            

        }

        [When(@"I traverse back through the pages")]
        public void WhenITraverseBackThroughThePages()
        {
            po.backward.Click();
            wait.Until(Driver => Driver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table")).Displayed);

            po.backward.Click();
            wait.Until(Driver => Driver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table")).Displayed);

            po.backward.Click();
            wait.Until(Driver => Driver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table")).Displayed);

            po.backward.Click();
            wait.Until(Driver => Driver.FindElement(By.XPath("/html/body/my-app/div/main/my-overall/div/div/table")).Displayed);

        }

        [Then(@"I am able to see the different cars")]
        public void ThenIAmAbleToSeeTheDifferentCars()
        {
            Assert.IsTrue(po.car.Text.Contains(read.jsonReader("TestData.json", "car1")), "Text does not match as expected");
            Assert.IsTrue(po.model.Text.Contains(read.jsonReader("TestData.json", "model1")), "Text does not match as expected");
            Assert.IsTrue(po.rank.Text.Contains(read.jsonReader("TestData.json", "rank1")), "Text does not match as expected");
            Assert.IsTrue(po.engine.Text.Contains(read.jsonReader("TestData.json", "engine1")), "Text does not match as expected");

        }

        [Then(@"I logout of the application")]
        public void ThenILogoutOfTheApplication()
        {
            Assert.IsTrue(po.logoutbtn.Text.Contains(read.jsonReader("TestData.json", "logout")), "Text does not match as expected");
            po.logoutbtn.Click();
        }

        [When(@"I proceed to vote")]
        public void WhenIProceedToVote()
        {
            wait.Until(Driver => Driver.FindElement(By.XPath("/html/body/my-app/div/main/my-home/div/div[3]/div/a/img")).Displayed);
            Assert.IsTrue(po.img3.Displayed, "Image is not displayed");
            po.img3.Click();
            Assert.IsTrue(po.firstvote.Displayed, "Image is not displayed");
            Assert.IsTrue(po.viewmore.Text.Contains(read.jsonReader("TestData.json", "viewmore")), "Text does not match as expected");
            po.viewmore.Click();
            Assert.IsTrue(po.imgmain.Displayed, "Image not displayed");
        }




    }
}
