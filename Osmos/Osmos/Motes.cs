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
