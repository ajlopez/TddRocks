namespace Consorcios.Web.Tests.Controllers
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Web.Mvc;
    using Consorcios.Web.Controllers;
    using Consorcios.Core;

    [TestClass]
    public class ConsorcioControllerTests
    {
        [TestMethod]
        public void GetEmptyConsorcios()
        {
            ConsorcioController controller = new ConsorcioController();

            var result = controller.Index();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var vresult = (ViewResult)result;
            Assert.IsNotNull(vresult.Model);
            Assert.IsInstanceOfType(vresult.Model, typeof(IList<Consorcio>));
        }

        [TestMethod]
        public void GetOneConsorcios()
        {
            ConsorcioRepository repositorio = new ConsorcioRepository();
            repositorio.Add(new Consorcio() { Nombre = "Consorcio 1" });

            ConsorcioController controller = new ConsorcioController(repositorio);

            var result = controller.Index();

            Assert.IsNotNull(result);
            Assert.IsInstanceOfType(result, typeof(ViewResult));

            var vresult = (ViewResult)result;
            Assert.IsNotNull(vresult.Model);
            Assert.IsInstanceOfType(vresult.Model, typeof(IList<Consorcio>));

            var consorcios = (IList<Consorcio>)vresult.Model;

            Assert.AreEqual(1, consorcios.Count);
            Assert.AreEqual("Consorcio 1", consorcios[0].Nombre);
        }

        [TestMethod]
        public void AddConsorcio()
        {
            ConsorcioRepository repositorio = new ConsorcioRepository();

            ConsorcioController controller = new ConsorcioController(repositorio);

            controller.Add("Consorcio Nuevo");

            var lista = repositorio.GetList();

            Assert.AreEqual(1, lista.Count);
            Assert.AreEqual("Consorcio Nuevo", lista[0].Nombre);
            Assert.AreEqual(1, lista[0].Id);
        }
    }
}
