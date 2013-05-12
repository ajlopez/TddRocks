namespace GreatWall
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Wall
    {
        private IDictionary<int, int> state = new Dictionary<int, int>();
        private IDictionary<int, int> newstate;

        public void NewDay()
        {
            if (this.newstate != null)
                this.EndOfDay();

            this.newstate = new Dictionary<int, int>();
        }

        public void EndOfDay()
        {
            foreach (int key in this.newstate.Keys)
                if (!this.state.ContainsKey(key) || this.state[key] < this.newstate[key])
                    this.state[key] = this.newstate[key];
        }

        public bool Attack(int from, int to, int height)
        {
            bool result = false;

            for (int k = from; k < to; k++)
                if (!this.state.ContainsKey(k) || this.state[k] < height)
                {
                    if (!this.newstate.ContainsKey(k) || this.newstate[k] < height)
                        this.newstate[k] = height;
                    result = true;
                }

            return result;
        }
    }
}
