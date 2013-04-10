namespace Ventas
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Producto
    {
        private decimal precio;

        public Producto(decimal precio)
        {
            this.precio = precio;
        }

        public decimal Precio { get { return this.precio; } }
    }
}
