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
            if (pancakes.Count == 0)
                return 0;

            IList<int> newpancakes1 = new List<int>();

            int maxvalue = pancakes.Max();

            if (maxvalue == 1)
                return 1;

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

            int maxvalue1 = newpancakes1.Max();
            int ncount1 = Resolve(newpancakes1);

            if (maxvalue1 >= ncount1)
                return 1 + ncount1;

            IList<int> newpancakes2 = new List<int>();

            foreach (int value in pancakes)
            {
                int newvalue = value - 1;

                if (newvalue > 0)
                    newpancakes2.Add(newvalue);
            }

            if (newpancakes2.Count == 0)
                return 1;

            int ncount2 = Resolve(newpancakes2);

            return Math.Min(1 + ncount1, ncount2 + 1);
        }

        public static int Resolve(string values)
        {
            IList<int> pancakes = new List<int>();

            foreach (var word in values.Split(' '))
                pancakes.Add(int.Parse(word));

            return Resolve(pancakes);
        }
    }
}
