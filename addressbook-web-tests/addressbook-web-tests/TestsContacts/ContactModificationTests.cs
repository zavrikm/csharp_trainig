﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            

            ContactData contact = new ContactData();
            contact.FirstName = "Antony";
            contact.MiddleName = "Alen";
            contact.LastName = "Cramer";
            contact.NickName = "antonyc";
            contact.Title = "Mr";
            contact.Company = "Some company";
            contact.Address1 = "Some address";
            contact.HomePhone1 = "123456";
            contact.MobilePhone = "123456789";
            contact.WorkPhone = null;
            contact.Email1 = "antonyc@domain.dn";
            contact.BDay = "15";
            contact.BMonth = "April";
            contact.BYear = "1982";
            contact.Address2 = "Secondary address";

            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts
                .CreateIfNoOneContactExists()
                .Modify(0,contact);

            List<ContactData> newContacts = app.Contacts.GetContactsList();

            oldContacts[0].FirstName = contact.FirstName;
            oldContacts[0].LastName = contact.LastName;

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);
        }


    }
}
