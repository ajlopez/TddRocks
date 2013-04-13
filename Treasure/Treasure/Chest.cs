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
        private bool opened;

        public Chest(string definition)
        {
            string[] numbers = definition.Split(' ');
            this.key = int.Parse(numbers[0]);
            this.keys = new List<int>();

            for (int k = 2; k < numbers.Length; k++)
                this.keys.Add(int.Parse(numbers[k]));
        }

        public Chest(int key, IList<int> keys)
        {
            this.key = key;
            this.keys = keys.ToList();
        }

        public int Key { get { return this.key; } }

        public bool Opened { get { return this.opened; } }

        public IList<int> Keys { get { return this.keys; } }

        public int Opener { get; set; }

        public void Open()
        {
            this.opened = true;
        }

        public void Close()
        {
            this.opened = false;
        }
    }
}
