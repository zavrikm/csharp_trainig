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

            return this.ToString().CompareTo(other.ToString()); 
        }


        public string Notes
        {
            get
            {
                return notes;
            }

            set
            {
                notes = value;
            }
        }

        public string HomePhone2
        {
            get
            {
                return homePhone2;
            }

            set
            {
                homePhone2 = value;
            }
        }

        public string Address2
        {
            get
            {
                return address2;
            }

            set
            {
                address2 = value;
            }
        }

        public string GroupName
        {
            get
            {
                return groupName;
            }

            set
            {
                groupName = value;
            }
        }

        public string AYear
        {
            get
            {
                return aYear;
            }

            set
            {
                aYear = value;
            }
        }

        public string AMonth
        {
            get
            {
                return aMonth;
            }

            set
            {
                aMonth = value;
            }
        }

        public string ADay
        {
            get
            {
                return aDay;
            }

            set
            {
                aDay = value;
            }
        }

        public string BYear
        {
            get
            {
                return bYear;
            }

            set
            {
                bYear = value;
            }
        }

        public string BMonth
        {
            get
            {
                return bMonth;
            }

            set
            {
                bMonth = value;
            }
        }

        public string BDay
        {
            get
            {
                return bDay;
            }

            set
            {
                bDay = value;
            }
        }

        public string HomePage
        {
            get
            {
                return homePage;
            }

            set
            {
                homePage = value;
            }
        }

        public string Email3
        {
            get
            {
                return email3;
            }

            set
            {
                email3 = value;
            }
        }

        public string Email2
        {
            get
            {
                return email2;
            }

            set
            {
                email2 = value;
            }
        }

        public string Email1
        {
            get
            {
                return email1;
            }

            set
            {
                email1 = value;
            }
        }

        public string FaxPhone
        {
            get
            {
                return faxPhone;
            }

            set
            {
                faxPhone = value;
            }
        }

        public string WorkPhone
        {
            get
            {
                return workPhone;
            }

            set
            {
                workPhone = value;
            }
        }

        public string MobilePhone
        {
            get
            {
                return mobilePhone;
            }

            set
            {
                mobilePhone = value;
            }
        }

        public string HomePhone1
        {
            get
            {
                return homePhone1;
            }

            set
            {
                homePhone1 = value;
            }
        }

        public string Address1
        {
            get
            {
                return address1;
            }

            set
            {
                address1 = value;
            }
        }

        public string Company
        {
            get
            {
                return company;
            }

            set
            {
                company = value;
            }
        }

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
            }
        }

        public string Photo
        {
            get
            {
                return photo;
            }

            set
            {
                photo = value;
            }
        }

        public string NickName
        {
            get
            {
                return nickName;
            }

            set
            {
                nickName = value;
            }
        }

        public string LastName
        {
            get
            {
                return lastName;
            }

            set
            {
                lastName = value;
            }
        }

        public string MiddleName
        {
            get
            {
                return middleName;
            }

            set
            {
                middleName = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }

            set
            {
                firstName = value;
            }
        }

    }
}
