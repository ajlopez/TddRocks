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

        [TestMethod]
        public void FacturaConUnProductGetTotal()
        {
            Factura factura = new Factura();
            Producto producto = new Producto(10);
            factura.AddProducto(producto, 2);

            Assert.AreEqual(20, factura.GetTotal());
        }

        [TestMethod]
        public void FacturaConDosProductGetTotal()
        {
            Factura factura = new Factura();
            Producto producto1 = new Producto(10);
            Producto producto2 = new Producto(20);
            factura.AddProducto(producto1, 2);
            factura.AddProducto(producto2, 1);

            Assert.AreEqual(40, factura.GetTotal());
        }
    }
}
