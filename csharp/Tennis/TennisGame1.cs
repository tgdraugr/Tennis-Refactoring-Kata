namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int _score1 = 0;
        private int _score2 = 0;
        private string _player1Name;
        private string _player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                _score1 += 1;
            else
                _score2 += 1;
        }

        public string GetScore()
        {
            var score = "";
            if (_score1 == _score2)
            {
                score = _score1 switch
                {
                    0 => "Love-All",
                    1 => "Fifteen-All",
                    2 => "Thirty-All",
                    _ => "Deuce"
                };
            }
            else if (_score1 >= 4 || _score2 >= 4)
            {
                var minusResult = _score1 - _score2;
                score = minusResult switch
                {
                    1 => "Advantage player1",
                    -1 => "Advantage player2",
                    _ => minusResult >= 2 ? "Win for player1" : "Win for player2"
                };
            }
            else
            {
                for (var i = 1; i < 3; i++)
                {
                    int tempScore;
                    if (i == 1) tempScore = _score1;
                    else { score += "-"; tempScore = _score2; }
                    switch (tempScore)
                    {
                        case 0:
                            score += "Love";
                            break;
                        case 1:
                            score += "Fifteen";
                            break;
                        case 2:
                            score += "Thirty";
                            break;
                        case 3:
                            score += "Forty";
                            break;
                    }
                }
            }
            return score;
        }
    }
}

