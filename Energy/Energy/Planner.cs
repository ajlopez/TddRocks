namespace Energy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Planner
    {
        private int maximum;
        private int reload;

        public Planner(int maximum, int reload)
        {
            this.maximum = maximum;
            this.reload = reload;
        }

        public int Decide(int amount, int current, int next)
        {
            if (current >= next)
                return amount;

            if (this.maximum - reload < amount)
                return amount - this.maximum + reload;

            return 0;
        }
    }
}
