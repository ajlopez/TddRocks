namespace Treasure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Trove
    {
        private KeySet keys = new KeySet();
        private KeySet availablekeys = new KeySet();
        private IList<Chest> chests = new List<Chest>();

        public IList<int> GetSolution()
        {
            var result = new List<int>();
            var keys = this.keys.Keys.ToList();

            foreach (var key in keys)
            {
                var chest = this.chests.FirstOrDefault(ch => ch.Key == key);

                if (chest == null)
                    return new int[] { };

                result.Add(this.chests.IndexOf(chest));
                this.keys = this.keys.Remove(key);
            }

            return result;
        }

        public void AddChest(Chest chest)
        {
            this.chests.Add(chest);
            this.availablekeys = this.availablekeys.Add(chest.Keys);
        }

        public void AddKey(int key)
        {
            this.keys = this.keys.Add(key);
            this.availablekeys = this.availablekeys.Add(key);
        }
    }
}
