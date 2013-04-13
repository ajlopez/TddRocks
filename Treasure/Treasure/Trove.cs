namespace Treasure
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Trove
    {
        private IList<int> keys = new List<int>();
        private IList<Chest> chests = new List<Chest>();

        public IList<int> GetSolution()
        {
            var result = new List<int>();

            foreach (var key in keys)
            {
                var chest = this.chests.FirstOrDefault(ch => ch.Key == key);

                if (chest == null)
                    return new int[] { };

                result.Add(this.chests.IndexOf(chest));
            }

            return result;
        }

        public void AddChest(Chest chest)
        {
            this.chests.Add(chest);
        }

        public void AddKey(int key)
        {
            this.keys.Add(key);
        }
    }
}
