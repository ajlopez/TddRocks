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

        [TestMethod]
        public void AddAndMatchWord()
        {
            Language language = new Language();

            language.AddWord("abc");

            var result = language.Match("abc");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("abc", result.First());
        }

        [TestMethod]
        public void AddWordsAndMatchWord()
        {
            Language language = new Language();

            language.AddWord("abc");
            language.AddWord("cba");

            var result = language.Match("abc");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.AreEqual("abc", result.First());
        }

        [TestMethod]
        public void AddWordsAndMatchPattern()
        {
            Language language = new Language();

            language.AddWord("abc");
            language.AddWord("cba");
            language.AddWord("aaa");
            language.AddWord("ccc");

            var result = language.Match("(ac)b(ac)");

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Contains("abc"));
            Assert.IsTrue(result.Contains("cba"));
        }

        [TestMethod]
        public void AddWordsAndMatchPatternWithManyLetters()
        {
            Language language = new Language();

            language.AddWord("abbc");
            language.AddWord("cbba");
            language.AddWord("aaaa");
            language.AddWord("cccc");

            var result = language.Match("(ac)bb(ac)");

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Contains("abbc"));
            Assert.IsTrue(result.Contains("cbba"));
        }

        [TestMethod]
        public void AddWordsAndMatchPatternWithNoLetters()
        {
            Language language = new Language();

            language.AddWord("abbc");
            language.AddWord("cbba");
            language.AddWord("aaaa");
            language.AddWord("cccc");

            var result = language.Match("(ac)(ba)(bc)(ac)");

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count());
            Assert.IsTrue(result.Contains("abbc"));
            Assert.IsTrue(result.Contains("cbba"));
        }

        [TestMethod]
        public void AddWordsAndMatchPatternStartingWithALetter()
        {
            Language language = new Language();

            language.AddWord("abbc");
            language.AddWord("cbba");
            language.AddWord("aaaa");
            language.AddWord("cccc");

            var result = language.Match("ab(bc)(ac)");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count());
            Assert.IsTrue(result.Contains("abbc"));
        }
    }
}
