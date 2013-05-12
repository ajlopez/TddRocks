namespace Consonants
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Analyzer
    {
        private static char[] vowels = new char[] { 'a', 'e', 'i', 'o', 'u' };

        public IList<int> GetConsonantPositions(string text, int length)
        {
            IList<int> positions = new List<int>();
            int l = text.Length;

            for (int k = 0; k + length <= l; k++)
            {
                int counter = 0;

                for (int j = 0; j < length; j++)
                    if (!vowels.Contains(text[k + j]))
                        counter++;

                if (counter == length)
                    positions.Add(k);
            }

            return positions;
        }

        public int Count(string text, int length)
        {
            var positions = this.GetConsonantPositions(text, length);

            var counter = 0;

            foreach (int position in positions)
            {
                counter += position + 1;
            }

            return counter;
        }
    }
}
