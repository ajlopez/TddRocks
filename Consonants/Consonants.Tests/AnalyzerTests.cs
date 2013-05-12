namespace Consonants.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AnalyzerTests
    {
        [TestMethod]
        public void GetConsonantStringsLength1Sample1()
        {
            Analyzer analyzer = new Analyzer();
            var result = analyzer.GetConsonantPositions("ab", 1);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0]);
        }

        [TestMethod]
        public void GetConsonantStringsLength1Sample2()
        {
            Analyzer analyzer = new Analyzer();
            var result = analyzer.GetConsonantPositions("bc", 1);

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual(0, result[0]);
            Assert.AreEqual(1, result[1]);
        }

        [TestMethod]
        public void GetConsonantStringsLength2Sample1()
        {
            Analyzer analyzer = new Analyzer();
            var result = analyzer.GetConsonantPositions("abc", 2);

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual(1, result[0]);
        }
    }
}
