namespace Treasure.Console
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

            int ncase = int.Parse(lines[0]);
            int nline = 0;

            IList<string> results = new List<string>();

            for (int n = 0; n < ncase; n++)
            {
                Console.WriteLine(string.Format("Solving #{0}", n + 1));
                nline++;
                string[] numbers = lines[nline].Split(' ');
                int nchests = int.Parse(numbers[1]);
                nline++;
                numbers = lines[nline].Split(' ');
                Console.WriteLine(lines[nline]);
                Trove trove = new Trove();
                
                foreach (var number in numbers)
                    trove.AddKey(int.Parse(number));

                for (int nc = 0; nc < nchests; nc++)
                {
                    nline++;
                    numbers = lines[nline].Split(' ');
                    int key = int.Parse(numbers[0]);
                    int nkeys = int.Parse(numbers[1]);
                    IList<int> keys = new List<int>();

                    for (int nk = 0; nk < nkeys; nk++)
                        keys.Add(int.Parse(numbers[2 + nk]));

                    trove.AddChest(new Chest(key, keys));
                }

                results.Add(string.Format("Case #{0}: {1}", n+1, SolutionToString(trove.GetSolution())));
            }

            File.WriteAllLines(outputname, results.ToArray());
        }

        private static string SolutionToString(IList<int> solution)
        {
            if (solution == null)
                return "IMPOSSIBLE";

            string result = string.Empty;

            foreach (int n in solution.Skip(1))
            {
                if (!string.IsNullOrEmpty(result))
                    result += " ";
                result += n.ToString();
            }

            return result;
        }
    }
}
