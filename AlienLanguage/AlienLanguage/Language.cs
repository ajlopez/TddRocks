namespace AlienLanguage
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Language
    {
        private string word;

        public IEnumerable<string> Match(string match)
        {
            var list = new List<string>();

            if (match == this.word)
                list.Add(this.word);

            return list;
        }

        public void AddWord(string word)
        {
            this.word = word;
        }
    }
}
