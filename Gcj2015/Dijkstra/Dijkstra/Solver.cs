namespace Dijkstra
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Solver
    {
        private static Multiplier multiplier = new Multiplier();

        public static bool CanBeSolved(Quaternions[] values, long repeat)
        {
            if (values.Length * repeat < 3)
                return false;

            Quaternions result = Quaternions.one;
            int sign = 1;
            long tlength = repeat * values.Length;
            int p = 0;
            long k;

            long firsti = -1;

            for (k = 0; k < tlength; k++, p = (p + 1) % values.Length)
            {
                int newresult = multiplier.Multiply(result, values[p]);

                if (newresult < 0)
                {
                    sign *= -1;
                    newresult = -newresult;
                }

                result = (Quaternions)newresult;

                if (firsti < 0 && sign == 1 && result == Quaternions.i)
                    firsti = k;
            }

            if (result != Quaternions.one)
                return false;

            if (sign != -1)
                return false;

            if (firsti < 0)
                return false;

            long firstk = -1;
            result = Quaternions.one;
            sign = 1;
            p = values.Length - 1;
            long j;

            for (j = tlength - 1; j > firsti + 1; j--, p = (p - 1) % values.Length)
            {
                int newresult = multiplier.Multiply(result, values[p]);

                if (newresult < 0)
                {
                    sign *= -1;
                    newresult = -newresult;
                }

                result = (Quaternions)newresult;

                if (sign == 1 && result == Quaternions.k)
                {
                    firstk = j;
                    break;
                }
            }

            if (firstk < 0)
                return false;

            return true;
        }
    }
}
