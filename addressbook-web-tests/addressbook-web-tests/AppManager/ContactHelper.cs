using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class ContactHelper : HelperBase
    {

        

        public ContactHelper(ApplicationManager manager) : base(manager)
        {
          
        }



        public ContactHelper Create(ContactData contact)
        {
            GoToContactCreationPage();
            FillContactCreationForm(contact);
            SubmitContactCreation();

            return this;
        }

        public ContactHelper Modify(int p, ContactData newData)
        {
            manager.Navigator.OpenDashboard();

            ClickEditPencilButtonInString(p);
            FillContactCreationForm(newData);
            SubmitContactMidification();
            manager.Navigator.OpenDashboard();

            return this;
        }

        public ContactHelper Remove(int p)
        {
            manager.Navigator.OpenDashboard();

            ChooseContactInTable(p);
            LookForAlert(true);
            ClickDeleteContactButton();
            ConfirmDeletindContactToAlert();
            contactCache = null;

            return this;
        }



        public bool AContactExists()
        {
            return IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[2]/td/input"));
        }


        public ContactHelper GoToContactCreationPage()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }


        public ContactHelper FillContactCreationForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.FirstName);
            Type(By.Name("middlename"), contact.MiddleName);
            Type(By.Name("lastname"), contact.LastName);
            Type(By.Name("nickname"), contact.NickName);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address1);
            Type(By.Name("home"), contact.HomePhone1);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("email"), contact.Email1);

            SelectBytextInDropDown(By.Name("bday"), contact.BDay);
            SelectBytextInDropDown(By.Name("bmonth"), contact.BMonth);

            Type(By.Name("byear"), contact.BYear);
            Type(By.Name("address2"), contact.Address2);

            return this;
        }



        public ContactHelper SubmitContactCreation()
        {
            driver.FindElement(By.XPath("(//input[@name='submit'])[2]")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper ChooseContactInTable(int index)
        {
               driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index+2) + "]/td/input")).Click();
            return this;
        }

        public ContactHelper ClickDeleteContactButton()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }

        public ContactHelper ConfirmDeletindContactToAlert()
        {
            Assert.IsTrue(Regex.IsMatch(CloseAlertAndGetItsText(), "^Delete 1 addresses[\\s\\S]$"));
            return this;
        }

        public ContactHelper ClickEditPencilButtonInString(int index)
        {
            index = index + 2;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]//img[@title='Edit']")).Click();
            return this;
        }

        public ContactHelper SubmitContactMidification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCache = null;
            return this;
        }

        public ContactHelper CreateIfNoOneContactExists() // for Remove and Modify Methods - creates a contact if there is no any
        {
            if (!AContactExists())
            {
                ContactData aContact = new ContactData();
                aContact.BMonth = "-";
                aContact.AMonth = "-";
                Create(aContact);
            }

            return this;
        }

        private List<ContactData> contactCache = null; //поле для кеширования списка контактов

        public List<ContactData> GetContactsList()
        {


                if (contactCache == null) //вариант после 1-й попытки - исправить
                {
                    contactCache = new List<ContactData>();

                    manager.Navigator.OpenDashboard();
                    ICollection<IWebElement> contactStrings = driver.FindElements(By.XPath("//tr[@name='entry']"));


                    foreach (IWebElement element in contactStrings)
                    {
                        var cells = element.FindElements(By.TagName("td"));

                    var item = new ContactData
                    {
                            Id = cells[0].FindElement(By.TagName("input")).GetAttribute("Id"),
                            FirstName = cells[2].Text,
                            LastName = cells[1].Text
                        };
                        contactCache.Add(item); //добавляем в лист контактов по новому создаваемому объекту контакта
                    }

                }





            return new List<ContactData>(contactCache);
        }


        public int GetContactCount() // считает количество контактов на странице
        {
            var timeout = TimeSpan.FromSeconds(10);

            WebDriverWait wait = new WebDriverWait(driver, timeout);
            var element = wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(By.XPath("//tr[@name='entry']")));

            return element.Count;

        }

    }
}
