﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTest : AuthTestBase
    {
        [Test]
        public void TestContactInformationGeneral()
        {
            // генерируем случайный номер контакта
            Random rnd = new Random();
            int number = rnd.Next(0, app.Contacts.GetContactCount());
            Console.WriteLine("number = {0}", number);

            //начинаем тест
            ContactData fromTable = app.Contacts.GetContactInformationFromTable(number);
            ContactData fromForm = app.Contacts.GetContactDetailedInformationFromForm(number);

            // verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address1, fromForm.Address1);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
        }

        [Test]
        public void TestContactInformationOnPage()
        {
            Random rnd = new Random();
            int number = rnd.Next(0, app.Contacts.GetContactCount());
            Console.WriteLine("number = {0}", number);

            string fromPage = app.Contacts.GetContactInformationFromPage(number);
            ContactData fromForm = app.Contacts.GetContactDetailedInformationFromForm(number);
          //  Assert.AreEqual(fromPage, fromForm.AllInfoToString);

        }
    }
}
