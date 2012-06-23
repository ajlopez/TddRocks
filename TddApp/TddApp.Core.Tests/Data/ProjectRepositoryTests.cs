using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddApp.Core.Data;
using TddApp.Core.Entities;

namespace TddApp.Core.Tests.Data
{
    [TestClass]
    public class ProjectRepositoryTests
    {
        [TestMethod]
        public void GetProjects()
        {
            ProjectRepository repository = new ProjectRepository();

            var result = repository.GetProjects();

            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void AddProject()
        {
            List<Project> projects = new List<Project>();
            ProjectRepository repository = new ProjectRepository(projects);
            Project project = new Project() { Name = "New Project" };

            repository.AddProject(project);

            Assert.AreEqual(1, project.Id);
            Assert.AreEqual(1, projects.Count);
            Assert.AreEqual("New Project", projects[0].Name);
        }
    }
}
