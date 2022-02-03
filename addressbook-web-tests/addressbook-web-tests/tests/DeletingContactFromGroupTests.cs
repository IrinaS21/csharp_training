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
            List<GroupData> grouplist = GroupData.GetAll();
            List<ContactData> contactlist = ContactData.GetAll();
            ContactData newcontact = new ContactData("Иван", "Сидоров");
            newcontact.Middlename = "Петрович";
            GroupData newgroup = new GroupData("новая группа");

            if (grouplist.Count == 0)
            {
                app.Groups.Create(newgroup);

                if (contactlist.Count == 0)
                {
                    app.Contacts.Create(newcontact);
                    GroupData group = GroupData.GetAll()[0];
                    List<ContactData> contactsInGroup = group.GetContacts();
                    ContactData contact = ContactData.GetAll().Except(contactsInGroup).First();
                    app.Contacts.AddContactToGroup(contact, group);
                }
            }
            else
            {
                if (contactlist.Count == 0)
                {
                    app.Contacts.Create(newcontact);
                }
                GroupData group = GroupData.GetAll()[0];
                List<ContactData> contactsInGroup = group.GetContacts();
                if (contactsInGroup.Count == 0)
                {
                    ContactData contact = ContactData.GetAll().Except(contactsInGroup).First();
                    app.Contacts.AddContactToGroup(contact, group);
                }
            }

            GroupData group2 = GroupData.GetAll()[0];
            List<ContactData> oldList = group2.GetContacts();
            ContactData contactInGroup = GroupData.GetAll()[0].GetContacts().First();
            

            app.Contacts.DeleteContactFromGroup(contactInGroup, group2);

            List<ContactData> newList = group2.GetContacts();
            oldList.Remove(contactInGroup);
            newList.Sort();
            oldList.Sort();


            Assert.AreEqual(oldList, newList);
        }
    }
}
