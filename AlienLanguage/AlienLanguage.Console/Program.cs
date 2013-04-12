namespace AlienLanguage.Console
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

            string[] numbers = lines[0].Split(' ');
            int nwords = int.Parse(numbers[1]);
            int nmatches = int.Parse(numbers[2]);

            Language language = new Language();

            for (var k = 1; k <= nwords; k++)
                language.AddWord(lines[k]);

            IList<string> result = new List<string>();

            for (var j = 0; j < nmatches; j++)
            {
                var words = language.Match(lines[nwords + j + 1]);
                result.Add(string.Format("Case #{0}: {1}", j + 1, words.Count()));
            }

            File.WriteAllLines(outputname, result.ToArray());
        }
    }
}
