using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : TestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.OpenDashboard();
            app.Contacts.ChooseContactInTable(1);
            app.Contacts.LookForAlert(true);
            app.Contacts.ClickDeleteContactButton();
            app.Contacts.ConfirmDeletindContactToAlert();
            app.Auth.Logout();
        }

    }
}
