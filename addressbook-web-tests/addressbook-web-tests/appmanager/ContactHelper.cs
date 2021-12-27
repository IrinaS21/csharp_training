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
            return this;
        }

        public ContactHelper Modify(int p, ContactData newData)
        {
            InitContactModification(p);
            FillContactForm(newData);
            SubmitContacModification();
            manager.Navigator.ReturnToHomePage();
            return this;
        }

        public ContactHelper Remove(int p)
        {
            SelectContact(p);
            RemoveContact();
            driver.SwitchTo().Alert().Accept();
            manager.Navigator.GoToGroupsPage();
            return this;
        }

        public ContactHelper InitNewContactCreation()
        {
            driver.FindElement(By.LinkText("add new")).Click();
            return this;
        }


        public ContactHelper FillContactForm(ContactData contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            return this;
        }

        public ContactHelper SubmitContacCreation()
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }


        public ContactHelper InitContactModification(int index)
        {
            if (!IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td[8]/a/img")))
            {
                ContactData contact = (new ContactData("Petr", "Sidorov"));
                contact.Middlename = "Petrovich";

                Create(contact);
                driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td[8]/a/img")).Click();
                return this;
            }

            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper SubmitContacModification()
        {
            driver.FindElement(By.Name("update")).Click();

            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            if (!IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td/input")))
            {
                ContactData contact = (new ContactData("Petr", "Sidorov"));
                contact.Middlename = "Petrovich";

                Create(contact);
                driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + "]/td/input")).Click();
                return this;
            }


            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr["+ index +"]/td/input")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            return this;
        }


    }
}
