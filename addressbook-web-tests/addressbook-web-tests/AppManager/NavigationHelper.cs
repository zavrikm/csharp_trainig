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
    public class NavigationHelper : HelperBase
    {
       
        private string baseURL;

        public NavigationHelper(ApplicationManager manager) : base(manager)
        {
            baseURL = manager.BaseURL;
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseURL + "/addressbook");
        }

        public void GoToGroupsPage()
        {
            if (driver.Url == manager.BaseURL + "/addressbook/group.php" && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void OpenDashboard()
        {
            if (driver.Url == manager.BaseURL + "/addressbook/" && IsElementPresent(By.XPath("//a[.='All e-mail']")))
            {
                return;
            }

            driver.FindElement(By.LinkText("home")).Click();
        }



    }
}
