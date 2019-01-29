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
            contactHelper.OpenDashboard();
            contactHelper.ChooseContactInTable(1);
            contactHelper.LookForAlert(true);
            contactHelper.ClickDeleteContactButton();
            contactHelper.ConfirmDeletindContactToAlert();
            loginHelper.Logout();
        }

    }
}
