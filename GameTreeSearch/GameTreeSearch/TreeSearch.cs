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
                return this.FindMaxValue(tree.ChildNodes.First(), depth - 1);

            return tree.RootValue;
        }
    }
}
