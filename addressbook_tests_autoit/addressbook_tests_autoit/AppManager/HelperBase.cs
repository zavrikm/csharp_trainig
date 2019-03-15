using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace addressbook_tests_autoit
{
    public class HelperBase
    {
        protected ApplicationManager manager; //для хранения ссылки на менеджера

        public HelperBase(ApplicationManager manager) //конструктор
        {
            this.manager = manager;
        }
    }
}
