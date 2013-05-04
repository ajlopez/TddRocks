namespace Osmos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Motes
    {
        public IList<int> GetResidues(int mote, IList<int> values)
        {
            IList<int> residues = new List<int>(values);
            int count = residues.Count;
            int rest = mote;

            for (int j = -1; j < count - 1; j++)
            {
                for (int k = j + 1; k < count; k++)
                    residues[k] -= rest;

                rest = values[j + 1];
            }

            return residues;
        }

        public bool IsSolved(IList<int> residues)
        {
            return residues.All(v => v < 0);
        }

        public bool CanBeSolved(int mote, IList<int> values)
        {
            var residues = this.GetResidues(mote, values);
            return this.IsSolved(residues);
        }

        public int MovesToApply(int mote, IList<int> values)
        {
            int maxcost = values.Count;
            var result = this.MovesToApply(mote, values, maxcost);
            if (result < 0)
                return maxcost;
            return result;
        }

        private int MovesToApply(int mote, IList<int> values, int maxcost)
        {
            var residues = this.GetResidues(mote, values);

            if (this.IsSolved(residues))
                return 0;

            if (maxcost <= 0)
                return -1;

            int toremove = this.NumberToRemove(values, residues);
            var newvalues = new List<int>(values);
            newvalues.Remove(toremove);
            newvalues.Sort();

            int moves1 = this.MovesToApply(mote, newvalues, maxcost - 1);

            int toadd = this.NumberToAdd(mote, values, residues);
            newvalues = new List<int>(values);
            newvalues.Add(toadd);
            newvalues.Sort();

            int moves2 = this.MovesToApply(mote, newvalues, maxcost - 1);

            if (moves1 < 0 && moves2 < 0)
                return -1;

            if (moves1 < 0)
                return moves2 + 1;

            if (moves2 < 0)
                return moves1 + 1;

            return Math.Min(moves1, moves2) + 1;
        }

        public int NumberToRemove(IList<int> values, IList<int> residues)
        {
            int badresidue = residues.First(r => r >= 0);
            int position = residues.IndexOf(badresidue);
            return values[position];
        }

        public int NumberToAdd(int mote, IList<int> values)
        {
            var residues = this.GetResidues(mote, values);

            if (this.IsSolved(residues))
                return 0;

            return NumberToAdd(mote, values, residues);
        }

        private int NumberToAdd(int mote, IList<int> values, IList<int> residues)
        {
            int number = mote;
            int count = residues.Count;

            for (int k = 0; k < count; k++)
                if (residues[k] < 0)
                    number += values[k];
                else
                    return number - 1;

            return 0;
        }
    }
}
