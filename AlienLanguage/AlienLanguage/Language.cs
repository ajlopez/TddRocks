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

            if (this.words.Contains(match))
                list.Add(match);

            return list;
        }

        public void AddWord(string word)
        {
            this.words.Add(word);
        }
    }
}
