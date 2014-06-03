using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace SeleniumTests
{
    [TestFixture]
    public class HeaderFooterLinks
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://spicestaging.azurewebsites.net/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheHeaderFooterLinksTest()
        {
            driver.Navigate().GoToUrl(baseURL + "/");
            try
            {
                Assert.AreEqual("Home", driver.FindElement(By.LinkText("Home")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Activities", driver.FindElement(By.LinkText("Activities")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("About Spice & Time Credits", driver.FindElement(By.LinkText("About Spice & Time Credits")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("For partners", driver.FindElement(By.LinkText("For partners")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Blog", driver.FindElement(By.LinkText("Blog")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            try
            {
                Assert.AreEqual("Sign-in", driver.FindElement(By.Id("lnkLogin")).Text);
            }
            catch (AssertionException e)
            {
                verificationErrors.Append(e.Message);
            }
            driver.FindElement(By.LinkText("Activities")).Click();
            Assert.AreEqual("http://spicestaging.azurewebsites.net/Activities/Categories", driver.Url);
            driver.FindElement(By.LinkText("Home")).Click();
            driver.FindElement(By.LinkText("About Spice & Time Credits")).Click();
            Assert.AreEqual("http://spicestaging.azurewebsites.net/Home/About", driver.Url);
            driver.FindElement(By.LinkText("Home")).Click();
            driver.FindElement(By.LinkText("For partners")).Click();
            Assert.AreEqual("http://spicestaging.azurewebsites.net/Partner", driver.Url);
            driver.FindElement(By.LinkText("Home")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'Activities')])[2]")).Click();
            Assert.AreEqual("http://spicestaging.azurewebsites.net/Activities/Categories", driver.Url);
            driver.FindElement(By.LinkText("Home")).Click();
            driver.FindElement(By.LinkText("Find a branch near you")).Click();
            Assert.AreEqual("http://spicestaging.azurewebsites.net/Account/SignUp", driver.Url);
            driver.FindElement(By.LinkText("Home")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'About Spice & Time Credits')])[3]")).Click();
            Assert.AreEqual("http://spicestaging.azurewebsites.net/Home/About", driver.Url);
            driver.FindElement(By.LinkText("Home")).Click();
            driver.FindElement(By.XPath("(//a[contains(text(),'For partners')])[2]")).Click();
            Assert.AreEqual("http://spicestaging.azurewebsites.net/Partner", driver.Url);
            driver.FindElement(By.LinkText("Home")).Click();
            driver.FindElement(By.LinkText("All branches")).Click();
            Assert.AreEqual("http://spicestaging.azurewebsites.net/Home/AllBranches", driver.Url);
            driver.FindElement(By.LinkText("Home")).Click();
            driver.FindElement(By.LinkText("Start a branch")).Click();
            Assert.AreEqual("http://spicestaging.azurewebsites.net/Home/StartABranch", driver.Url);
            driver.FindElement(By.LinkText("Home")).Click();
            driver.FindElement(By.LinkText("Terms & conditions")).Click();
            Assert.AreEqual("http://spicestaging.azurewebsites.net/Home/Terms", driver.Url);
            driver.FindElement(By.LinkText("Home")).Click();
            driver.FindElement(By.LinkText("Sign-up to Spice")).Click();
            Assert.AreEqual("http://spicestaging.azurewebsites.net/Account/SignUp", driver.Url);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
