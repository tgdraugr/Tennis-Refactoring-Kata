using System.Collections.Generic;

namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private const int MinPointsToWin = 3;

        private static readonly Dictionary<int, string> DesignationByScore =
            new Dictionary<int, string>
            {
                { 0, "Love" },
                { 1, "Fifteen" },
                { 2, "Thirty" },
                { 3, "Forty" }
            };
        
        private int _score1;
        private int _score2;
        private readonly string _player1Name;
        private readonly string _player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name)
                _score1 += 1;
            else
                _score2 += 1;
        }

        public string GetScore()
        {
            if (_score1 == _score2)
            {
                return GetTieScore();
            }

            if (AtLeastThreePointsScored())
            {
                return GetScoreWithAdvantage(_score1 - _score2);
            }
            
            return DesignationByScore[_score1] + "-" + DesignationByScore[_score2];
        }

        private bool AtLeastThreePointsScored()
        {
            return _score1 > MinPointsToWin || _score2 > MinPointsToWin;
        }

        private string GetTieScore()
        {
            return _score1 switch
            {
                0 => $"{DesignationByScore[_score1]}-All",
                1 => $"{DesignationByScore[_score1]}-All",
                2 => $"{DesignationByScore[_score1]}-All",
                _ => "Deuce"
            };
        }

        private string GetScoreWithAdvantage(int margin)
        {
            return margin switch
            {
                1 => $"Advantage {_player1Name}",
                -1 => $"Advantage {_player2Name}",
                _ => margin >= 2 ? $"Win for {_player1Name}" : $"Win for {_player2Name}"
            };
        }
    }
}
