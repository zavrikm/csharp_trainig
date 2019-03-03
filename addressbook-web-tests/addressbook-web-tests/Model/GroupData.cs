using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LinqToDB.Mapping;

namespace WebAddressbookTests
{
    [Table(Name = "group_list")]
    public class GroupData : IEquatable <GroupData>, IComparable<GroupData>
    {


        public GroupData(string name) // constructor
        {
            Name = name;
        }

        public GroupData() // constructor
        {

        }

        public bool Equals(GroupData other)
        {
            if (Object.ReferenceEquals(other, null)) //если other == null, вернуть false - стандартная проверка объектов
            {
                return false;
            }

            if (Object.ReferenceEquals(this, other)) //если объект сравнивается сам с собой (та же сущность) - вернуть true - стандартная проверка объектов
            {
                return true;
            }

            return Name == other.Name;
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }

        public override string ToString()
        {
            return "name= " + Name + "\nHeader = " + Header + "\nFooter = " + Footer;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return Name.CompareTo(other.Name);
        }

        [Column(Name = "group_name")]
        public string Name { get; set; } // property

        [Column(Name = "group_header")]
        public string Header { get; set; }

        [Column(Name = "group_footer")]
        public string Footer { get; set; }

        [Column(Name = "group_footer"), PrimaryKey, Identity]
        public string Id { get; set; }

        public static List<GroupData> GetAll() //извлекам все данные по группам из БД
        {
            using (AddressbookDb db = new AddressbookDb())
            {
                return (from g in db.Groups select g).ToList();
            }

        }
    }
}
