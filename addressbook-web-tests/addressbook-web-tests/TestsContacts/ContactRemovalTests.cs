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
            app.Contacts
                .OpenDashboard()
                .ChooseContactInTable(1);
            app.Contacts.LookForAlert(true);
            app.Contacts
                .ClickDeleteContactButton()
                .ConfirmDeletindContactToAlert();
        }

    }
}
