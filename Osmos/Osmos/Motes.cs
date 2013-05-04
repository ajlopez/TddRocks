namespace Osmos
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Motes
    {
        public bool CanBeSolved(int mote, IList<int> values)
        {
            int count = values.Count;

            for (int k = 0; k < count; k++)
            {
                if (mote <= values[k])
                    return false;
                mote += values[k];
            }

            return true;
        }
    }
}
