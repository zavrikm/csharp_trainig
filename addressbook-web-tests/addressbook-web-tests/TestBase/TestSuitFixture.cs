﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [SetUpFixture]
    public class TestSuitFixture
    {

        [SetUp]
        public void InitApplicationManager() // общая инициализация
        {
            ApplicationManager app = ApplicationManager.GetInstance();

            app.Navigator.OpenHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
        }

    }
}
