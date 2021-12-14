using System;
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
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Contacts.InitNewContactCreation();
            ContactData contact = (new ContactData("Petr", "Sidorov"));
            contact.Middlename = "Petrovich";
            app.Contacts.FillContactForm(contact);
            app.Contacts.SubmitContacCreation();
            app.Navigator.ReturnToHomePage();
            app.Auth.Logout();
        }
    }
}
