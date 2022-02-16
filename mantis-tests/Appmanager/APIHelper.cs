using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using SimpleBrowser.WebDriver;
using System.Text.RegularExpressions;

namespace mantis_tests
{
    public class APIHelper : HelperBase
    {
        public APIHelper(ApplicationManager manager) : base(manager) { }

        public void CreateNewIssue(AccountData account, ProjectData project, IssueData IssueData)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.IssueData issue = new Mantis.IssueData();
            issue.summary = IssueData.Summary;
            issue.description = IssueData.Description;
            issue.category = IssueData.Category;
            issue.project = new Mantis.ObjectRef();
            issue.project.id = project.Id;
            client.mc_issue_add(account.Username, account.Password, issue);
        }

        List<ProjectData> projectList = new List<ProjectData>();
        public List<ProjectData> GetProjectsList(AccountData account)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData[] projectData = client.mc_projects_get_user_accessible(account.Username, account.Password);
            foreach (var project in projectData)
            {
                projectList.Add(new ProjectData
                {
                    Id = project.id,
                    Description = project.description,
                    ProjectName = project.name
                });
            }
            return projectList;
        }

        public void CreateProject(AccountData account, ProjectData project)
        {
            Mantis.MantisConnectPortTypeClient client = new Mantis.MantisConnectPortTypeClient();
            Mantis.ProjectData newProject = new Mantis.ProjectData();
            newProject.name = project.ProjectName;

            client.mc_project_add(account.Username, account.Password, newProject);
        }


    }
}
