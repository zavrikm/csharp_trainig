using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;

namespace addressbook_tests_autoit
{
    public class HelperBase
    {
        protected ApplicationManager manager; //для хранения ссылки на менеджера
        protected string WINTITLE;
        protected AutoItX3 aux;

        public HelperBase(ApplicationManager manager) //конструктор
        {
            this.manager = manager;
            this.aux = manager.Aux;
            WINTITLE = ApplicationManager.WINTITLE;

        }
    }
}
