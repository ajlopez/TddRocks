namespace StandingOvation.Console
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

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
                var words = lines[k + 1].Trim().Split(' ').ToList();
                var solution = Solver.Resolve(words[1]);

                Console.WriteLine(k + 1);
                results.Add(string.Format("Case #{0}: {1}", k + 1, solution));
            }

            File.WriteAllLines(outputname, results.ToArray());
        }
    }
}
