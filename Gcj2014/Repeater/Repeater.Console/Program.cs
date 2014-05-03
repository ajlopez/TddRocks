using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repeater.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Repeater reapeter = new Repeater();
            int ncases = int.Parse(System.Console.ReadLine());

            for (int k = 1; k <= ncases; k++)
            {
                int nstrings = int.Parse(System.Console.ReadLine());
                IList<string> strings = new List<string>();

                for (int j = 0; j < nstrings; j++)
                    strings.Add(System.Console.ReadLine().ToString());

                int moves = reapeter.Moves(strings);

                System.Console.WriteLine(string.Format("Case #{0}: {1}", k, moves < 0 ? "Fegla Won" : moves.ToString()));
            }
        }
    }
}
