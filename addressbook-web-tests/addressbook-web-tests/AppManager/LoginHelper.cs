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
    public class LoginHelper : HelperBase
    {


        public LoginHelper(ApplicationManager manager) : base(manager)
        {

        }


        public void Login(AccountData account)
        {

            if (IsLoggedIn()) //если залогинен
            {
                if (IsLoggedIn(account))  //залогинен конкретным аккаунтом
                {
                    return; // return logged account
                }

                Logout(); //если залогинен не тем аккаунтом - выйти
            }

            Type(By.XPath("//input[@name='user']"), account.Username); //если не залогинен - залогиниться
            Type(By.Name("pass"), account.Password);

            driver.FindElement(By.XPath("//input[@value='Login']")).Click();
        }


        public void Logout()
        {
            if (IsLoggedIn())
            {
                driver.FindElement(By.LinkText("Logout")).Click();
            }

        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.Name("logout"));

        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn()
                && GetLoggetUserName() == account.Username;
                
        }

        public string GetLoggetUserName()
        {
            string text = driver.FindElement(By.Name("logout")).FindElement(By.TagName("b")).Text;
            return text.Substring(1, text.Length - 2);
        }
    }
}
