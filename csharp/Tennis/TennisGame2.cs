namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _p1Point;
        private int _p2Point;

        private string _p2Res = "";
        private readonly string _player1Name;
        private readonly string _player2Name;

        public TennisGame2(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
            _p1Point = 0;
        }

        public void WonPoint(string player)
        {
            if (player == _player1Name)
                _p1Point++;
            else
                _p2Point++;
        }

        public string GetScore()
        {
            if (_p1Point == _p2Point)
            {
                if (_p1Point >= 3)
                    return "Deuce";
                
                return GetDesignationFrom(_p1Point) + "-All";
            }
            
            if (OnePlayerHasWon())
            {
                return _p1Point - _p2Point >= 2 ? 
                    $"Win for {_player1Name}" : 
                    $"Win for {_player2Name}";
            }
            
            if (OnePlayerHasAdvantage())
            {
                return _p1Point > _p2Point ? 
                    $"Advantage {_player1Name}" : 
                    $"Advantage {_player2Name}";
            }
            
            return GetDesignationFrom(_p1Point) + "-" + GetDesignationFrom(_p2Point);
        }

        private bool OnePlayerHasAdvantage()
        {
            return _p1Point > _p2Point && _p2Point >= 3 || 
                   _p2Point > _p1Point && _p1Point >= 3;
        }

        private bool OnePlayerHasWon()
        {
            return _p1Point >= 4 && _p1Point - _p2Point >= 2 || 
                   _p2Point >= 4 && _p2Point - _p1Point >= 2;
        }

        private static string GetDesignationFrom(int score)
        {
            return score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                3 => "Forty",
                _ => ""
            };
        }
    }
}
