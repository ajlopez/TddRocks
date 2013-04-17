namespace GameTreeSearch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class TreeSearch
    {
        public int FindMaxValue(Tree tree, int depth)
        {
            if (depth > 0 && tree.ChildNodes.Count() > 0)
                return tree.ChildNodes.Max(tr => this.FindMaxValue(tr, depth - 1));

            return tree.RootValue;
        }
    }
}
