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

            app.Contacts
                .CreateIfNoOneContactExists()
                .Modify(1,contact);

        }


    }
}
