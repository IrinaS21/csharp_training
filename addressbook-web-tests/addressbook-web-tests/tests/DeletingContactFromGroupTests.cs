using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
    public class DeletingingContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void TestDeletingContactfromGroup()
        {
            GroupData group = GroupData.GetAll()[0];
            List<ContactData> oldList = group.GetContacts();
            ContactData contact = GroupData.GetAll()[0].GetContacts().First();
            

            app.Contacts.DeleteContactFromGroup(contact, group);

            List<ContactData> newList = group.GetContacts();
            oldList.Remove(contact);
            newList.Sort();
            oldList.Sort();


            Assert.AreEqual(oldList, newList);
        }
    }
}
