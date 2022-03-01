namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
        private static readonly string[] PossibleScores = { "Love", "Fifteen", "Thirty", "Forty" };
        
        private int _player1Points;
        private int _player2Points;
        private readonly string _player1Name;
        private readonly string _player2Name;

        public TennisGame3(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public string GetScore()
        {
            if (_player1Points < 4 && _player2Points < 4 && _player1Points + _player2Points < 6)
            {
                return _player1Points == _player2Points ? 
                    PossibleScores[_player1Points] + "-All" : 
                    PossibleScores[_player1Points] + "-" + PossibleScores[_player2Points];
            }

            if (_player1Points == _player2Points)
                return "Deuce";

            return (_player1Points - _player2Points) * (_player1Points - _player2Points) == 1 ? 
                "Advantage " + GetPlayerNameInAdvantage() : 
                "Win for " + GetPlayerNameInAdvantage();
        }

        private string GetPlayerNameInAdvantage()
        {
            return _player1Points > _player2Points ? _player1Name : _player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name)
                _player1Points += 1;
            else
                _player2Points += 1;
        }
    }
}

