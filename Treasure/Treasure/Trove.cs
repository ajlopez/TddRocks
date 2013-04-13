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
            var chest = new Chest(0, this.keys.Keys.ToList());
            chest.Open();
            this.chests.Insert(0, chest);
            var count = this.chests.Count;
            var result = new int[count];

            int pos = 1;

            if (GetSolution(count, pos, result))
                return result;

            return null;
        }

        public bool GetSolution(int count, int pos, int[] result)
        {
            for (int k = 1; k < count; k++)
            {
                var ch = this.chests[k];

                if (ch.Opened)
                    continue;

                for (int j = ch.Opener + 1; j < count; j++)
                {
                    if (j == k)
                        continue;
                    var ch2 = this.chests[j];
                    if (!ch2.Opened)
                        continue;
                    if (!ch2.Keys.Contains(ch.Key))
                        continue;
                    ch2.Keys.Remove(ch.Key);
                    ch.Opener = j;
                    ch.Open();
                    result[pos] = k;

                    pos++;

                    if (pos >= count)
                        return true;

                    if (GetSolution(count, pos, result))
                        return true;

                    pos--;
                    ch.Close();
                    ch2.Keys.Add(ch.Key);
                    break;
                }
            }

            return false;
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

            foreach (var chest in toopen.Where(ch => ch.Opener == -1 && this.keys.Keys.Contains(ch.Key)))
            {
                int key = chest.Key;

                var result = new List<int>(opened);
                result.Add(this.chests.IndexOf(chest));
                chest.Open();
                chest.Opener = 0;

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
            chest.Opener = -1;
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
