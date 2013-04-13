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
            var result = this.GetSolution(new int[] { });

            if (result == null)
                return null;

            return result.ToList();
        }

        public IEnumerable<int> GetSolution(IEnumerable<int> opened)
        {
            var toopen = this.chests.Where(ch => !ch.Opened);

            if (toopen.Count() == 0)
                return opened;

            foreach (var chest in toopen.Where(ch => this.keys.Keys.Contains(ch.Key)))
            {
                int key = chest.Key;

                var result = new List<int>(opened);
                result.Add(this.chests.IndexOf(chest));
                chest.Open();

                var oldkeys = this.keys;

                this.keys = this.keys.Remove(key);
                this.keys = this.keys.Add(chest.Keys);

                var newopened = this.GetSolution(result);

                if (newopened != null)
                    return newopened;

                chest.Close();

                this.keys = oldkeys;
            }

            return null;
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
