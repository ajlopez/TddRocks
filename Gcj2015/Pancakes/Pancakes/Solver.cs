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
            IList<int> newpancakes = new List<int>();

            int maxvalue = pancakes.Max();
            int secondmax = (maxvalue % 2 == 1) ? maxvalue / 2 + 1 : maxvalue / 2;
            var second = pancakes.Where(n => n != maxvalue).ToList();
            int maxvalue2 = second.Count > 0 ? second.Max() : 0;
            int next = Math.Max(secondmax, maxvalue2);
            int maxcount = pancakes.Count(n => n == maxvalue);

            if (next + maxcount <= maxvalue)
            {
                bool found = false;
                foreach (int value in pancakes)
                    if (!found && value == maxvalue)
                    {
                        newpancakes.Add(value - secondmax);
                        found = true;
                    }
                    else
                        newpancakes.Add(value);

                newpancakes.Add(secondmax);

                return newpancakes;
            }

            foreach (int value in pancakes)
            {
                int newvalue = value - 1;

                if (newvalue > 0)
                    newpancakes.Add(newvalue);
            }

            return newpancakes;
        }
    }
}
