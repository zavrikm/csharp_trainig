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
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            navigationHelper.OpenHomePage();
            loginHelper.Login(new AccountData("admin", "secret"));
            OpenDashboard();
            contactHelper.ChooseContactInTable(1);
            acceptNextAlert = true;
            contactHelper.ClickDeleteContactButton();
            contactHelper.ConfirmDeletindContactToAlert();
            Logout();
        }


    }
}
