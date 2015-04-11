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

            int ncount1 = ResolveSpecial(pancakes);
            int ncount2 = ResolveNormal(pancakes);

            return Math.Min(ncount1, ncount2);
        }

        public static int Resolve(string values)
        {
            IList<int> pancakes = new List<int>();

            foreach (var word in values.Split(' '))
                pancakes.Add(int.Parse(word));

            return Resolve(pancakes);
        }

        private static int ResolveSpecial(IList<int> pancakes)
        {
            IList<int> newpancakes = new List<int>();

            int maxvalue = pancakes.Max();

            if (maxvalue == 1)
                return 1;

            int split = maxvalue / 2;
            int steps = pancakes.Count(n => n == maxvalue);

            foreach (int value in pancakes)
                if (value == maxvalue)
                    newpancakes.Add(value - split);
                else
                    newpancakes.Add(value);

            for (int k = 0; k < steps; k++)
                newpancakes.Add(split);

            int ncount1 = Resolve(newpancakes);

            return steps + Resolve(newpancakes);
        }

        private static int ResolveNormal(IList<int> pancakes)
        {
            int maxvalue = pancakes.Max();
            int minvalue = pancakes.Min();

            if (minvalue == maxvalue)
                return maxvalue;

            int secondmaxvalue = pancakes.Where(n => n != maxvalue).Max();

            IList<int> newpancakes = new List<int>();
            int steps = maxvalue - secondmaxvalue;

            foreach (int value in pancakes)
            {
                if (value == maxvalue)
                    newpancakes.Add(secondmaxvalue);
                else if (value > steps)
                    newpancakes.Add(value - steps);
            }

            if (newpancakes.Count == 0)
                return 1;

            return Resolve(newpancakes) + steps;
        }
    }
}
