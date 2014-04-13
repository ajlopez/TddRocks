namespace CookieClicker
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Solver
    {
        public double Solve(double cost, double frequency, double increment, double target)
        {
            double total = 0.0;
            double time1 = target / frequency;
            double time2 = cost / frequency + target / (frequency + increment);

            while (time1 > time2)
            {
                total += cost / frequency;
                frequency += increment;
                time1 = target / frequency;
                time2 = cost / frequency + target / (frequency + increment);
            }

            return total + time1;
        }
    }
}
