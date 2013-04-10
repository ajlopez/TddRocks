namespace SpockGameTests
{
    using System;
    using System.Text;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SpockGame;

    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void ScissorsCutPaper()
        {
            Game game = new Game();

            Assert.AreEqual(PlayResult.FirstPlayer, game.Play(Play.Scissors, Play.Paper));
        }

        [TestMethod]
        public void PaperIsCutByScissors()
        {
            Game game = new Game();

            Assert.AreEqual(PlayResult.SecondPlayer, game.Play(Play.Paper, Play.Scissors));
        }
    }
}
