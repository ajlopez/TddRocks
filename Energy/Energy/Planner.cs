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
            if (current > next)
                return amount;

            if (amount == this.maximum)
                return this.reload;

            if (amount + this.reload > this.maximum)
                return amount + this.reload - this.maximum;

            return 0;
        }

        public int Decide(int amount, IList<int> numbers)
        {
            for (int k = 0; k < numbers.Count - 1; k++)
                if (numbers[0] * amount < numbers[k] * (amount + this.reload * k) && amount + this.reload * k <= this.maximum)
                    return 0;

            if (numbers[0] > numbers[1])
                return amount;

            if (amount == this.maximum)
                return this.reload;

            if (amount + this.reload > this.maximum)
                return amount + this.reload - this.maximum;

            return 0;
        }

        public long Run(IList<int> numbers)
        {
            long total = 0;
            int amount = this.maximum;
            int k;

            var rest = numbers.ToList();

            for (k = 0; k < numbers.Count - 1; k++)
            {
                int move = this.Decide(amount, rest);
                total += (long)move * numbers[k];
                amount -= move;
                amount += this.reload;

                if (amount > this.maximum)
                    amount = this.maximum;

                rest = rest.Skip(1).ToList();
            }

            total += (long)amount * numbers[k];

            return total;
        }
    }
}
