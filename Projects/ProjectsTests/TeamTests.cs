using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projects;

namespace ProjectsTests
{
    [TestClass]
    public class TeamTests
    {
        private Project project;
        private Resource john;
        private Resource mary;
        private Resource joe;

        [TestInitialize]
        public void Setup()
        {
            this.project = new Project();
            this.john = new Resource();
            this.mary = new Resource();
            this.joe = new Resource();

            DateTime from = new DateTime(2012, 9, 11);
            DateTime to = new DateTime(2012, 9, 18);

            this.project.AllocateResource(john, from, to, 6);
            this.project.AllocateResource(mary, from, to, 6);
        }

        [TestMethod]
        public void GetTeam()
        {
            IList<Resource> result = this.project.GetTeam();

            Assert.IsTrue(result.Contains(this.john));
            Assert.IsTrue(result.Contains(this.mary));
            Assert.IsFalse(result.Contains(this.joe));
        }
    }
}
