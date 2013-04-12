namespace AlienLanguage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Language
    {
        private IList<string> words = new List<string>();

        public IEnumerable<string> Match(string match)
        {
            var list = new List<string>();

            if (!IsPattern(match))
            {
                if (this.words.Contains(match))
                    list.Add(match);

                return list;
            }

            var parts = SplitPattern(match);

            IList<string> result = this.words;
            int pos = 0;

            foreach (var part in parts)
            {
                if (part[0] == '(')
                {
                    pos++;
                    continue;
                }

                int len = part.Length;
                result = result.Where(w => w.Substring(pos, len) == part).ToList();
                pos += len;
            }

            pos = 0;

            foreach (var part in parts)
            {
                if (part[0] != '(')
                {
                    int len = part.Length;
                    pos += len;
                    continue;
                }

                result = result.Where(w => part.Contains(w[pos])).ToList();
                pos++;
            }

            return result;
        }

        public void AddWord(string word)
        {
            this.words.Add(word);
        }

        private static bool IsPattern(string match)
        {
            return match.Contains("(");
        }

        private static IList<string> SplitPattern(string match)
        {
            var firstparts = match.Split(')');

            var parts = new List<string>();

            foreach (var part in firstparts)
            {
                if (string.IsNullOrEmpty(part))
                    continue;

                int pos = part.IndexOf('(');

                if (pos >= 0)
                {
                    if (pos > 0)
                        parts.Add(part.Substring(0, pos));

                    parts.Add(part.Substring(pos));
                }
                else
                    parts.Add(part);
            }

            return parts;
        }
    }
}
