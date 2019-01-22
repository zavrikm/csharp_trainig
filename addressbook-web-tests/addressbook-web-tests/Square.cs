using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_web_tests
{
    class Square : Figure
    {
        private int size;

        public Square(int size) // constructor
        {
            this.size = size;
        }

        public int Size // property 
        {
            get
            {
                return size;
            }

            set
            {
                size = value; // value - neyavnaya peremennaya
            }
        }


    }
}
