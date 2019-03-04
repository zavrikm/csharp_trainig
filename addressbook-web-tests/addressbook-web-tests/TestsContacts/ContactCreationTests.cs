using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : AuthTestBase
    {
        public static IEnumerable<ContactData> RandomContactDataProvider()
        {
            List<ContactData> contacts = new List<ContactData>();

            for (int i = 0; i < 7; i++)
            {
                contacts.Add(new ContactData(GenerateRandomString(25), GenerateRandomString(25))

                {
                   // FirstName = GenerateRandomString(25),
                    MiddleName = GenerateRandomString(25),
                  //  LastName = GenerateRandomString(25),
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
                });

                contacts[i].BDay = GenerateRandomDay(GetMonthNumber(contacts[i].BMonth), contacts[i].BYear);
                contacts[i].ADay = GenerateRandomDay(GetMonthNumber(contacts[i].AMonth), contacts[i].AYear);

            }

            return contacts;
        }

        public static IEnumerable<ContactData> ContactDataFromXmlFile()
        {
           return (List<ContactData>)
                new XmlSerializer(typeof(List<ContactData>)).Deserialize(new StreamReader(@"contacts.xml"));
        }

        public static IEnumerable<ContactData> ContactDataFromJsonFile()
        {
            return JsonConvert.DeserializeObject<List<ContactData>>(
                    File.ReadAllText(@"contacts.json")
                );
        }

        [Test, TestCaseSource("ContactDataFromJsonFile")]
        public void ContactCreationTest(ContactData contact)
        {
            List<ContactData> oldContacts = app.Contacts.GetContactsList();

            app.Contacts.Create(contact);

            Assert.AreEqual(oldContacts.Count + 1, app.Contacts.GetContactCount(), "1-я проверка");

            List<ContactData> newContacts = app.Contacts.GetContactsList();

            oldContacts.Add(contact);
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts, "2-я проверка");
        }

        [Test]
        public void TestDBConnectivityContacts()
        {
            DateTime start = DateTime.Now;
            List<ContactData> fromUi = app.Contacts.GetContactsList();
            DateTime end = DateTime.Now;
            Console.WriteLine("Ui: " + end.Subtract(start));

            start = DateTime.Now;
            List<ContactData> fromDb = ContactData.GetAllContacts();
            end = DateTime.Now;
            Console.WriteLine("DB: " + end.Subtract(start));

        }












    }
}
