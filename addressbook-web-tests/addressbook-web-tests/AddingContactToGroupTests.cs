using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : AuthTestBase
    {
        [Test]
        public void TestAddingContactToGroup()
        {
            GroupData group = GroupData.GetAllGroups()[0]; //1-я группа из имеющихся
            List<ContactData> oldList = group.GetContactsByGroup(); //список контактов в этой группе до добавления
            ContactData contact = ContactData.GetAllContacts().Except(group.GetContactsByGroup()).First(); //1-й контакт в списке не входящих в 1-ю группу контактов

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactData> newList = group.GetContactsByGroup();

            oldList.Add(contact);

            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList,newList);
        }

    }
}
