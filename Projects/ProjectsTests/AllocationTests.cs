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
//        private Project project;
        [TestInitialize]
        public void Setup()
        {
  //          this.project = new Project();
        }

        [TestCleanup]
        public void Cleanup()
        {
        }

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

        [TestMethod]
        public void AllocateResourceTwoWeeksToProjectSkippingWeekEnd()
        {
            Project project = new Project();
            Resource resource = new Resource();

            DateTime fromDate = new DateTime(2012, 9, 11);
            DateTime toDate = new DateTime(2012, 9, 21);
            DateTime saturday = new DateTime(2012, 9, 15);
            DateTime sunday = new DateTime(2012, 9, 16);
            int dailyload = 6;

            project.AllocateResource(resource, fromDate, toDate, dailyload);

            var result = project.GetDailyLoad(resource, saturday);
            Assert.AreEqual(0, result);
            result = project.GetDailyLoad(resource, sunday);
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void RaiseIfResourceIsNull()
        {
            Project project = new Project();

            DateTime fromDate = new DateTime(2012, 9, 18);
            DateTime toDate = new DateTime(2012, 9, 20);
            int dailyload = 6;

            project.AllocateResource(null, fromDate, toDate, dailyload);
        }
    }
}
