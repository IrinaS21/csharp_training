﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : AuthTestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = (new ContactData("Petr_ed", "Sidorov_ed"));
            newData.Middlename = "Petrovich_ed";

            app.Contacts.IsContactPresent();

            List<ContactData> oldContacts = app.Contacts.GetContactList();

            app.Contacts.Modify(1, newData);

            List<ContactData> newContacts = app.Contacts.GetContactList();
            oldContacts[0].Firstname = newData.Firstname;
            oldContacts[0].Lastname = newData.Lastname;
            oldContacts.Sort();
            newContacts.Sort();

            Assert.AreEqual(oldContacts, newContacts);


        }
    }
}
