namespace GameTreeSearch
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Tree
    {
        private int rootvalue;
        private IEnumerable<Tree> childnodes;

        public Tree(int rootvalue)
            : this(rootvalue, null)
        {
        }

        public Tree(int rootvalue, IEnumerable<Tree> childnodes)
        {
            this.rootvalue = rootvalue;
            if (childnodes == null)
                this.childnodes = new List<Tree>();
            else
                this.childnodes = new List<Tree>(childnodes);
        }

        public int RootValue { get { return this.rootvalue; } }

        public IEnumerable<Tree> ChildNodes { get { return this.childnodes; } }
    }
}
