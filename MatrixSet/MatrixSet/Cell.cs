namespace MatrixSet
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Cell
    {
        private int x;
        private int y;

        public Cell(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public bool Value { get; set; }

        public int X { get { return this.x; } }

        public int Y { get { return this.y; } }
    }
}
