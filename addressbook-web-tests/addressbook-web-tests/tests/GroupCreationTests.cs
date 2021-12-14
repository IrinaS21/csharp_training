using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
       
        [Test]
        public void GroupCreationTest()
        {
            app.Navigator.GoToHomePage();
            app.Auth.Login(new AccountData("admin", "secret"));
            app.Navigator.GoToGroupsPage();
            app.Groups.InitNewGroupCreation();
            GroupData group = (new GroupData("aaa"));
            group.Header = "ddd";
            group.Footer = "fff";
            app.Groups.FillGropForm(group);
            app.Groups.SubmitGroupCreation();
            app.Navigator.GoToGroupsPage();
            app.Auth.Logout();
        }
    }
}
