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
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < 5; i++)
            {
                contacts.Add(new ContactData() {

                    FirstName = GenerateRandomString(25),
                    MiddleName = GenerateRandomString(25),
                    LastName = GenerateRandomString(25),
                    NickName = GenerateRandomString(15),
                    Company = GenerateRandomString(25),
                    Title = GenerateContactTitle(),
                    Address1 = GenerateRandomString(50),

                    HomePhone1 = GenerateRandomPhone(),
                    MobilePhone = GenerateRandomPhone(),
                    WorkPhone = GenerateRandomPhone(),
                    FaxPhone = GenerateRandomPhone(),

                    Email1 = GenerateRandomEmail(),
                    Email2 = GenerateRandomEmail(),
                    Email3 = GenerateRandomEmail(),
                    HomePage = GenerateRandomeHomePage(),

                    BYear = GenerateRandomYear(),
                    BMonth = GenerateRandomMonth(),
                    //    BDay = GenerateRandomDay(BMonth.GetMonthNumber(), BYear),                    


                    AYear = GenerateRandomYear(),
                    AMonth = GenerateRandomMonth(),
                 //   ADay = GenerateRandomDay(),

                    Address2 = GenerateRandomString(50),
                    HomePhone2 = GenerateRandomPhone(),
                    Notes = GenerateRandomString(100)
                }
              );

                contacts[i].BDay = GenerateRandomDay(GetMonthNumber(contacts[i].BMonth), contacts[i].BYear);
                contacts[i].ADay = GenerateRandomDay(GetMonthNumber(contacts[i].AMonth), contacts[i].AYear);

            }

            return contacts;
        }


        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactCreationTest(ContactData contact)
        {


            //ContactData contact = new ContactData();
            //contact.FirstName = "Vivian";
            //contact.MiddleName = "Ann";
            //contact.LastName = "Winter";
            //contact.NickName = "vivianw";
            //contact.Title = "Mrs";
            //contact.Company = "Some company";
            //contact.Address1 = "Some address";
            //contact.HomePhone1 = "123456";
            //contact.MobilePhone = "123456789";
            //contact.WorkPhone = "456789";
            //contact.Email1 = "user@domain.dn";
            //contact.BDay = "15";
            //contact.BMonth = "April";
            //contact.BYear = "1982";
            //contact.Address2 = "Secondary address";


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
