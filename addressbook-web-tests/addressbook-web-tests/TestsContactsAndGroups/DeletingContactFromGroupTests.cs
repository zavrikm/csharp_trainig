using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class DeletingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void DeleteContactFromGroupTest() // Для ДЗ №17 - тест удаления контакта из группы
        {
            List<GroupData> groupList = GroupData.GetAllGroups(); //обеспечиваем наличие хотя бы одной группы

            if (groupList.Count < 1)
            {
                app.Groups.CreateAGroup();
                groupList = GroupData.GetAllGroups();
            }

            GroupData testGroup = groupList[0]; // установили тестовую группу


            if (testGroup.GetContactsByGroup().Count < 1) //обеспечиваем наличие хотя бы одного контакта в группе
            {

                if (ContactData.GetAllContacts().Count < 1)
                {
                    app.Contacts.CreateAContact();
                }

                app.Contacts.AddContactToGroup(ContactData.GetAllContacts().First(), testGroup);  
            }

            List<ContactData> oldContacts = testGroup.GetContactsByGroup();
            ContactData contact = oldContacts[0]; //контакт, который будем удалять

            app.Contacts.DeleteContactFromGroup(contact, testGroup);

            List<ContactData> newContacts = testGroup.GetContactsByGroup();

            Assert.AreEqual(oldContacts.Count - 1, newContacts.Count); //если контакт не удалился - тест упадет здесь

            oldContacts.RemoveAt(0);

            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);

        }
    }
}
