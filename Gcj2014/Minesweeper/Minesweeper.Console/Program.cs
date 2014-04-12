namespace Minesweeper.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    public class Program
    {
        public static void Main(string[] args)
        {
            string inputname = args[0];
            string outputname = args[1];

            string[] lines = File.ReadAllLines(inputname);

            int ncases = int.Parse(lines[0]);
            IList<string> results = new List<string>();
            Master master = new Master();

            for (int k = 0; k < ncases; k++)
            {
                int nline = k + 1;
                string line = lines[nline];
                IList<int> numbers = line.Trim().Split(' ').Select(s => int.Parse(s)).ToList();
                var solution = master.Solve(numbers[0], numbers[1], numbers[2]);

                results.Add(string.Format("Case #{0}:", k + 1));

                if (solution is IList<string>)
                {
                    var lns = (IList<string>)solution;

                    foreach (var ln in lns)
                        results.Add(ln);
                }
                else
                    results.Add(solution.ToString());
            }

            File.WriteAllLines(outputname, results.ToArray());
        }
    }
}
