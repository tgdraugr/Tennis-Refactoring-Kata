namespace Tennis
{
    public class TennisGame3 : ITennisGame
    {
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
            string s;
            if ((_player1Points < 4 && _player2Points < 4) && (_player1Points + _player2Points < 6))
            {
                string[] p = { "Love", "Fifteen", "Thirty", "Forty" };
                s = p[_player1Points];
                return (_player1Points == _player2Points) ? s + "-All" : s + "-" + p[_player2Points];
            }

            if (_player1Points == _player2Points)
                return "Deuce";
            s = _player1Points > _player2Points ? _player1Name : _player2Name;
            return ((_player1Points - _player2Points) * (_player1Points - _player2Points) == 1) ? "Advantage " + s : "Win for " + s;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _player1Points += 1;
            else
                _player2Points += 1;
        }
    }
}

