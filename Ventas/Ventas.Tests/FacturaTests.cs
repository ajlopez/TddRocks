using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Ventas.Tests
{
    [TestClass]
    public class FacturaTests
    {
        [TestMethod]
        public void FacturaVaciaTotalEnCero()
        {
            Factura factura = new Factura();

            Assert.AreEqual(0, factura.GetTotal());
        }
    }
}
