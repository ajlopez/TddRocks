using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TddApp.Core.Data;

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
    }
}
