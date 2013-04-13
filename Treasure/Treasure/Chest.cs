namespace Treasure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Chest
    {
        private int key;
        private IList<int> keys;

        public Chest(int key, IList<int> keys)
        {
            this.key = key;
            this.keys = keys;
        }

        public int Key { get { return this.key; } }

        public IEnumerable<int> Keys { get { return this.keys; } }
    }
}
