using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class TestBase
    {

      
        protected IWebDriver driver;
        protected StringBuilder verificationErrors;
        protected string baseURL;
        protected bool acceptNextAlert = true;

        protected LoginHelper loginHelper;  // links to helpers
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";
            verificationErrors = new StringBuilder();

            loginHelper = new LoginHelper(driver);
            navigationHelper = new NavigationHelper(driver, baseURL);
            groupHelper = new GroupHelper(driver);
            contactHelper = new ContactHelper(driver, acceptNextAlert);
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


        // ************************ help methods *******************************************


        #region Alerts

        ////protected string CloseAlertAndGetItsText()
        ////{
        ////    try
        ////    {
        ////        IAlert alert = driver.SwitchTo().Alert();
        ////        string alertText = alert.Text;
        ////        if (acceptNextAlert)
        ////        {
        ////            alert.Accept();
        ////        }
        ////        else
        ////        {
        ////            alert.Dismiss();
        ////        }
        ////        return alertText;
        ////    }
        ////    finally
        ////    {
        ////        acceptNextAlert = true;
        ////    }
        ////}

        //protected bool IsAlertPresent()
        //{
        //    try
        //    {
        //        driver.SwitchTo().Alert();
        //        return true;
        //    }
        //    catch (NoAlertPresentException)
        //    {
        //        return false;
        //    }
        //}

        //protected bool IsElementPresent(By by)
        //{
        //    try
        //    {
        //        driver.FindElement(by);
        //        return true;
        //    }
        //    catch (NoSuchElementException)
        //    {
        //        return false;
        //    }
        //}

        #endregion

    }
}
