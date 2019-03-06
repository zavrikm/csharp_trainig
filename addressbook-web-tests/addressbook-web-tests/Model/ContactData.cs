using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "addressbook")]
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string allPhones;
        private string allEmails;
        private string allInfoToString;

        public ContactData()
        {
            // no required fields in addressbook
        }

        public ContactData(string firestName, string lastName)
        {
            FirstName = firestName;
            LastName = lastName;
        }


        public bool Equals(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }

            return (FirstName == other.FirstName) && (LastName == other.LastName);
        }

        public override int GetHashCode()
        {
            return FirstName.GetHashCode() + LastName.GetHashCode();
        }

        public override string ToString()
        {
            return "FirstName LastName= " + FirstName + " " + LastName;
        }

        public int CompareTo(ContactData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            if (LastName.CompareTo(other.LastName) == 0)
            {
                return FirstName.CompareTo(other.FirstName);
            }

            return LastName.CompareTo(other.LastName);

        }

        [Column(Name = "notes")]
        public string Notes { get; set; }

        [Column(Name = "phone2")]
        public string HomePhone2 { get; set; }

        [Column(Name = "address2")]
        public string Address2 { get; set; }

       // в базе нет колонки для названия группы
        public string GroupName { get; set; }

        [Column(Name = "ayear")]
        public string AYear { get; set; }

        [Column(Name = "amonth")]
        public string AMonth { get; set; }

        [Column(Name = "aday")]
        public string ADay { get; set; }

        [Column(Name = "byear")]
        public string BYear { get; set; }

        [Column(Name = "bmonth")]
        public string BMonth { get; set; }

        [Column(Name = "bday")]
        public string BDay { get; set; }

        [Column(Name = "homepage")]
        public string HomePage { get; set; }

        [Column(Name = "email3")]
        public string Email3 { get; set; }

        [Column(Name = "email2")]
        public string Email2 { get; set; }

        [Column(Name = "email")]
        public string Email1 { get; set; }

        [Column(Name = "fax")]
        public string FaxPhone { get; set; }

        [Column(Name = "work")]
        public string WorkPhone { get; set; }

        [Column(Name = "mobile")]
        public string MobilePhone { get; set; }

        [Column(Name = "home")]
        public string HomePhone1 { get; set; }

        [Column(Name = "address")]
        public string Address1 { get; set; }

        [Column(Name = "company")]
        public string Company { get; set; }

        [Column(Name = "title")]
        public string Title { get; set; }

        [Column(Name = "photo")]
        public string Photo { get; set; }

        [Column(Name = "nickname")]
        public string NickName { get; set; }

        [Column(Name = "lastname")]
        public string LastName { get; set; }

        [Column(Name = "middlename")]
        public string MiddleName { get; set; }

        [Column(Name = "firstname")]
        public string FirstName { get; set; }

        [Column(Name = "id"), PrimaryKey]
        public string Id { get; set; }

        [Column(Name = "deprecated")]
        public string Deprecated { get; set; }

        public string AllPhones
        {
            get
            {
                if (allPhones != null)
                {

                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomePhone1) + CleanUp(MobilePhone) + CleanUp(WorkPhone) + CleanUp(HomePhone2)).Trim();
                }

            }
            set
            {
                allPhones = value;
            }
        }



        private string CleanUp(string phone)
        {
            if (phone == null || phone == "")
            {
                return "";
            }
            // return phone.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")","") + "\r\n";
            return Regex.Replace(phone, "[ -()]", "") + "\r\n";
        }

        [JsonIgnore]
        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    allEmails = "";

                    if (Email1 != "")
                    {
                        allEmails = Email1;
                    }

                    if (Email2 != "")
                    {
                        if (allEmails == "")
                        {
                            allEmails = Email2;
                        }
                        else
                        {
                            allEmails = allEmails + "\r\n" + Email2;
                        }
                    }

                    if (Email3 != "")
                    {
                        if (allEmails == "")
                        {
                            allEmails = Email3;
                        }
                        else
                        {
                            allEmails = allEmails + "\r\n" + Email3;
                        }
                    }

                    return allEmails.Trim();
                }
            }
            set
            {
                allEmails = value;
            }
        }

        [JsonIgnore]
        public string AllInfoToString
        {
            get
            {
                //    if (allInfoToString != null)
                //    {
                return AllInfoToString;
                //    }
                //    else
                //    {
                //        allInfoToString = "";

                //        if (FirstName != "")
                //        { allInfoToString = allInfoToString + FirstName; }

                //        if (MiddleName != "") //****************** MIddleName ****************
                //        {
                //            if (allInfoToString == "")
                //            {
                //                allInfoToString = MiddleName;
                //            }
                //            else
                //            {
                //                allInfoToString = allInfoToString + " " + MiddleName;
                //            }
                //        }

                //        if (LastName != "") //****************** LastName ****************
                //        {
                //            if (allInfoToString == "")
                //            {
                //                allInfoToString = LastName;
                //            }
                //            else
                //            {
                //                allInfoToString = allInfoToString + " " + LastName;
                //            }
                //        }

                //        if (NickName != "") //****************** NickName ****************
                //        {
                //            if (allInfoToString == "")
                //            {
                //                allInfoToString = NickName;
                //            }
                //            else
                //            {
                //                allInfoToString = allInfoToString + "\r\n" + NickName;
                //            }
                //        }

                //        if (Title != "") //****************** Title ****************
                //        {
                //            if (allInfoToString == "")
                //            {
                //                allInfoToString = Title;
                //            }
                //            else
                //            {
                //                allInfoToString = allInfoToString + "\r\n" + Title;
                //            }
                //        }

                //        if (Company != "") //****************** Company ****************
                //        {
                //            if (allInfoToString == "")
                //            {
                //                allInfoToString = Company;
                //            }
                //            else
                //            {
                //                allInfoToString = allInfoToString + "\r\n" + Company;
                //            }
                //        }


                //        if (Address1 != "") //****************** Address1 ****************
                //        {
                //            if (allInfoToString == "")
                //            {
                //                allInfoToString = Address1;
                //            }
                //            else
                //            {
                //                allInfoToString = allInfoToString + "\r\n" + Address1;
                //            }
                //        }

                //        //*********************** \r\n *****************************************

                //        if ((allInfoToString != "") && (HomePhone1 != "" || MobilePhone != "" || WorkPhone != "" || FaxPhone != ""))
                //        {
                //            allInfoToString = allInfoToString + "\r\n";
                //        }

                //        //************************************** PHONES ******************************************************************************

                //        if (HomePhone1 != "") //****************** HomePhone1 ****************
                //        {
                //            if (allInfoToString == "")
                //            {
                //                allInfoToString = "H: " + HomePhone1;
                //            }
                //            else
                //            {
                //                allInfoToString = allInfoToString + "\r\nH: " + HomePhone1;
                //            }
                //        }

                //        if (MobilePhone != "") //****************** MobilePhone ****************
                //        {
                //            if (allInfoToString == "")
                //            {
                //                allInfoToString = "M: " + MobilePhone;
                //            }
                //            else
                //            {
                //                allInfoToString = allInfoToString + "\r\nM: " + MobilePhone;
                //            }
                //        }

                //        if (WorkPhone != "") //****************** WorkPhone ****************
                //        {
                //            if (allInfoToString == "")
                //            {
                //                allInfoToString = "W: " + WorkPhone;
                //            }
                //            else
                //            {
                //                allInfoToString = allInfoToString + "\r\nW: " + WorkPhone;
                //            }
                //        }

                //        if (FaxPhone != "") //****************** FaxPhone ****************
                //        {
                //            if (allInfoToString == "")
                //            {
                //                allInfoToString = "F: " + FaxPhone;
                //            }
                //            else
                //            {
                //                allInfoToString = allInfoToString + "\r\nF: " + FaxPhone;
                //            }
                //        }

                //        //*********************** \r\n *****************************************

                //        if ((allInfoToString != "") && (Email1 != "" || Email2 != "" || Email3 != "" || HomePage != ""))
                //        {
                //            allInfoToString = allInfoToString + "\r\n";
                //        }

                //        //********************************** Emails ***************************************************

                //        if (Email1 != "") //****************** Email1 ****************
                //        {
                //            if (allInfoToString == "")
                //            {
                //                allInfoToString = Email1;
                //            }
                //            else
                //            {
                //                allInfoToString = allInfoToString + "\r\n" + Email1;
                //            }
                //        }

                //        if (Email2 != "") //****************** Email2 ****************
                //        {
                //            if (allInfoToString == "")
                //            {
                //                allInfoToString = Email2;
                //            }
                //            else
                //            {
                //                allInfoToString = allInfoToString + "\r\n" + Email2;
                //            }
                //        }

                //        if (Email3 != "") //****************** Email3 ****************
                //        {
                //            if (allInfoToString == "")
                //            {
                //                allInfoToString = Email3;
                //            }
                //            else
                //            {
                //                allInfoToString = allInfoToString + "\r\n" + Email3;
                //            }
                //        }

                //        if (HomePage != "") //****************** Email1 ****************
                //        {
                //            if (allInfoToString == "")
                //            {
                //                allInfoToString = "Homepage:\r\n" + HomePage;
                //            }
                //            else
                //            {
                //                allInfoToString = allInfoToString + "\r\nHomepage:\r\n" + HomePage;
                //            }
                //        }

                //        //*********************** \r\n *****************************************

                //        if ((allInfoToString != "") && (BDay != "0" || BMonth != "-" || BYear != "" || ADay != "0" || AMonth != "-" || AYear != ""))
                //        {
                //            allInfoToString = allInfoToString + "\r\n";
                //        }

                //        //***************************************************** DATES ******************************************************

                //        if (BDay != "0" || BMonth != "-" || BYear != "")
                //        {
                //            allInfoToString = allInfoToString + "\r\nBirthday";

                //            if (BDay != "0")
                //            {
                //                allInfoToString = allInfoToString + " " + BDay + ".";
                //            }
                //            if (BMonth != "-")
                //            {
                //                allInfoToString = allInfoToString + " " + BMonth;
                //            }
                //            if (BYear != "")
                //            {
                //                allInfoToString = allInfoToString + " " + BYear + " (" + Age(Int32.Parse(BYear), GetMonthNumber(BMonth), Int32.Parse(BDay)) + ")"; // AGE!!!!! 
                //            }

                //        }

                //        if (ADay != "0" || AMonth != "-" || AYear != "")
                //        {
                //            allInfoToString = allInfoToString + "\r\nAnniversary";

                //            if (ADay != "0")
                //            {
                //                allInfoToString = allInfoToString + " " + ADay + ".";
                //            }
                //            if (AMonth != "-")
                //            {
                //                allInfoToString = allInfoToString + " " + AMonth;
                //            }
                //            if (AYear != "")
                //            {
                //                allInfoToString = allInfoToString + " " + AYear + " (" + Age(Int32.Parse(AYear), GetMonthNumber(AMonth), Int32.Parse(ADay)) + ")"; // AGE!!!!! 
                //            }

                //        }
                //        //********************* SECONDARY *********************************************************************

                //        if (Address2 != "") //****************** Address2 ****************
                //        {
                //            if (allInfoToString == "")
                //            {
                //                allInfoToString = Address2;
                //            }
                //            else
                //            {
                //                allInfoToString = allInfoToString + "\r\n\r\n" + Address2;
                //            }
                //        }

                //        if (HomePhone2 != "") //****************** HomePhone2 ****************
                //        {
                //            if (allInfoToString == "")
                //            {
                //                allInfoToString = HomePhone2;
                //            }
                //            else
                //            {
                //                allInfoToString = allInfoToString + "\r\n\r\nP: " + HomePhone2;
                //            }
                //        }

                //        if (Notes != "") //****************** Notes ****************
                //        {
                //            if (allInfoToString == "")
                //            {
                //                allInfoToString = Notes;
                //            }
                //            else
                //            {
                //                allInfoToString = allInfoToString + "\r\n\r\n" + Notes;
                //            }
                //        }

                //        return allInfoToString;
                //    }
            }
            set
            {
                AllInfoToString = value;
            }
        }

        public int Age(int cYear, int cMonth, int cDay)
        {
            DateTime dateNow = DateTime.Now;
            int age = dateNow.Year - cYear;

            if (cDay != 0 && cMonth != 0)
            {

                if (dateNow.Month < cMonth || (dateNow.Month == cMonth && dateNow.Day < cDay))
                {
                    age--;
                }

                return age;
            }

            if (cDay == 0 && cMonth != 0)
            {
                if (dateNow.Month < cMonth)
                {
                    age--;
                }

                return age;
            }

            return age;
        }

        public int GetMonthNumber(string month)
        {
            if(month == "-") { return 0; };
            if (month == "January") { return 1; };
            if (month == "February") { return 2; };
            if (month == "March") { return 3; };
            if (month == "April") { return 4; };
            if (month == "May") { return 5; };
            if (month == "June") { return 6; };
            if (month == "July") { return 7; };
            if (month == "August") { return 8; };
            if (month == "September") { return 9; };
            if (month == "October") { return 10; };
            if (month == "November") { return 11; };
            return 12;
        }

        public static List<ContactData> GetAllContacts()
        {
             using (AddressbookDb db = new AddressbookDb())
            {
                return (from c in db.Contacts.Where(x => x.Deprecated == "0000-00-00 00:00:00") select c).ToList();
            }
        }


    }
}
