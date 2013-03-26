namespace Ventas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Factura
    {
        private IList<ItemFactura> items = new List<ItemFactura>();

        public decimal GetTotal()
        {
            return this.items.Sum(i => i.Precio);
        }

        public void AddProducto(Producto producto, int cantidad)
        {
            this.items.Add(new ItemFactura(producto, cantidad));
        }
    }
}
