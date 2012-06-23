using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using TddApp.Web.Controllers;
using TddApp.Core.Entities;

namespace TddApp.Web.Tests.Controllers
{
    [TestClass]
    public class ProjectControllerTests
    {
        private ProjectController controller;
        private List<Project> projects;

        [TestInitialize]
        public void Setup()
        {
            this.projects = new List<Project>()
            {
                new Project() { Id = 1, Name = "Project 1" },
                new Project() { Id = 2, Name = "Project 2" },
                new Project() { Id = 3, Name = "Project 3" }
            };

            this.controller = new ProjectController(this.projects);
        }

        [TestMethod]
        public void GetIndex()
        {
            ProjectController controller = new ProjectController();

            var result = controller.Index();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var vresult = (ViewResult)result;

            Assert.IsNotNull(vresult.Model);
            Assert.IsInstanceOfType(vresult.Model, typeof(IEnumerable<Project>));
        }

        [TestMethod]
        public void GetIndexWithProjects()
        {
            var result = this.controller.Index();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var vresult = (ViewResult)result;

            Assert.IsNotNull(vresult.Model);
            Assert.IsInstanceOfType(vresult.Model, typeof(IEnumerable<Project>));

            var list = (IEnumerable<Project>)vresult.Model;

            Assert.AreNotEqual(0, list.Count());
        }

        [TestMethod]
        public void GetCreate()
        {
            var result = this.controller.Create();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var vresult = (ViewResult)result;
            Assert.IsNull(vresult.Model);
        }

        [TestMethod]
        public void PostCreate()
        {
            Project project = new Project() { Name = "New Project" };

            var result = this.controller.Create(project);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));

            var rresult = (RedirectToRouteResult)result;

            Assert.AreEqual("Index", rresult.RouteValues["action"]);

            Assert.AreEqual(4, this.projects.Count);
            Assert.IsTrue(this.projects.Any(p => p.Name == "New Project"));
            Assert.AreEqual(4, project.Id);
        }

        [TestMethod]
        public void PostCreateFirstProject()
        {
            Project project = new Project() { Name = "New Project" };
            List<Project> projects = new List<Project>();
            ProjectController controller = new ProjectController(projects);

            var result = controller.Create(project);

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(RedirectToRouteResult));

            var rresult = (RedirectToRouteResult)result;

            Assert.AreEqual("Index", rresult.RouteValues["action"]);

            Assert.AreEqual(1, projects.Count);
            Assert.IsTrue(projects.Any(p => p.Name == "New Project"));
            Assert.AreEqual(1, project.Id);
        }
    }
}
