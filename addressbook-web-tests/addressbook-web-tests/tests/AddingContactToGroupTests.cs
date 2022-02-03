using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;



namespace WebAddressbookTests
{
    public class AddingContactToGroupTests : ContactTestBase
    {


        [Test]
        //public void TestAddingContactToGroup()
        //{
        //    GroupData group = GroupData.GetAll()[0];
        //    List<ContactData> oldList = group.GetContacts();

        //    ContactData newcontact = new ContactData("Иван", "Сидоров");

        //    newcontact.Middlename = "Петрович";

        //    app.Contacts.Create(newcontact);

        //    GroupData newgroup = new GroupData("TestGroup");

        //    app.Groups.Create(newgroup);

        //    ContactData contact = ContactData.GetAll().Except(oldList).First();

        //    app.Contacts.AddContactToGroup(contact, newgroup);

        //    List<ContactData> newList = group.GetContacts();
        //    oldList.Add(contact);
        //    newList.Sort();
        //    oldList.Sort();


        //    Assert.AreEqual(oldList, newList);
        //}

        public void TestAddingContactToGroup()
        {
            List<GroupData> grouplist = GroupData.GetAll();
            List<ContactData> contactlist = ContactData.GetAll();

            if (grouplist.Count != 0)
            {
                if (contactlist.Count != 0)
                {
                    GroupData group = GroupData.GetAll()[0];
                    List<ContactData> oldList = group.GetContacts();                    
                    var eqv = oldList.SequenceEqual(contactlist);

                    if (oldList.SequenceEqual(contactlist))
                    {
                        ContactData newcontact = new ContactData("Иван", "Сидоров");
                            newcontact.Middlename = "Петрович";
                        app.Contacts.Create(newcontact);
                        
                    }
                    var exceptlist = contactlist.Except(oldList);
                        ContactData contact = contactlist.Except(oldList).First();
                        app.Contacts.AddContactToGroup(contact, group);
                        oldList.Add(contact);
                        List<ContactData> newList = group.GetContacts();
                        newList.Sort();
                        oldList.Sort();

                        Assert.AreEqual(oldList, newList);
                }
                else
                {
                    ContactData newcontact = new ContactData("Иван", "Сидоров");
                        newcontact.Middlename = "Петрович";
                    app.Contacts.Create(newcontact);

                    GroupData group = GroupData.GetAll()[0];
                    List<ContactData> oldList = group.GetContacts();
                    ContactData contact = ContactData.GetAll().Except(oldList).First();

                    app.Contacts.AddContactToGroup(contact, group);

                    List<ContactData> newList = group.GetContacts();
                    oldList.Add(contact);
                    newList.Sort();
                    oldList.Sort();

                    Assert.AreEqual(oldList, newList);
                }
            }

            else
            {
                GroupData newgroup = new GroupData("новая группа");
                app.Groups.Create(newgroup);

                if (contactlist.Count != 0)
                {
                    GroupData group = GroupData.GetAll()[0];
                    List<ContactData> oldList = group.GetContacts();
                    ContactData contact = ContactData.GetAll().Except(oldList).First();

                    app.Contacts.AddContactToGroup(contact, group);

                    List<ContactData> newList = group.GetContacts();
                    oldList.Add(contact);
                    newList.Sort();
                    oldList.Sort();

                    Assert.AreEqual(oldList, newList);
                }
                else
                {
                    ContactData newcontact = new ContactData("Иван", "Сидоров");
                    newcontact.Middlename = "Петрович";
                    app.Contacts.Create(newcontact);

                    GroupData group = GroupData.GetAll()[0];
                    List<ContactData> oldList = group.GetContacts();
                    ContactData contact = ContactData.GetAll().Except(oldList).First();

                    app.Contacts.AddContactToGroup(contact, group);

                    List<ContactData> newList = group.GetContacts();
                    oldList.Add(contact);
                    newList.Sort();
                    oldList.Sort();

                    Assert.AreEqual(oldList, newList);
                }
            }
            
        }

    }
}
