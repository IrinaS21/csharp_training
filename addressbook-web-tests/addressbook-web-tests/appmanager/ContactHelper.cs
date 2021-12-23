using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            InitNewContactCreation();
            FillContactForm(contact);
            SubmitContacCreation();
            manager.Navigator.ReturnToHomePage();
            manager.Auth.Logout();
            return this;
        }

        public ContactHelper Modify(ContactData newData)
        {
            InitContactModification();
            FillContactForm(newData);
            SubmitContacModification();
            manager.Navigator.ReturnToHomePage();
            manager.Auth.Logout();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            SelectContact(p);
            RemoveContact();
            driver.SwitchTo().Alert().Accept();
            manager.Navigator.GoToGroupsPage();
            manager.Auth.Logout();

            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }


        public ContactHelper FillContactForm(ContactData contact)
        {
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            return this;
        }

        public ContactHelper SubmitContacCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }


        public ContactHelper InitContactModification()
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper SubmitContacModification()
        {
            driver.FindElement(By.Name("update")).Click();

            return this;
        }

        public ContactHelper SelectContact(int p)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[2]/td/input")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }


    }
}
