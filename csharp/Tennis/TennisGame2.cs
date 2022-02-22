namespace Tennis
{
    public class TennisGame2 : ITennisGame
    {
        private int _p1Point;
        private int _p2Point;

        private string _p1Res = "";
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
            var score = "";
            if (_p1Point == _p2Point && _p1Point < 3)
            {
                score = _p1Point switch
                {
                    0 => "Love",
                    1 => "Fifteen",
                    2 => "Thirty",
                    _ => score
                };
                score += "-All";
            }
            
            if (_p1Point == _p2Point && _p1Point > 2)
                score = "Deuce";

            if (_p1Point > 0 && _p2Point == 0)
            {
                _p1Res = _p1Point switch
                {
                    1 => "Fifteen",
                    2 => "Thirty",
                    3 => "Forty",
                    _ => _p1Res
                };

                _p2Res = "Love";
                score = _p1Res + "-" + _p2Res;
            }
            
            if (_p2Point > 0 && _p1Point == 0)
            {
                _p2Res = _p2Point switch
                {
                    1 => "Fifteen",
                    2 => "Thirty",
                    3 => "Forty",
                    _ => _p2Res
                };

                _p1Res = "Love";
                score = _p1Res + "-" + _p2Res;
            }

            if (_p1Point > _p2Point && _p1Point < 4)
            {
                _p1Res = _p1Point switch
                {
                    2 => "Thirty",
                    3 => "Forty",
                    _ => _p1Res
                };
                _p2Res = _p2Point switch
                {
                    1 => "Fifteen",
                    2 => "Thirty",
                    _ => _p2Res
                };
                score = _p1Res + "-" + _p2Res;
            }
            
            if (_p2Point > _p1Point && _p2Point < 4)
            {
                _p2Res = _p2Point switch
                {
                    2 => "Thirty",
                    3 => "Forty",
                    _ => _p2Res
                };
                _p1Res = _p1Point switch
                {
                    1 => "Fifteen",
                    2 => "Thirty",
                    _ => _p1Res
                };
                score = _p1Res + "-" + _p2Res;
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
    }
}

