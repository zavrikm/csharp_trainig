﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactRemovalTests : AuthTestBase
    {

        [Test]
        public void ContactRemovalTest()
        {
            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts
                .CreateIfNoOneContactExists()
                .Remove(0);

            Assert.AreEqual(oldContacts.Count - 1, app.Contacts.GetContactCount());

            List<ContactData> newContacts = app.Contacts.GetContactsList();

            ContactData toBeRemoved = oldContacts[0];
            oldContacts.RemoveAt(0);

            Assert.AreEqual(oldContacts, newContacts);

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(toBeRemoved.Id, contact.Id);
            }

        }

        [Test]
        public void ContactRemovalTestWithBD()
        {
            List<ContactData> oldContacts = ContactData.GetAllContacts();

            if (oldContacts.Count == 0)
            {
                app.Contacts.CreateAContact();
                oldContacts = ContactData.GetAllContacts();
            }

            ContactData toBeRemoved = oldContacts[0];

            app.Contacts.RemoveByContactId(toBeRemoved.Id);

            Assert.AreEqual(oldContacts.Count - 1, ContactData.GetAllContacts().Count, "Контакт не удалился");

            List<ContactData> newContacts = ContactData.GetAllContacts();

            oldContacts.RemoveAt(0);

            oldContacts.Sort();
            newContacts.Sort();
            Assert.AreEqual(oldContacts,newContacts,"Списки контактов не совпадают");

            foreach (ContactData contact in newContacts)
            {
                Assert.AreNotEqual(toBeRemoved.Id, contact.Id);
            }

        }

    }
}
