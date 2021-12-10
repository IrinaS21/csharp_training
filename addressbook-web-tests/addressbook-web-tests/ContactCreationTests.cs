﻿using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactCreationTests : TestBase
    {

        [Test]
        public void ContactCreationTest()
        {
            GoToHomePage();
            Login(new AccountData("admin", "secret"));
            InitNewContactCreation();
            ContactData contact = (new ContactData("Petr", "Sidorov"));
            contact.Middlename = "Petrovich";
            FillContactForm(contact);            
            SubmitContacCreation();
            ReturnToHomePage();
            Logout();
        }
    }
}
