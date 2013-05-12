namespace GreatWall.Console
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
            Attacks attacks = new Attacks();

            for (int k = 0; k < ncases; k++)
            {
                Console.WriteLine(string.Format("Solving Case #{0}", k + 1));
                nline++;
                int ntribes = int.Parse(lines[nline]);
                IList<Tribe> tribes = new List<Tribe>();

                for (int j = 0; j < ntribes; j++)
                {
                    nline++;
                    string[] words = lines[nline].Split(' ');
                    int day = int.Parse(words[0]);
                    int nattacks = int.Parse(words[1]);
                    int west = int.Parse(words[2]);
                    int east = int.Parse(words[3]);
                    int strength = int.Parse(words[4]);
                    int ddays = int.Parse(words[5]);
                    int ddistance = int.Parse(words[6]);
                    int dstrength = int.Parse(words[7]);
                    Tribe tribe = new Tribe(day, nattacks, west, east, strength, ddays, ddistance, dstrength);
                    tribes.Add(tribe);
                }

                int count = attacks.Count(tribes);

                results.Add(string.Format("Case #{0}: {1}", k + 1, count));
            }

            File.WriteAllLines(outputname, results.ToArray());
        }
    }
}
