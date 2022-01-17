using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class ContactInformationTests : AuthTestBase
    {
        [Test]
        public void ContactInformationTest()
        {
           ContactData fromTable = app.Contacts.GetContactInformationFromTable(0);
           ContactData fromForm = app.Contacts.GetContactInformationFromEditForm();

            //verification
            Assert.AreEqual(fromTable, fromForm);
            Assert.AreEqual(fromTable.Address, fromForm.Address.Trim());
            Assert.AreEqual(fromTable.AllEmail, fromForm.AllEmail);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);

        }

        [Test]
        public void ContactDetailTest()
        {
            string fromDetails = app.Contacts.GetContactInformationFromDetailsForm();
            ContactData fromForm = app.Contacts.GetContactInformationFromEditForm();

            //verification
            Assert.AreEqual(fromDetails, fromForm.AllDetails);
        }
    }
}
