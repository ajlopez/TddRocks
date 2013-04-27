using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace Bulleyes.Console
{
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
            Paint paint = new Paint();

            for (int k = 0; k < ncases; k++)
            {
                System.Console.WriteLine(string.Format("Solving Case #{0}", k + 1));
                nline++;
                string[] numbers = lines[nline].Split(' ');
                long radius = long.Parse(numbers[0]);
                long pnt = long.Parse(numbers[1]);
                long result = paint.CountFor(radius, pnt);
                results.Add(string.Format("Case #{0}: {1}", k + 1, result));
            }

            File.WriteAllLines(outputname, results.ToArray());
        }
    }
}
