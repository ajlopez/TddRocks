namespace AlienLanguageTests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using AlienLanguage;

    [TestClass]
    public class LanguageTests
    {
        [TestMethod]
        public void MatchUnknownWord()
        {
            Language language = new Language();

            var result = language.Match("abc");

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count());
        }
    }
}
