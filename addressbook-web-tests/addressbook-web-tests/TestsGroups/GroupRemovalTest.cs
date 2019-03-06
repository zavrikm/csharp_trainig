using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {


        [Test]
        public void GroupRemovalTest() // old test
        {
              List<GroupData> oldGroups = app.Groups.GetGroupList();

            app.Groups
                .CreateIfNoOneGroupExists()
                .Remove(0);

            Assert.AreEqual(oldGroups.Count - 1, app.Groups.GetGroupCount()); //если количество групп не совпало - тест упадет здесь

            List<GroupData> newGroups = app.Groups.GetGroupList();

            GroupData toBeRemoved = oldGroups[0];
            oldGroups.RemoveAt(0);
            Assert.AreEqual(oldGroups, newGroups);


            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

        }

        [Test]

        public void GroupRemovalTestWithDB() // 6.03.19 - новый тест для ДЗ №16
        {
            List<GroupData> oldGroups = GroupData.GetAllGroups();

            if (oldGroups.Count == 0)
            {
                app.Groups.CreateAGroup();
                oldGroups = GroupData.GetAllGroups();
            }

            GroupData toBeRemoved = oldGroups[0];

            app.Groups.RemoveGroupById(Int32.Parse(toBeRemoved.Id));

                Assert.AreEqual(oldGroups.Count - 1, GroupData.GetAllGroups().Count); //если количество групп не совпало - тест упадет здесь

            List<GroupData> newGroups = GroupData.GetAllGroups();

            oldGroups.RemoveAt(0);

            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                Assert.AreNotEqual(group.Id, toBeRemoved.Id);
            }

        }

    }
}
