namespace Pancakes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Solver
    {
        public static int Resolve(IList<int> pancakes)
        {
            int rounds = 1;

            for (var newpancakes = DoRound(pancakes); newpancakes.Count > 0; newpancakes = DoRound(newpancakes))
                rounds++;

            return rounds;
        }

        public static int Resolve(string values)
        {
            IList<int> pancakes = new List<int>();

            foreach (var word in values.Split(' '))
                pancakes.Add(int.Parse(word));

            return Resolve(pancakes);
        }

        private static IList<int> DoRound(IList<int> pancakes)
        {
            IList<int> newpancakes1 = new List<int>();
            IList<int> newpancakes2 = new List<int>();

            int maxvalue = pancakes.Max();
            int split = maxvalue / 2;
            int maxcount = pancakes.Count(n => n == maxvalue);

            bool found = false;
            foreach (int value in pancakes)
                if (!found && value == maxvalue)
                {
                    newpancakes1.Add(value - split);
                    found = true;
                }
                else
                    newpancakes1.Add(value);

            newpancakes1.Add(split);

            foreach (int value in pancakes)
            {
                int newvalue = value - 1;

                if (newvalue > 0)
                    newpancakes2.Add(newvalue);
            }

            if (newpancakes1.Count == 0)
                return newpancakes1;
            if (newpancakes2.Count == 0)
                return newpancakes2;

            var value1 = ((double)newpancakes1.Sum()) / newpancakes1.Count;
            var value2 = ((double)newpancakes2.Sum()) / newpancakes2.Count;

            if (value1 < value2)
                return newpancakes1;
            else
                return newpancakes2;
        }
    }
}
