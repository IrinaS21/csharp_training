﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    public class GroupHelper : HelperBase 
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }

        public GroupHelper Create(GroupData group)
        {
            manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            FillGropForm(group);
            SubmitGroupCreation();
            manager.Navigator.GoToGroupsPage();

            return this;
        }

        public GroupHelper Modify(int p, GroupData newData)
        {
            manager.Navigator.GoToGroupsPage();
            IsGroupPresent();
            SelectGroup(p);
            InitGroupModification();
            FillGropForm(newData); 
            SubmitGroupModification();
            manager.Navigator.GoToGroupsPage();

            return this;
        }

        public GroupHelper Remove(int p)
        {
            manager.Navigator.GoToGroupsPage();
            IsGroupPresent();
            SelectGroup(p);
            RemoveGroup();
            manager.Navigator.GoToGroupsPage();

            return this;
        }

        public GroupHelper IsGroupPresent()
        {
            if (!IsElementPresent(By.XPath("//div[@id='content']/form/span[1]/input")))
            {
                GroupData group = (new GroupData("aaa"));
                group.Header = "ddd";
                group.Footer = "fff";

                Create(group);
            }
            return this;
        }
        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;

        }

        public GroupHelper FillGropForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;

        }


        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;

        }


        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + index + "]/input")).Click();
            return this;
        }

        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }

        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;

        }


        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

    }
}
