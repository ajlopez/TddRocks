namespace MagicTrick.Console
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
            Magician magician = new Magician();

            for (int k = 0; k < ncases; k++)
            {
                int nline = k * 10 + 1;

                int nrow1 = int.Parse(lines[nline]);

                Grid grid1 = new Grid(new string[] {
                    lines[nline+1],
                    lines[nline+2],
                    lines[nline+3],
                    lines[nline+4]
                });

                int nrow2 = int.Parse(lines[nline+5]);

                Grid grid2 = new Grid(new string[] {
                    lines[nline+6],
                    lines[nline+7],
                    lines[nline+8],
                    lines[nline+9]
                });

                results.Add(string.Format("Case #{0}: {1}", k + 1, magician.Resolve(nrow1, grid1, nrow2, grid2)));
            }

            File.WriteAllLines(outputname, results.ToArray());
        }
    }
}
