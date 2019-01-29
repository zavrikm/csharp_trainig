using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.GoToContactCreationPage();

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

            app.Contacts.FillContactCreationForm(contact);
            app.Contacts.SubmitContactCreation();
            app.Auth.Logout();
        }

 











 
    }
}
