using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TddApp.Web.Tests
{
    [TestClass]
    public class DomainTests
    {
        [TestMethod]
        public void CreateDomainWithNoProjects()
        {
            Domain domain = new Domain();

            Assert.IsNotNull(domain.Projects);
            Assert.AreEqual(0, domain.Projects.Count);
        }

        [TestMethod]
        public void DomainCurrent()
        {
            Assert.IsNotNull(Domain.Current);
        }

        [TestMethod]
        [DeploymentItem("Files", "TddAppWebTests")]
        public void InitializeFromFolder()
        {
            Domain domain = new Domain();

            domain.InitializeFromFolder("TddAppWebTests");

            Assert.AreNotEqual(0, domain.Projects.Count);
        }
    }
}
