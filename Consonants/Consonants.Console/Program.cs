namespace Consonants.Console
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
            int nline = 0;
            IList<string> results = new List<string>();
            Analyzer analyzer = new Analyzer();

            for (int k = 0; k < ncases; k++)
            {
                Console.WriteLine(string.Format("Solving Case #{0}", k + 1));
                nline++;
                string[] words = lines[nline].Split(' ');
                string text = words[0];
                int length = int.Parse(words[1]);
                int count = analyzer.Count(text, length);
                results.Add(string.Format("Case #{0}: {1}", k + 1, count));
            }

            File.WriteAllLines(outputname, results.ToArray());
        }
    }
}
