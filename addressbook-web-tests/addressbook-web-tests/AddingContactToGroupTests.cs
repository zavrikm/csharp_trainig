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

        [Test]

        public void TestAddingContactToDifferentGroups() // 7.03.19 - для ДЗ №17 - добавление контакта в разные группы
        {
            List<GroupData> allGroups = GroupData.GetAllGroups();

            while (allGroups.Count < 2)
            {
                app.Groups.CreateAGroup();
                allGroups = GroupData.GetAllGroups();
            }

            List<GroupData> controlList = new List<GroupData>();
            controlList.Add(allGroups[0]);
            controlList.Add(allGroups[allGroups.Count - 1]);

            ContactData contact = ContactData.GetAllContacts().Except(controlList[0].GetContactsByGroup()).Except(controlList[1].GetContactsByGroup()).First();

            app.Contacts.AddContactToGroup(contact, controlList[0]);
            app.Contacts.AddContactToGroup(contact, controlList[1]);

            List<GroupData> testList = contact.GetGroupsByContact();

            controlList.Sort();
            testList.Sort();

            Assert.AreEqual(controlList,testList);
        }

    }
}
