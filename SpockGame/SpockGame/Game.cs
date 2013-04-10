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

            if (first == Play.Spock && (second == Play.Scissors || second == Play.Rock))
                return PlayResult.FirstPlayer;

            if (first == Play.Scissors && (second == Play.Paper || second == Play.Lizard))
                return PlayResult.FirstPlayer;

            if (first == Play.Paper && (second == Play.Rock || second == Play.Spock))
                return PlayResult.FirstPlayer;

            if (first == Play.Rock && (second == Play.Lizard || second == Play.Scissors))
                return PlayResult.FirstPlayer;

            if (first == Play.Lizard && (second == Play.Spock || second == Play.Paper))
                return PlayResult.FirstPlayer;

            return PlayResult.SecondPlayer;
        }
    }
}
