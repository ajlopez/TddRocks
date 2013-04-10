namespace SpockGame
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Game
    {
        public PlayResult DoPlay(Play first, Play second)
        {
            if (first == second)
                return PlayResult.Tie;

            if (first == Play.Scissors)
                return PlayResult.FirstPlayer;

            return PlayResult.SecondPlayer;
        }
    }
}
