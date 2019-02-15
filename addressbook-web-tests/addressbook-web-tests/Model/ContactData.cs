using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class ContactData : IEquatable<ContactData>, IComparable<ContactData>
    {
        private string firstName = "";
        private string middleName = "";
        private string lastName = "";
        private string nickName = "";
        private string photo = "";
        private string title = "";
        private string company = "";
        private string address1 = "";
        private string homePhone1 = "";
        private string mobilePhone = "";
        private string workPhone = "";
        private string faxPhone = "";
        private string email1 = "";
        private string email2 = "";
        private string email3 = "";
        private string homePage = "";
        private string bDay;
        private string bMonth = "";
        private string bYear = "";
        private string aDay = "";
        private string aMonth = "";
        private string aYear = "";
        private string groupName = "";
        private string address2 = "";
        private string homePhone2 = "";
        private string notes = "";


        public ContactData()
        {
            // no required fields in addressbook
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


        public string Notes { get; set; }

        public string HomePhone2 { get; set; }


        public string Address2 { get; set; }


        public string GroupName { get; set; }

        public string AYear { get; set; }

        public string AMonth { get; set; }

        public string ADay { get; set; }

        public string BYear { get; set; }

        public string BMonth { get; set; }

        public string BDay { get; set; }

        public string HomePage { get; set; }


        public string Email3 { get; set; }

        public string Email2 { get; set; }

        public string Email1 { get; set; }

        public string FaxPhone { get; set; }

        public string WorkPhone { get; set; }

        public string MobilePhone { get; set; }

        public string HomePhone1 { get; set; }

        public string Address1 { get; set; }

        public string Company { get; set; }

        public string Title { get; set; }

        public string Photo { get; set; }

        public string NickName { get; set; }

        public string LastName { get; set; }

        public string MiddleName { get; set; }

        public string FirstName { get; set; }

        public string Id { get; set; }

    }
}
