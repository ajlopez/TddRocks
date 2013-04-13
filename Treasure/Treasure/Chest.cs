namespace Treasure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Chest
    {
        private int key;

        public Chest(int key, IList<int> keys)
        {
            this.key = key;
        }

        public int Key { get { return this.key; } }
    }
}
