﻿using System;
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
    public class GroupHelper : HelperBase
    {


        public GroupHelper(ApplicationManager manager) : base (manager)
        {

        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            ReturnToGroupPage();

            return this;
        }


        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();

            //  SelectGroup(p);
            SelectGroupByGroupId(p); 
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            ReturnToGroupPage();

            return this;
        }

        public GroupHelper SelectGroupByGroupId(int value) //находит группу на странице по ее group_id в базе
        {
            driver.FindElement(By.XPath("//input[@type = 'checkbox'][@value = '" + value + "']")).Click();

            return this;
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage(); 

            SelectGroup(p);
            RemoveGroup();
            ReturnToGroupsPage();


            return this;
        }

        public GroupHelper RemoveGroupById(int p)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroupByGroupId(p);
            RemoveGroup();
            new WebDriverWait(driver, TimeSpan.FromSeconds(10)).Until(d => d.FindElements(By.CssSelector("div.msgbox")).Count > 0);
            ReturnToGroupsPage();

            return this;
        }




        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
 
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);

            return this;
        }


        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCaсhe = null;
            return this;
        }

        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
            return this;
        }

        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("(//input[@name='selected[]'])[" + (index+1) + "]")).Click();
            return this;
        }

        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCaсhe = null;
            return this;
        }

        public GroupHelper ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }

        public GroupHelper InitGroupModification() 
        {
            driver.FindElement(By.XPath("//input[@name='edit'][1]")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification() 
        {
            driver.FindElement(By.Name("update")).Click();
            groupCaсhe = null;
            return this;
        }


        public GroupHelper CreateIfNoOneGroupExists() // for Remove and Modify Methods - creates a group if there is no any
        {
            if (!IsElementPresent(By.XPath("(//input[@name='selected[]'])[1]")))
            {
                GroupData aGroup = new GroupData("qwe");
                Create(aGroup);
            }

            return this;
        }

        public GroupHelper CreateAGroup()
        {
            GroupData aGroup = new GroupData("qwe");
            Create(aGroup);

            return this;
        }

        private List<GroupData> groupCaсhe = null; //поле для хранения кеширования списка групп

        public List<GroupData> GetGroupList()
        {
            if (groupCaсhe == null)
            {
                groupCaсhe = new List<GroupData>();

                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));
                foreach (IWebElement element in elements)
                {
                    
                    groupCaсhe.Add(new GroupData(null)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    }); //добавляем в лист групп по новому создаваемому объекту группы, попутно вызывая конструктор и записывая свойство в поле
                }

                string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text;
                string[] parts = allGroupNames.Split('\n');
                int shift = groupCaсhe.Count - parts.Length;
                for (int i = 0; i < groupCaсhe.Count; i++)
                {
                    if (i < shift)
                    {
                        groupCaсhe[i].Name = "";
                    }
                    else
                    {
                        groupCaсhe[i].Name = parts[i - shift].Trim();
                    }
                    
                }

            }

            return new List<GroupData>(groupCaсhe);
        }

        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

    }
}
