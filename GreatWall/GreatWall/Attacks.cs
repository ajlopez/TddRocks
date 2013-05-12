namespace GreatWall
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Attacks
    {
        public int Count(IList<Tribe> initialtribes)
        {
            Wall wall = new Wall();

            IList<Tribe> tribes = initialtribes.OrderBy(t => t.Day).ToList();

            int counter = 0;
            int lastday = -1;

            while (tribes.Count > 0)
            {
                var tribe = tribes.First();
                tribes.RemoveAt(0);

                if (lastday != tribe.Day)
                {
                    wall.NewDay();
                    lastday = tribe.Day;
                }

                if (wall.Attack(tribe.West, tribe.East, tribe.Strength))
                    counter++;

                tribe.NewDay();

                if (!tribe.CanAttack())
                    continue;

                int n = tribes.Count;

                if (n == 0 || tribes[n - 1].Day <= tribe.Day)
                {
                    tribes.Add(tribe);
                    continue;
                }

                bool added = false;

                for (int k = 0; k < n; k++)
                {
                    if (tribes[k].Day > tribe.Day)
                    {
                        tribes.Insert(k, tribe);
                        added = true;
                        break;
                    }
                }

                if (!added)
                    tribes.Add(tribe);
            }

            return counter;
        }
    }
}
