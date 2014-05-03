namespace Repeater.Tests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RepeaterTests
    {
        private Repeater repeater;

        [TestInitialize]
        public void Setup()
        {
            this.repeater = new Repeater();
        }

        [TestMethod]
        public void GetGroup()
        {
            var result = this.repeater.ToGroups("a");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual('a', result[0].Letter);
            Assert.AreEqual(1, result[0].Count);
        }

        [TestMethod]
        public void GetGroupRepeatedLetter()
        {
            var result = this.repeater.ToGroups("aaa");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual('a', result[0].Letter);
            Assert.AreEqual(3, result[0].Count);
        }

        [TestMethod]
        public void GetGroupRepeatedLetters()
        {
            var result = this.repeater.ToGroups("aaabb");

            Assert.IsNotNull(result);
            Assert.AreEqual(2, result.Count);
            Assert.AreEqual('a', result[0].Letter);
            Assert.AreEqual(3, result[0].Count);
            Assert.AreEqual('b', result[1].Letter);
            Assert.AreEqual(2, result[1].Count);
        }

        [TestMethod]
        public void GetNoGroupFromEmptyString()
        {
            var result = this.repeater.ToGroups(string.Empty);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void GetNoGroupFromNullString()
        {
            var result = this.repeater.ToGroups(null);

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void AreSolvable()
        {
            Assert.IsTrue(this.repeater.AreSolvable(new IList<Group>[] { this.repeater.ToGroups("ab"), this.repeater.ToGroups("aabbb"), this.repeater.ToGroups("aaab") }));
            Assert.IsFalse(this.repeater.AreSolvable(new IList<Group>[] { this.repeater.ToGroups("ab"), this.repeater.ToGroups("aabbb"), this.repeater.ToGroups("aaabc") }));
            Assert.IsFalse(this.repeater.AreSolvable(new IList<Group>[] { this.repeater.ToGroups("abc"), this.repeater.ToGroups("aabbb"), this.repeater.ToGroups("aaab") }));
        }

        [TestMethod]
        public void NoMove()
        {
            Assert.AreEqual(-1, this.repeater.Moves(new string[] { "ab", "bc" }));
            Assert.AreEqual(-1, this.repeater.Moves(new string[] { "ab", "abc" }));
            Assert.AreEqual(-1, this.repeater.Moves(new string[] { "cab", "bc" }));
        }

        [TestMethod]
        public void FirsSample()
        {
            Assert.AreEqual(1, this.repeater.Moves(new string[] { "mmaw", "maw" }));
        }
    }
}
