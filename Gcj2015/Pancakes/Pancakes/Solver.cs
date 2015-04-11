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

        private static IList<int> DoRound(IList<int> pancakes)
        {
            IList<int> newpancakes = new List<int>();

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
