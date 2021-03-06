﻿using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using System.Linq;
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


        public static IEnumerable<GroupData> GroupDataFromCsvFile()
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


        public static IEnumerable<GroupData> GroupDataFromXmlFile()
        {
          //  List<GroupData> groups = new List<GroupData>();

            return (List<GroupData>) 
                new XmlSerializer(typeof(List<GroupData>))
                    .Deserialize(new StreamReader(@"groups.xml"));

        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile()
        {
           return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));

        }


        [Test, TestCaseSource("GroupDataFromCsvFile")]
        public void GroupCreationTest(GroupData group) // 05.03.19 - тест переделан для задания №16
        {

            List<GroupData> oldGroups = GroupData.GetAllGroups(); //у групп не сохраняются копии с deprecated

            app.Groups.Create(group);

            Assert.AreEqual(oldGroups.Count + 1, GroupData.GetAllGroups().Count); //если количество групп не совпало - тест упадет здесь

            List<GroupData> newGroups = GroupData.GetAllGroups();

            oldGroups.Add(group);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }

        [Test]
        public void TestDBConnectivity()
        {
            Console.WriteLine("Test is running");
            foreach (ContactData contact in GroupData.GetAllGroups()[0].GetContactsByGroup())
            {
                Console.WriteLine(contact);
            }

        }

    }

}

