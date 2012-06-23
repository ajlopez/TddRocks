using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddApp.Core.Services;
using TddApp.Core.Entities;

namespace TddApp.Core.Tests.Services
{
    [TestClass]
    public class ProjectServicesTests
    {
        [TestMethod]
        public void GetProjects()
        {
            ProjectServices services = new ProjectServices();

            var result = services.GetProjects();

            Assert.AreEqual(0, result.Count());
        }

        [TestMethod]
        public void GetThreeProjects()
        {
            var projects = new List<Project>()
            {
                new Project() { Id = 1, Name = "Project 1" },
                new Project() { Id = 2, Name = "Project 2" },
                new Project() { Id = 3, Name = "Project 3" }
            };

            ProjectServices services = new ProjectServices(projects);

            var result = services.GetProjects();

            Assert.AreEqual(3, result.Count());
        }

        [TestMethod]
        public void AddProject()
        {
            var projects = new List<Project>()
            {
                new Project() { Id = 1, Name = "Project 1" },
                new Project() { Id = 2, Name = "Project 2" },
                new Project() { Id = 3, Name = "Project 3" }
            };

            Project project = new Project() { Name = "New Project" };

            ProjectServices services = new ProjectServices(projects);

            services.AddProject(project);

            Assert.AreEqual(4, project.Id);
            Assert.IsTrue(projects.Any(p => p.Name == "New Project"));
        }
    }
}
