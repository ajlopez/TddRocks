namespace Ventas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Factura
    {
        private Producto producto;
        private int cantidad;

        public decimal GetTotal()
        {
            if (this.producto == null)
                return 0;

            return this.producto.Precio * this.cantidad;
        }

        public void AddProducto(Producto producto, int cantidad)
        {
            this.producto = producto;
            this.cantidad = cantidad;
        }
    }
}
