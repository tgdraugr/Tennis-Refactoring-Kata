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
                if (_p1Point == 0)
                    score = "Love";
                if (_p1Point == 1)
                    score = "Fifteen";
                if (_p1Point == 2)
                    score = "Thirty";
                score += "-All";
            }
            if (_p1Point == _p2Point && _p1Point > 2)
                score = "Deuce";

            if (_p1Point > 0 && _p2Point == 0)
            {
                if (_p1Point == 1)
                    _p1Res = "Fifteen";
                if (_p1Point == 2)
                    _p1Res = "Thirty";
                if (_p1Point == 3)
                    _p1Res = "Forty";

                _p2Res = "Love";
                score = _p1Res + "-" + _p2Res;
            }
            if (_p2Point > 0 && _p1Point == 0)
            {
                if (_p2Point == 1)
                    _p2Res = "Fifteen";
                if (_p2Point == 2)
                    _p2Res = "Thirty";
                if (_p2Point == 3)
                    _p2Res = "Forty";

                _p1Res = "Love";
                score = _p1Res + "-" + _p2Res;
            }

            if (_p1Point > _p2Point && _p1Point < 4)
            {
                if (_p1Point == 2)
                    _p1Res = "Thirty";
                if (_p1Point == 3)
                    _p1Res = "Forty";
                if (_p2Point == 1)
                    _p2Res = "Fifteen";
                if (_p2Point == 2)
                    _p2Res = "Thirty";
                score = _p1Res + "-" + _p2Res;
            }
            if (_p2Point > _p1Point && _p2Point < 4)
            {
                if (_p2Point == 2)
                    _p2Res = "Thirty";
                if (_p2Point == 3)
                    _p2Res = "Forty";
                if (_p1Point == 1)
                    _p1Res = "Fifteen";
                if (_p1Point == 2)
                    _p1Res = "Thirty";
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

