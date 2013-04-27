namespace Energy.Console
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.IO;

    class Program
    {
        static void Main(string[] args)
        {
            string inputname = args[0];
            string outputname = args[1];

            string[] lines = File.ReadAllLines(inputname);

            int ncases = int.Parse(lines[0]);
            int nline = 0;
            IList<string> results = new List<string>();

            for (int k = 0; k < ncases; k++)
            {
                System.Console.WriteLine(string.Format("Solving Case #{0}", k + 1));
                nline++;
                string[] numbers = lines[nline].Split(' ');
                int maximum = int.Parse(numbers[0]);
                int reload = int.Parse(numbers[1]);
                nline++;
                numbers = lines[nline].Split(' ');
                List<int> nums = new List<int>();

                foreach (var number in numbers)
                    nums.Add(int.Parse(number));

                Planner planner = new Planner(maximum, reload);
                var result = planner.Run(nums);
                results.Add(string.Format("Case #{0}: {1}", k + 1, result));
            }

            File.WriteAllLines(outputname, results.ToArray());
        }
    }
}
