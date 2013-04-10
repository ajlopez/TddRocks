namespace SpockGameTests
{
    [TestClass]
    public class GameTests
    {
        [TestMethod]
        public void ScissorsCutPaper()
        {
            Game game = new Game();

            Assert.AreEqual(PlayResult.FirstPlayer, game.Play(Play.Scissors, Play.Paper));
        }
    }
}
