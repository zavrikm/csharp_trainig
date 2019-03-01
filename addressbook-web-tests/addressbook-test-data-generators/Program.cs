using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebAddressbookTests;

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = Convert.ToInt32(args[0]); //количество строк
            StreamWriter writer = new StreamWriter(args[1]); // адрес файла
            string format = args[2]; //для формата файла записи
            string item = args[3]; //параметр для указания - contacts или groups



            if (item == "groups") // ****************** GROUPS **************************
            {
                List<GroupData> groups = new List<GroupData>();

                AddGroupsToList(groups, count);

                if (format == "csv")
                {
                    WriteGroupsToCsvFile(groups, writer);
                }
                else if (format == "xml")
                {
                    WriteGroupsToXmlFile(groups, writer);
                }
                else if (format == "json")
                {
                    WriteGroupsToJsonFile(groups, writer);
                }
                else
                {
                    Console.WriteLine("Unrecognized format " + format);
                }
            }
            else if (item == "contacts") //************************ CONTACTS *********************
            {
                List<ContactData> contacts = new List<ContactData>();

                AddContactsToList(contacts, count);

                if (format == "xml")
                {
                    WriteContactsToXmlFile(contacts, writer);
                }
                else if (format == "json")
                {
                    WriteContactsToJsonFile(contacts, writer);
                }
                else
                {
                    Console.WriteLine("Unrecognized format " + format);
                }

            }
            else //********************** OTHER ***************************************
            {
                Console.WriteLine("Unrecognized item " + item);
            }
          
            writer.Close();
        }

        #region MethodsForGroups

        static void AddGroupsToList(List<GroupData> groups, int count)
        {
            for (int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GenerateRandomString(10))
                {
                    Header = TestBase.GenerateRandomString(10),
                    Footer = TestBase.GenerateRandomString(10)
                });
            }
        }

        static void WriteGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}", 
                    group.Name, group.Header, group.Footer));
            }
        }

        static void WriteGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer,groups); 
        }


        static void WriteGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented));
        }

        #endregion

        #region MethodsForContacts

        static void AddContactsToList(List<ContactData> contacts, int count)
        {

            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactData(TestBase.GenerateRandomString(25), TestBase.GenerateRandomString(25))

                {
                    //MiddleName = TestBase.GenerateRandomString(25),
                    //NickName = TestBase.GenerateRandomString(15),
                    //Company = TestBase.GenerateRandomString(25),
                    //Title = TestBase.GenerateContactTitle(),
                    //Address1 = TestBase.GenerateRandomString(50),

                    //HomePhone1 = TestBase.GenerateRandomPhone(),
                    //MobilePhone = TestBase.GenerateRandomPhone(),
                    //WorkPhone = TestBase.GenerateRandomPhone(),
                    //FaxPhone = TestBase.GenerateRandomPhone(),

                    //Email1 = TestBase.GenerateRandomEmail(),
                    //Email2 = TestBase.GenerateRandomEmail(),
                    //Email3 = TestBase.GenerateRandomEmail(),
                    //HomePage = TestBase.GenerateRandomeHomePage(),

                    //BYear = TestBase.GenerateRandomYear(),
                    //BMonth = TestBase.GenerateRandomMonth(),

                    //AYear = TestBase.GenerateRandomYear(),
                    //AMonth = TestBase.GenerateRandomMonth(),

                    //Address2 = TestBase.GenerateRandomString(50),
                    //HomePhone2 = TestBase.GenerateRandomPhone(),
                    //Notes = TestBase.GenerateRandomString(100)
                });

                //  contacts[i].BDay = TestBase.GenerateRandomDay(TestBase.GetMonthNumber(contacts[i].BMonth), contacts[i].BYear);
                //  contacts[i].ADay = TestBase.GenerateRandomDay(TestBase.GetMonthNumber(contacts[i].AMonth), contacts[i].AYear);

            }

        }

        static void WriteContactsToXmlFile(List<ContactData> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactData>)).Serialize(writer, contacts);
        }

        static void WriteContactsToJsonFile(List<ContactData> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented));
        }

        #endregion


    }
}
