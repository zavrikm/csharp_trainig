﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoItX3Lib;


namespace addressbook_tests_autoit
{
    public class ApplicationManager
    {
        public static string WINTITLE = "Free Address Book";
        private AutoItX3 aux;
        private GroupHelper groupHelper; //для хранения ссылки на груп-хелпер

        public ApplicationManager()
        {
            aux = new AutoItX3();
            aux.Run(@"D:\Software-testing\AddressBookPortable\AddressBook.exe", "", aux.SW_SHOW);
            aux.WinSetState(WINTITLE, "", aux.SW_MAXIMIZE); //иначе окно не активируется
            aux.WinWait(WINTITLE);
            aux.WinActivate(WINTITLE);
            aux.WinWaitActive(WINTITLE);

            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            aux.ControlClick(WINTITLE, "", "WindowsForms10.BUTTON.app.0.2c908d510");
        }

        public AutoItX3 Aux
        {
            get { return aux; }
        }

        public GroupHelper Groups
        {
            get { return groupHelper; }
        }

    }
}
