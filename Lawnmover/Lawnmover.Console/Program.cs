namespace Lawnmover.Console
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
            int nline = 0;
            IList<string> results = new List<string>();

            for (int k = 0; k < ncases; k++) 
            {
                Console.WriteLine(string.Format("Solving Case #{0}", k + 1));
                nline++;
                string[] numbers = lines[nline].Split(' ');
                int height = int.Parse(numbers[0]);
                int width = int.Parse(numbers[1]);
                Pattern pattern = new Pattern(width, height);

                for (int j = 0; j < height; j++) 
                {
                    nline++;
                    pattern.SetRow(j, lines[nline]);
                    Console.WriteLine(lines[nline]);
                }

                results.Add(string.Format("Case #{0}: {1}", k+1, pattern.HasSolution() ? "YES" : "NO"));
            }

            File.WriteAllLines(outputname, results.ToArray());
        }
    }
}
