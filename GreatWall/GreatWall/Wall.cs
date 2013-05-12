namespace GreatWall
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Wall
    {
        private IList<Interval> state = new List<Interval>();
        private IList<Interval> newstate;

        public void NewDay()
        {
            if (this.newstate != null)
                this.EndOfDay();

            this.newstate = new List<Interval>();
        }

        public void EndOfDay()
        {
            this.state = this.state.Union(this.newstate).ToList();
        }

        public bool Attack(int from, int to, int strength)
        {
            for (int k = from; k < to; k++)
                if (this.state.All(i => i.Wins(k, strength)))
                {
                    this.newstate.Add(new Interval(from, to, strength));
                    return true;
                }

            return false;
        }

        private class Interval
        {
            private int from;
            private int to;
            private int height;

            public Interval(int from, int to, int height)
            {
                this.from = from;
                this.to = to;
                this.height = height;
            }

            public bool Wins(int position, int strenght)
            {
                if (this.to <= position)
                    return true;
                if (this.from > position)
                    return true;
                return this.height < strenght;
            }
        }
    }
}
