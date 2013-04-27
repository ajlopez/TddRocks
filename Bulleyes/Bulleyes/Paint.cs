namespace Bulleyes
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Paint
    {
        public int PaintFor(int radius)
        {
            return (radius + 1) * (radius + 1) - radius * radius;
        }

        public long CountFor(long radius, long paint)
        {
            long rest = paint;
            long count = 0;
            long incr = 1;

            while (true)
            {
                while ((count + incr) * (2 * radius + 1 + 2 * (count + incr - 1)) <= paint)
                {
                    count += incr;
                    incr *= 2;
                }

                if (incr == 1)
                    break;

                incr /= 2;
            }

            return count;

            //for (int p = this.PaintFor(radius); p <= rest; p = this.PaintFor(radius))
            //{
            //    rest -= p;
            //    count++;
            //    radius += 2;
            //}

            //return count;
        }
    }
}
