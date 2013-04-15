namespace LawnmoverTests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using Lawnmover;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class PatternTests
    {
        [TestMethod]
        public void CreatePattern()
        {
            Pattern pattern = new Pattern(3, 2);

            Assert.AreEqual(3, pattern.Width);
            Assert.AreEqual(2, pattern.Height);
        }

        [TestMethod]
        public void SetRows()
        {
            Pattern pattern = new Pattern(2, 2);

            pattern.SetRow(0, new int[] { 1, 2 });
            pattern.SetRow(1, new int[] { 2, 3 });

            Assert.AreEqual(1, pattern.GetCell(0, 0));
            Assert.AreEqual(2, pattern.GetCell(0, 1));
            Assert.AreEqual(2, pattern.GetCell(1, 0));
            Assert.AreEqual(3, pattern.GetCell(1, 1));
        }

        [TestMethod]
        public void SetRowsUsingStrings()
        {
            Pattern pattern = new Pattern(2, 2);

            pattern.SetRow(0, "1 2");
            pattern.SetRow(1, "2 3");

            Assert.AreEqual(1, pattern.GetCell(0, 0));
            Assert.AreEqual(2, pattern.GetCell(0, 1));
            Assert.AreEqual(2, pattern.GetCell(1, 0));
            Assert.AreEqual(3, pattern.GetCell(1, 1));
        }

        [TestMethod]
        public void ValidRowMove()
        {
            Pattern pattern = new Pattern(2, 2);

            pattern.SetRow(0, "1 2");
            pattern.SetRow(1, "2 3");

            Assert.IsTrue(pattern.IsValidRowMove(0, 2));
            Assert.IsFalse(pattern.IsValidRowMove(0, 1));
            Assert.IsFalse(pattern.IsValidRowMove(0, 0));

            Assert.IsTrue(pattern.IsValidRowMove(1, 3));
            Assert.IsFalse(pattern.IsValidRowMove(1, 2));
            Assert.IsFalse(pattern.IsValidRowMove(1, 1));
        }

        [TestMethod]
        public void ValidRowMoveAfterMove()
        {
            Pattern pattern = new Pattern(2, 2);

            pattern.SetRow(0, "1 2");
            pattern.SetRow(1, "2 3");

            pattern.MoveRow(1, 3);

            Assert.IsTrue(pattern.IsValidRowMove(0, 2));
            Assert.IsFalse(pattern.IsValidRowMove(0, 1));
            Assert.IsFalse(pattern.IsValidRowMove(0, 0));

            Assert.IsFalse(pattern.IsValidRowMove(1, 3));
            Assert.IsFalse(pattern.IsValidRowMove(1, 2));
            Assert.IsFalse(pattern.IsValidRowMove(1, 1));
        }

        [TestMethod]
        public void ValidColumnMove()
        {
            Pattern pattern = new Pattern(2, 2);

            pattern.SetRow(0, "1 2");
            pattern.SetRow(1, "4 3");

            Assert.IsTrue(pattern.IsValidColumnMove(0, 4));
            Assert.IsFalse(pattern.IsValidColumnMove(0, 1));
            Assert.IsFalse(pattern.IsValidColumnMove(0, 0));

            Assert.IsTrue(pattern.IsValidColumnMove(1, 3));
            Assert.IsFalse(pattern.IsValidColumnMove(1, 2));
            Assert.IsFalse(pattern.IsValidColumnMove(1, 1));
        }

        [TestMethod]
        public void ValidColumnMoveAfterMove()
        {
            Pattern pattern = new Pattern(2, 2);

            pattern.SetRow(0, "1 2");
            pattern.SetRow(1, "4 3");

            pattern.MoveColumn(1, 4);

            Assert.IsTrue(pattern.IsValidColumnMove(0, 4));
            Assert.IsFalse(pattern.IsValidColumnMove(0, 1));
            Assert.IsFalse(pattern.IsValidColumnMove(0, 0));

            Assert.IsFalse(pattern.IsValidColumnMove(1, 3));
            Assert.IsFalse(pattern.IsValidColumnMove(1, 2));
            Assert.IsFalse(pattern.IsValidColumnMove(1, 1));
        }

        [TestMethod]
        public void GetMinUnsolved()
        {
            Pattern pattern = new Pattern(2, 2);

            pattern.SetRow(0, "1 2");
            pattern.SetRow(1, "4 3");

            var result = pattern.GetMinUnsolved();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Row);
            Assert.AreEqual(0, result.Column);
            Assert.AreEqual(1, result.Value);
        }

        [TestMethod]
        public void GetMinUnsolvedWithRowMove()
        {
            Pattern pattern = new Pattern(2, 2);

            pattern.SetRow(0, "1 2");
            pattern.SetRow(1, "4 3");

            pattern.MoveRow(0, 1);

            var result = pattern.GetMinUnsolved();

            Assert.IsNotNull(result);
            Assert.AreEqual(0, result.Row);
            Assert.AreEqual(1, result.Column);
            Assert.AreEqual(2, result.Value);
        }

        [TestMethod]
        public void HasSolution2x2()
        {
            Pattern pattern = new Pattern(2, 2);

            pattern.SetRow(0, "1 2");
            pattern.SetRow(1, "4 3");

            Assert.IsFalse(pattern.HasSolution());
        }

        [TestMethod]
        public void HasSolution3x3()
        {
            Pattern pattern = new Pattern(3, 3);

            pattern.SetRow(0, "2 1 2");
            pattern.SetRow(1, "1 1 1");
            pattern.SetRow(2, "2 1 2");

            Assert.IsTrue(pattern.HasSolution());
        }

        [TestMethod]
        public void HasSolution5x5()
        {
            Pattern pattern = new Pattern(5, 5);

            pattern.SetRow(0, "2 2 2 2 2");
            pattern.SetRow(1, "2 1 1 1 2");
            pattern.SetRow(2, "2 1 2 1 2");
            pattern.SetRow(2, "2 1 1 1 2");
            pattern.SetRow(2, "2 2 2 2 2");

            Assert.IsFalse(pattern.HasSolution());
        }

        [TestMethod]
        public void HasSolution3x1()
        {
            Pattern pattern = new Pattern(3, 1);

            pattern.SetRow(0, "1 2 1");

            Assert.IsTrue(pattern.HasSolution());
        }
    }
}
