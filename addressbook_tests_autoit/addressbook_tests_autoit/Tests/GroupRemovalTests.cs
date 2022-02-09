using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void TestGroupRemoval()
        {
            //app.Groups.OpenGroupsDialogue();
            List<GroupData> oldGroups = app.Groups.GetGroupList();
            
           
            if (oldGroups.Count == 1)
            {
                GroupData newGroup = new GroupData()
                {
                    Name = "Test231"
                };
                app.Groups.Add(newGroup);
                oldGroups.Add(newGroup);
            }

            GroupData toBeRemoved = oldGroups[0];

            app.Groups.Remove(toBeRemoved);

            List<GroupData> newGroups = app.Groups.GetGroupList();

            oldGroups.Remove(oldGroups[0]);
            oldGroups.Sort();
            newGroups.Sort();
            Assert.AreEqual(oldGroups, newGroups);
        }
    }
}
