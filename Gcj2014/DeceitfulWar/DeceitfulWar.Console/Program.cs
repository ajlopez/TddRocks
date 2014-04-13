namespace DeceitfulWar.Console
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
            Strategy strat = new Strategy();
            int nline = 0;

            for (int k = 0; k < ncases; k++)
            {
                nline++;
                int nnumbers = int.Parse(lines[nline].Trim());
                nline++;
                var first = lines[nline].Trim().Split(' ').Select(n => double.Parse(n)).ToList();
                nline++;
                var second = lines[nline].Trim().Split(' ').Select(n => double.Parse(n)).ToList();

                int nwinwar = strat.CalculateWar(first, second);
                int nwindwar = strat.CalculateDeceitfulWar(first, second);

                results.Add(string.Format("Case #{0}: {1} {2}", k + 1, nwindwar, nwinwar));
            }

            File.WriteAllLines(outputname, results.ToArray());
        }
    }
}
