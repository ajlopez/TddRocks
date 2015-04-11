namespace Dijkstra.Console
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;

    public class Program
    {
        public static void Main(string[] args)
        {
            string inputname = args[0];
            string outputname = args[1];

            string[] lines = File.ReadAllLines(inputname);

            int ncases = int.Parse(lines[0]);
            IList<string> results = new List<string>();

            for (int k = 0; k < ncases; k++)
            {
                var pline = lines[k * 2 + 1];
                long repeat = long.Parse(pline.Split(' ')[1]);
                var line = lines[k * 2 + 2];
                var solution = Solver.CanBeSolved(line, repeat);

                Console.WriteLine(k + 1);
                results.Add(string.Format("Case #{0}: {1}", k + 1, solution ? "YES" : "NO"));
            }

            File.WriteAllLines(outputname, results.ToArray());
        }
    }
}
