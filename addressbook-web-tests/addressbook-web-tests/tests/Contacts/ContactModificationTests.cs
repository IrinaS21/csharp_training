﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactModificationTests : TestBase
    {
        [Test]
        public void ContactModificationTest()
        {
            ContactData newData = (new ContactData("Petr_ed", "Sidorov_ed"));
            newData.Middlename = "Petrovich_ed";

            app.Contacts.Modify(newData);

        }
    }
}