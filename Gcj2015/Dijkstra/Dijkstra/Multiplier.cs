namespace Dijkstra
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Multiplier
    {
        private IDictionary<Quaternions, IDictionary<Quaternions, int>> table;

        public Multiplier()
        {
            table = new Dictionary<Quaternions, IDictionary<Quaternions, int>>();
            
            table[Quaternions.one] = new Dictionary<Quaternions, int>();
            table[Quaternions.i] = new Dictionary<Quaternions, int>();
            table[Quaternions.j] = new Dictionary<Quaternions, int>();
            table[Quaternions.k] = new Dictionary<Quaternions, int>();

            table[Quaternions.one][Quaternions.one] = (int)Quaternions.one;
            table[Quaternions.one][Quaternions.i] = (int)Quaternions.i;
            table[Quaternions.one][Quaternions.j] = (int)Quaternions.j;
            table[Quaternions.one][Quaternions.k] = (int)Quaternions.k;

            table[Quaternions.i][Quaternions.one] = (int)Quaternions.i;
            table[Quaternions.i][Quaternions.i] = -(int)Quaternions.one;
            table[Quaternions.i][Quaternions.j] = (int)Quaternions.k;
            table[Quaternions.i][Quaternions.k] = -(int)Quaternions.j;

            table[Quaternions.j][Quaternions.one] = (int)Quaternions.j;
            table[Quaternions.j][Quaternions.i] = -(int)Quaternions.k;
            table[Quaternions.j][Quaternions.j] = -(int)Quaternions.one;
            table[Quaternions.j][Quaternions.k] = (int)Quaternions.i;

            table[Quaternions.k][Quaternions.one] = (int)Quaternions.k;
            table[Quaternions.k][Quaternions.i] = (int)Quaternions.j;
            table[Quaternions.k][Quaternions.j] = -(int)Quaternions.i;
            table[Quaternions.k][Quaternions.k] = -(int)Quaternions.one;
        }

        public int Multiply(Quaternions x, Quaternions y)
        {
            return table[x][y];
        }
    }
}
