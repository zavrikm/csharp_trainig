using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections.Generic;
using System.Text.RegularExpressions;
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

        public ContactData GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index]
                .FindElements(By.TagName("td"));

            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address1 = cells[3].Text;
            string allEmails = cells[4].Text;

            string allPhones = cells[5].Text;

            return new ContactData()
            {
                FirstName = firstName,
                LastName = lastName,
                Address1 = address1,
                AllEmails = allEmails,
                AllPhones = allPhones
            };
        }


        public ContactData GetContactDetailedInformationFromForm(int index) // пдополнить информацией из формы и склеить в отдельном свойстве
        {
            manager.Navigator.OpenHomePage();
            ClickEditPencilButtonInString(index);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string middleName = driver.FindElement(By.Name("middlename")).GetAttribute("value");
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string nickName = driver.FindElement(By.Name("nickname")).GetAttribute("value");
            string company = driver.FindElement(By.Name("company")).GetAttribute("value");
            string title = driver.FindElement(By.Name("title")).GetAttribute("value");

            string address1 = driver.FindElement(By.Name("address")).Text;
            string homePhone1 = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string fax = driver.FindElement(By.Name("fax")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            string homePage = driver.FindElement(By.Name("homepage")).GetAttribute("value");

            string bDay = driver.FindElement(By.Name("bday")).GetAttribute("value");
            string bMonth = driver.FindElement(By.Name("bmonth")).GetAttribute("value");
            string bYear = driver.FindElement(By.Name("byear")).GetAttribute("value");

            string aDay = driver.FindElement(By.Name("aday")).GetAttribute("value");
            string aMonth = driver.FindElement(By.Name("amonth")).GetAttribute("value");
            string aYear = driver.FindElement(By.Name("ayear")).GetAttribute("value");

            string address2 = driver.FindElement(By.Name("address2")).GetAttribute("value");
            string homePhone2 = driver.FindElement(By.Name("phone2")).GetAttribute("value");
            string notes = driver.FindElement(By.Name("notes")).GetAttribute("value");


            return new ContactData()
            {
                FirstName = firstName,
                MiddleName = middleName,
                LastName = lastName,
                NickName = nickName,
                Company = company,
                Title = title,

                Address1 = address1,
                HomePhone1 = homePhone1,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                FaxPhone = fax,

                Email1 = email,
                Email2 = email2,
                Email3 = email3,
                HomePage = homePage,

                BDay = bDay,
                BMonth = bMonth,
                BYear = bYear,

                ADay = aDay,
                AMonth = aMonth,
                AYear = aYear,

                Address2 = address2,
                HomePhone2 = homePhone2,
                Notes = notes

            };
        }


        public string GetContactInformationFromPage(int index)
        {
            manager.Navigator.OpenHomePage();
            ClickViewInfoIconInString(index);

            return driver.FindElement(By.Id("content")).Text;

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
            Type(By.Name("company"), contact.Company);
            Type(By.Name("title"), contact.Title);
            Type(By.Name("address"), contact.Address1);

            Type(By.Name("home"), contact.HomePhone1);
            Type(By.Name("mobile"), contact.MobilePhone);
            Type(By.Name("work"), contact.WorkPhone);
            Type(By.Name("fax"), contact.FaxPhone);

            Type(By.Name("email"), contact.Email1);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.HomePage);

            SelectBytextInDropDown(By.Name("bday"), contact.BDay);
            SelectBytextInDropDown(By.Name("bmonth"), contact.BMonth);
            Type(By.Name("byear"), contact.BYear);

            SelectBytextInDropDown(By.Name("aday"), contact.ADay);
            SelectBytextInDropDown(By.Name("amonth"), contact.AMonth);
            Type(By.Name("ayear"), contact.AYear);

            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.HomePhone2);
            Type(By.Name("notes"), contact.Notes);

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

        public ContactHelper ClickViewInfoIconInString(int index)
        {
            
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[6].Click();

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

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.OpenDashboard();
            string text = driver.FindElement(By.TagName("label")).Text;
            Match m = new Regex(@"\d+").Match(text);
            return Int32.Parse(m.Value);
        }

        public void AddContactToGroup(ContactData contact, GroupData group)
        {
            manager.Navigator.OpenDashboard();
            CleanGroupFilter();
            SelectContact(contact.Id);
            SelectGroupToAdd(group.Name);
            CommitAddingContactToGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10))
                .Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
        }

        public void CleanGroupFilter()
        {
            new SelectElement(driver.FindElement(By.Name("group"))).SelectByText("[all]");
        }

        public void SelectContact(string id)
        {
            driver.FindElement(By.Id(id)).Click();
        }

        public void SelectGroupToAdd(string name)
        {
            new SelectElement(driver.FindElement(By.Name("to_group"))).SelectByText(name);
        }

        public void CommitAddingContactToGroup()
        {
            driver.FindElement(By.Name("add")).Click();
        }


    }
}
