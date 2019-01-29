using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    public class GroupData
    {
        private string name; // field
        private string header = "";
        private string footer = "";

        public GroupData(string name) // constructor
        {
            this.name = name;
        }

        public string Name // property
        {
            get
            {
                return name;
            }

            set
            {
                name = value;
            }
        }

        public string Header
        {
            get
            {
                return header;
            }

            set
            {
                this.header = value;
            }
        }

        public string Footer
            {
                get
                  {
                return footer;
                  }

                set
                {
                footer = value;
                }
            }
    }
}
