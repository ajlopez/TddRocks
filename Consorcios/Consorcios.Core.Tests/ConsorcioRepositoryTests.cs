using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Consorcios.Core.Tests
{
    [TestClass]
    public class ConsorcioRepositoryTests
    {
        [TestMethod]
        public void GetEmptyConsorcios()
        {
            ConsorcioRepository repository = new ConsorcioRepository();

            var result = repository.GetList();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void AddConsorcio()
        {
            ConsorcioRepository repository = new ConsorcioRepository();
            Consorcio consorcio = new Consorcio() { Nombre = "Primero" };
            repository.Add(consorcio);
            var result = repository.GetList();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(consorcio.Nombre, result[0].Nombre);
            Assert.AreEqual(1, result[0].Id);
        }
    }
}
