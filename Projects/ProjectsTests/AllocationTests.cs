using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Projects;

namespace ProjectsTests
{
    /// <summary>
    /// Summary description for AllocationTests
    /// </summary>
    [TestClass]
    public class AllocationTests
    {
        [TestMethod]
        public void AllocateResourceToProject()
        {
            Project project = new Project();
            Resource resource = new Resource();

            DateTime fromDate = new DateTime(2012, 9, 18);
            DateTime toDate = new DateTime(2012, 9, 20);
            int dailyload = 6;

            project.AllocateResource(resource, fromDate, toDate, dailyload);

            var result = project.GetDailyLoad(resource, fromDate);
            Assert.AreEqual(6, result);
            result = project.GetDailyLoad(resource, fromDate.AddDays(-1));
            Assert.AreEqual(0, result);
        }
    }
}
