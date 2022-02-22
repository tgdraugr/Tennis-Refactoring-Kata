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

            var score = "";

            if (_p1Point > 0 && _p2Point == 0 || 
                _p2Point > 0 && _p1Point == 0 || 
                _p1Point > _p2Point && _p1Point < 4 ||
                _p2Point > _p1Point && _p2Point < 4)
            {
                score = GetDesignationFrom(_p1Point) + "-" + GetDesignationFrom(_p2Point);
            }

            if (_p1Point > _p2Point && _p2Point >= 3)
            {
                score = $"Advantage {_player1Name}";
            }

            if (_p2Point > _p1Point && _p1Point >= 3)
            {
                score = $"Advantage {_player2Name}";
            }

            if (_p1Point >= 4 && _p2Point >= 0 && (_p1Point - _p2Point) >= 2)
            {
                score = $"Win for {_player1Name}";
            }
            
            if (_p2Point >= 4 && _p1Point >= 0 && (_p2Point - _p1Point) >= 2)
            {
                score = $"Win for {_player2Name}";
            }
            
            return score;
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
