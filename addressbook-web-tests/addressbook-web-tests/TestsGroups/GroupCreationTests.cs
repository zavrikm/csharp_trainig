﻿using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase

    {
        public static IEnumerable<GroupData> RandomGroupDataProvider()
        {
            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < 5; i++)
            {
                groups.Add(new GroupData(GenerateRandomString(30))
                        { Header = GenerateRandomString(100),
                          Footer = GenerateRandomString(100)
                });
            }

            return groups;
        }


        public static IEnumerable<GroupData> GroupDataFromFile()
        {
            List<GroupData> groups = new List<GroupData>();
            string[] lines = File.ReadAllLines(@"groups.csv");

            foreach (string l in lines)
            {
                string[] parts = l.Split(',');
                groups.Add(new GroupData(parts[0])
                {
                    Header = parts[1],
                    Footer = parts[2]
                });
            }

            return groups;
        }



        [Test, TestCaseSource("GroupDataFromFile")]
        public void GroupCreationTest(GroupData group)
        {           
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1,app.Groups.GetGroupCount()); //если количество групп не совпало - тест упадет здесь

            List <GroupData> newGroups = app.Groups.GetGroupList();
            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }


    }

}

