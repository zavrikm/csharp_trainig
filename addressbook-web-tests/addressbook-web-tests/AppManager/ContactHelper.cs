using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
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
            OpenDashboard();
            ClickEditPencilButtonInString(p);
            FillContactCreationForm(newData);
            SubmitContactMidification();
            OpenDashboard();

            return this;
        }

        public ContactHelper Remove(int p)
        {
            OpenDashboard();

            if (!AContactExists())
            {
                ContactData aContact = new ContactData();
                aContact.BMonth = "-";
                aContact.AMonth = "-";
                Create(aContact);
            }

            ChooseContactInTable(p);
            LookForAlert(true);
            ClickDeleteContactButton();
            ConfirmDeletindContactToAlert();

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
            return this;
        }

        public ContactHelper OpenDashboard()
        {
            driver.FindElement(By.LinkText("home")).Click();
            return this;
        }

        public ContactHelper ChooseContactInTable(int index)
        {
            index = index + 1;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td/input")).Click();
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
            index = index + 1;
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]//img[@title='Edit']")).Click();
            return this;
        }

        public ContactHelper SubmitContactMidification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }


    }
}
