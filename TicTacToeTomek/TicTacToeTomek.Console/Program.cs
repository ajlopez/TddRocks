namespace TicTacToeTomek.Console
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

            for (int k = 0; k < ncases; k++)
            {
                string cells = lines[k * 5 + 1] + lines[k * 5 + 2] + lines[k * 5 + 3] + lines[k * 5 + 4];
                Board board = new Board(cells);
                var status = board.Evaluate();
                results.Add(string.Format("Case #{0}: {1}", k + 1, StatusToString(status)));
            }

            File.WriteAllLines(outputname, results.ToArray());
        }

        private static string StatusToString(Status status)
        {
            switch (status)
            {
                case Status.Draw:
                    return "Draw";
                case Status.NotCompleted:
                    return "Game has not completed";
                case Status.XWon:
                    return "X won";
                case Status.OWon:
                    return "O won";
            }

            return string.Empty;
        }
    }
}
