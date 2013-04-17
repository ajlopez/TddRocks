namespace GameTreeSearch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree
    {
        private int rootvalue;

        public Tree(int rootvalue)
        {
            this.rootvalue = rootvalue;
        }

        public int RootValue { get { return this.rootvalue; } }
    }
}
