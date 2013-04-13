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
            var toopen = this.chests.Where(ch => !ch.Opened).ToList();
            KeySet keyset = new KeySet();

            foreach (var chest in toopen)
                keyset = keyset.Add(chest.Keys);

            var result = this.GetSolution(new int[] { }, toopen, keyset);
            if (result == null)
                return null;

            return result.ToList();
        }

        public IEnumerable<int> GetSolution(IEnumerable<int> opened, IList<Chest> toopen, KeySet keyset)
        {
            if (toopen.Count() == 0)
                return opened;

            foreach (var chest in toopen.Where(ch => !this.keys.Keys.Contains(ch.Key))) 
            {
                var newset = keyset.Remove(chest.Keys);
                if (!newset.Keys.Contains(chest.Key))
                    return null;
            }

            foreach (var chest in toopen.Where(ch => this.keys.Keys.Contains(ch.Key)))
            {
                int key = chest.Key;

                var result = new List<int>(opened);
                result.Add(this.chests.IndexOf(chest));
                chest.Open();

                var oldkeys = this.keys;

                this.keys = this.keys.Remove(key);
                this.keys = this.keys.Add(chest.Keys);

                var newtoopen = new List<Chest>(toopen);
                newtoopen.Remove(chest);
                var newkeyset = keyset.Remove(chest.Keys);

                var newresult = this.GetSolution(result, newtoopen, newkeyset);

                if (newresult != null)
                    return newresult;

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

        public void AddKeys(string keys)
        {
            string[] numbers = keys.Split(' ');

            foreach (var number in numbers)
                this.AddKey(int.Parse(number));
        }
    }
}
