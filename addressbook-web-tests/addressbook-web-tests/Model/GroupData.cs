using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData : IEquatable <GroupData>, IComparable<GroupData>
    {


        public GroupData(string name) // constructor
        {
            Name = name;
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
            return "name= " + Name;
        }

        public int CompareTo(GroupData other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            return Name.CompareTo(other.Name);
        }

        public string Name { get; set; } // property

        public string Header { get; set; }

        public string Footer { get; set; }

        public string Id { get; set; }
    }
}
