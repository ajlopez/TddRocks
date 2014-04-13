namespace CookieClicker.Console
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
            Solver solver = new Solver();

            for (int k = 0; k < ncases; k++)
            {
                var numbers = lines[k + 1].Trim().Split(' ').Select(n => double.Parse(n)).ToList();
                var solution = solver.Solve(numbers[0], 2.0, numbers[1], numbers[2]);

                Console.WriteLine(k + 1);
                results.Add(string.Format("Case #{0}: {1}", k + 1, solution));
            }

            File.WriteAllLines(outputname, results.ToArray());
        }
    }
}
