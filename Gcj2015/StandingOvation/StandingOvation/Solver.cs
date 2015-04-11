namespace StandingOvation
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Solver
    {
        public static int Resolve(int[] levels)
        {
            int result = 0;
            int accum = levels[0];

            for (int k = 1; k < levels.Length; k++)
            {
                if (levels[k] > 0 && accum < k)
                {
                    int friends = k - accum;
                    accum += friends;
                    result += friends;
                }

                accum += levels[k];
            }

            return result;
        }

        public static int Resolve(string levels)
        {
            IList<int> values = new List<int>();

            for (int k = 0; k < levels.Length; k++)
                values.Add(levels[k] - '0');

            return Resolve(values.ToArray());
        }
    }
}
