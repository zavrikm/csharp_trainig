using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformation()
        {
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
            ContactData fromForm = app.Contacts.GetContactInformationFromForm(0);

            // verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address1, fromForm.Address1);

            Console.WriteLine("fromForm homePhone1 = " + fromForm.HomePhone1);
            Console.WriteLine("fromForm mobilePhone = " + fromForm.MobilePhone);
            Console.WriteLine("fromForm workPhone = " + fromForm.WorkPhone);
            Console.WriteLine("fromForm allPhones =" + fromForm.AllPhones);

            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }
    }
}
