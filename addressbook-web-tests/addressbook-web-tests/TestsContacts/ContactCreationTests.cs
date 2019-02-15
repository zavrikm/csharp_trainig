using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {

        [Test]
        public void ContactCreationTest()
        {


            ContactData contact = new ContactData();
            contact.FirstName = "Vivian";
            contact.MiddleName = "Ann";
            contact.LastName = "Winter";
            contact.NickName = "vivianw";
            contact.Title = "Mrs";
            contact.Company = "Some company";
            contact.Address1 = "Some address";
            contact.HomePhone1 = "123456";
            contact.MobilePhone = "123456789";
            contact.WorkPhone = "456789";
            contact.Email1 = "user@domain.dn";
            contact.BDay = "15";
            contact.BMonth = "April";
            contact.BYear = "1982";
            contact.Address2 = "Secondary address";


            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.Create(contact);


           


            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount(), "1-я проверка");

            List<ContactData> newContacts = app.Contacts.GetContactsList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts, "2-я проверка");
        }

 











 
    }
}
