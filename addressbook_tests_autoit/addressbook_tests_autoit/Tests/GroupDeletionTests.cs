using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupDeletionTests : TestBase
    {
        [Test]
        public void TestGroupDeletion()
        {
            List<GroupData> oldGroups = app.Groups.GetGroupList();

            if (oldGroups.Count < 2) // приложение пишет, что всегда должна быть минимум одна группа
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "test"
                };

                app.Groups.Add(newGroup);
                oldGroups = app.Groups.GetGroupList();
            }


            GroupData toBeDeleted = oldGroups[0];

            app.Groups.DeleteFirstGroup();

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.RemoveAt(0);
            oldGroups.Sort();
            newGroups.Sort();

            Assert.AreEqual(oldGroups,newGroups);
        }
    }
}
