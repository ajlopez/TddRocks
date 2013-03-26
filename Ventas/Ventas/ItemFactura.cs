namespace Ventas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class ItemFactura
    {
        private Producto producto;
        private int cantidad;

        public ItemFactura(Producto producto, int cantidad)
        {
            this.producto = producto;
            this.cantidad = cantidad;
        }

        public decimal Precio { get { return this.producto.Precio * this.cantidad; } }
    }
}
