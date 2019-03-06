using System;
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
        //[Test]
        //public void ContactModificationTest()
        //{


        //    ContactData contact = new ContactData();
        //    contact.FirstName = "Antony";
        //    contact.MiddleName = "Alen";
        //    contact.LastName = "Cramer";
        //    contact.NickName = "antonyc";
        //    contact.Title = "Mr";
        //    contact.Company = "Some company";
        //    contact.Address1 = "Some address";
        //    contact.HomePhone1 = "123456";
        //    contact.MobilePhone = "123456789";
        //    contact.WorkPhone = null;
        //    contact.Email1 = "antonyc@domain.dn";
        //    contact.BDay = "15";
        //    contact.BMonth = "April";
        //    contact.BYear = "1982";
        //    contact.Address2 = "Secondary address";

        //    List<ContactData> oldContacts = app.Contacts.GetContactsList();
        //    ContactData oldData = oldContacts[0];

        //    app.Contacts
        //        .CreateIfNoOneContactExists()
        //        .Modify(0,contact);

        //    Assert.AreEqual(oldContacts.Count, app.Contacts.GetContactCount());

        //    List<ContactData> newContacts = app.Contacts.GetContactsList();

        //    oldContacts[0].FirstName = contact.FirstName;
        //    oldContacts[0].LastName = contact.LastName;

        //    oldContacts.Sort();
        //    newContacts.Sort();

        //    Assert.AreEqual(oldContacts, newContacts);



        //    foreach (ContactData inscription in newContacts)
        //    {
        //        if (inscription.Id == oldData.Id)
        //        {
        //            Assert.IsTrue((contact.FirstName == inscription.FirstName)&&(contact.LastName == inscription.LastName));
        //        }
        //    }

        //}


        [Test]
        public void ContactModificationTest() // 06.03.19 - для ДЗ №16 переделан тест - теперь с обращением к БД
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

            List<ContactData> oldContacts = ContactData.GetAllContacts();

            if (oldContacts.Count == 0)
            {
                app.Contacts.CreateAContact();
                oldContacts = ContactData.GetAllContacts();
            }

            ContactData oldData = oldContacts[0];

            app.Contacts.ModifyByContactId(Int32.Parse(oldData.Id), contact);

            Assert.AreEqual(oldContacts.Count, ContactData.GetAllContacts().Count);

            List<ContactData> newContacts = ContactData.GetAllContacts();

            oldContacts[0].FirstName = contact.FirstName;
            oldContacts[0].LastName = contact.LastName;

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);



            foreach (ContactData inscription in newContacts)
            {
                if (inscription.Id == oldData.Id)
                {
                    Assert.IsTrue((contact.FirstName == inscription.FirstName) && (contact.LastName == inscription.LastName));
                }
            }

        }


    }
}
