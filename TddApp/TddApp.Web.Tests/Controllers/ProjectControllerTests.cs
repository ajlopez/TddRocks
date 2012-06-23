using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Web.Mvc;
using TddApp.Web.Controllers;
using TddApp.Web.Models;

namespace TddApp.Web.Tests.Controllers
{
    [TestClass]
    public class ProjectControllerTests
    {
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
    }
}
