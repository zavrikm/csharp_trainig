﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ApplicationManager
    {

        protected IWebDriver driver;
        protected string baseURL;

        protected LoginHelper loginHelper;  // fields with links to helpers
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;
        protected ContactHelper contactHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>(); 

        private ApplicationManager() //constructor
        {

            driver = new FirefoxDriver();
            baseURL = "http://localhost/addressbook";

            loginHelper = new LoginHelper(this);
            navigationHelper = new NavigationHelper(this);
            groupHelper = new GroupHelper(this);
            contactHelper = new ContactHelper(this);


        }


         ~ApplicationManager() // destructor
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }


        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                app.Value = new ApplicationManager();
            }
            return app.Value;
        }

        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public string BaseURL

        {
            get
            {
                return baseURL;
            }
        }

        public LoginHelper Auth   // Propertyes for from test
        {
            get
            {
                return loginHelper;
            }
        }

        public NavigationHelper Navigator
        {
            get
            {
                return navigationHelper;
            }
        }

        public GroupHelper Groups
        {
            get
            {
                return groupHelper;
            }
        }

        public ContactHelper Contacts
        {
            get
            {
                return contactHelper;
            }
        }


        //public void Stop() // Stop ewbdriver on ending the testing
        //{
        //    //try
        //    //{
        //    //    driver.Quit();
        //    //}
        //    //catch (Exception)
        //    //{
        //    //    // Ignore errors if unable to close the browser
        //    //}
        //}

    }
}
