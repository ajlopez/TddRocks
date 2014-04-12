namespace DeceitfulWar
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Strategy
    {
        public int CalculateWar(IList<double> first, IList<double> second)
        {
            if (first.Count == 0)
                return 0;

            double play1 = first.Max();
            double play2;
            bool win = false;

            var greater = second.Where(n => n > play1).ToList();

            if (greater.Count > 0)
                play2 = greater.Min();
            else
            {
                play2 = second.Min();
                win = true;
            }
            
            var newfirst = first.Where(n => n != play1).ToList();
            var newsecond = second.Where(n => n != play2).ToList();

            return CalculateWar(newfirst, newsecond) + (win ? 1 : 0);
        }
    }
}
