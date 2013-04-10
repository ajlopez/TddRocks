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

            Assert.AreEqual(PlayResult.FirstPlayer, game.DoPlay(Play.Scissors, Play.Paper));
        }

        [TestMethod]
        public void PaperIsCutByScissors()
        {
            Game game = new Game();

            Assert.AreEqual(PlayResult.SecondPlayer, game.DoPlay(Play.Paper, Play.Scissors));
        }

        [TestMethod]
        public void Ties()
        {
            Game game = new Game();

            Assert.AreEqual(PlayResult.Tie, game.DoPlay(Play.Paper, Play.Paper));
            Assert.AreEqual(PlayResult.Tie, game.DoPlay(Play.Scissors, Play.Scissors));
        }

        [TestMethod]
        public void PaperCoversRock()
        {
            Game game = new Game();

            Assert.AreEqual(PlayResult.FirstPlayer, game.DoPlay(Play.Paper, Play.Rock));
        }

        [TestMethod]
        public void RockIsCoveredByPaper()
        {
            Game game = new Game();

            Assert.AreEqual(PlayResult.SecondPlayer, game.DoPlay(Play.Rock, Play.Paper));
        }

        [TestMethod]
        public void RockCrushesLizard()
        {
            Game game = new Game();

            Assert.AreEqual(PlayResult.FirstPlayer, game.DoPlay(Play.Rock, Play.Lizard));
        }

        [TestMethod]
        public void LizardIsCrushedByRock()
        {
            Game game = new Game();

            Assert.AreEqual(PlayResult.SecondPlayer, game.DoPlay(Play.Lizard, Play.Rock));
        }

        [TestMethod]
        public void LizardPoisonsSpock()
        {
            Game game = new Game();

            Assert.AreEqual(PlayResult.FirstPlayer, game.DoPlay(Play.Lizard, Play.Spock));
        }

        [TestMethod]
        public void SpockIsPoisonedByLizard()
        {
            Game game = new Game();

            Assert.AreEqual(PlayResult.SecondPlayer, game.DoPlay(Play.Spock, Play.Lizard));
        }
    }
}
