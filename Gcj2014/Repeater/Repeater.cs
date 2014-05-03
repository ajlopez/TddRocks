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

        public bool AreSolvable(IList<IList<Group>> groups)
        {
            var initial = groups[0];
            int ng = initial.Count;

            if (!groups.All(gr => gr.Count == ng))
                return false;

            for (int k = 1; k < groups.Count; k++)
            {
                var group = groups[k];
                for (int j = 0; j < ng; j++)
                    if (initial[j].Letter != group[j].Letter)
                        return false;
            }

            return true;
        }

        public int Moves(IList<string> strings)
        {
            IList<IList<Group>> groups = new List<IList<Group>>();

            foreach (var str in strings)
                groups.Add(this.ToGroups(str));

            if (!this.AreSolvable(groups))
                return -1;

            throw new NotImplementedException();
        }
    }
}
