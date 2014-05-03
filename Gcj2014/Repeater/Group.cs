namespace Repeater
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Group
    {
        private char letter;
        private int count;

        public Group(char letter, int count)
        {
            this.letter = letter;
            this.count = count;
        }

        public char Letter { get { return this.letter; } }

        public int Count { get { return this.count; } }
    }
}
