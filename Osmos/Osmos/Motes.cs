namespace Osmos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Motes
    {
        public bool CanBeSolved(int mote, IList<int> values)
        {
            IList<int> residues = new List<int>(values.OrderBy(v => v));
            int count = residues.Count;
            int rest = mote;

            for (int j = -1; j < count - 1; j++)
            {
                for (int k = j + 1; k < count; k++)
                    residues[k] -= rest;

                rest = values[j + 1];
            }

            return residues.All(v => v < 0);
        }
    }
}
