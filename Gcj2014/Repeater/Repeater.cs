namespace Repeater
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Repeater
    {
        public IList<Group> ToGroups(string text)
        {
            IList<Group> groups = new List<Group>();

            if (string.IsNullOrWhiteSpace(text))
                return groups;

            char letter = text[0];
            int count = 1;

            for (int k = 1; k < text.Length; k++)
                if (text[k] != letter)
                {
                    groups.Add(new Group(letter, count));
                    letter = text[k];
                    count = 1;
                }
                else
                    count++;

            groups.Add(new Group(letter, count));

            return groups;
        }

        public int Moves(IList<string> strings)
        {
            throw new NotImplementedException();
        }
    }
}
