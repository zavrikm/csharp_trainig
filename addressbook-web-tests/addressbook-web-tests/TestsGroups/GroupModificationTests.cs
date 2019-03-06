using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        //[Test]

        //public void GroupModificationTest()
        //{


        //    GroupData newData = new GroupData("bbb"); //newData for modifying
        //    newData.Header = null;
        //    newData.Footer = null;

        //    //   List<GroupData> oldGroups = app.Groups.GetGroupList();

        //    List<GroupData> oldGroups = GroupData.GetAllGroups();

        //    GroupData oldData = oldGroups[0];

        //    app.Groups
        //        .CreateIfNoOneGroupExists()
        //        .Modify(0,newData);

        //    //Assert.AreEqual(oldGroups.Count, app.Groups.GetGroupCount()); //если количество групп не совпало - тест упадет здесь
        //    Assert.AreEqual(oldGroups.Count, GroupData.GetAllGroups().Count); //если количество групп не совпало - тест упадет здесь

        //    //  List<GroupData> newGroups = app.Groups.GetGroupList();

        //    List<GroupData> newGroups = GroupData.GetAllGroups();

        //    oldGroups[0].Name = newData.Name;
        //    oldGroups.Sort();
        //    newGroups.Sort();
        //    Assert.AreEqual(oldGroups, newGroups);

        //    foreach (GroupData group in newGroups)
        //    {
        //        if (group.Id == oldData.Id)
        //        {
        //            Assert.AreEqual(newData.Name, group.Name);
        //        }
        //    }

        //}


        [Test]

        public void GroupModificationTest()
        {


            GroupData newData = new GroupData("bbb"); //newData for modifying
            newData.Header = null;
            newData.Footer = null;

            List<GroupData> oldGroups = GroupData.GetAllGroups();

            GroupData oldData = oldGroups[0];

            app.Groups
                .CreateIfNoOneGroupExists()
                .Modify(Int32.Parse(oldData.Id), newData); //модифицируем первую группу из списка, полученного из базы

            Assert.AreEqual(oldGroups.Count, GroupData.GetAllGroups().Count); //если количество групп не совпало - тест упадет здесь

            //  List<GroupData> newGroups = app.Groups.GetGroupList();

            List<GroupData> newGroups = GroupData.GetAllGroups();

            oldGroups[0].Name = newData.Name;
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);

            foreach (GroupData group in newGroups)
            {
                if (group.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Name, group.Name);
                }
            }

        }

    }
}
