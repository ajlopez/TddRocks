namespace Lawnmover
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Pattern
    {
        private int width;
        private int height;

        public Pattern(int width, int height)
        {
            this.width = width;
            this.height = height;
        }

        public int Width { get { return this.width; } }

        public int Height { get { return this.height; } }
    }
}
