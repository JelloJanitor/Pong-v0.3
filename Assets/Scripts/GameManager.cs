using UnityEngine;

public class GameManager : MonoBehaviour
{
    ///public ScoreTextController textLeft, textRight;
    int scoreOfPlayer1 = 0, scoreOfPlayer2 = 0;
    public GameUIController gameUI;
    int winScore = 4;

    // Function that updates a score when player scores
    public void SetScore(string tag)
    {
        // Update right score when left zone entered
        if (tag == "LeftZone")
            scoreOfPlayer2++;
        // Update right score when left zone entered
        else if (tag == "RightZone")
            scoreOfPlayer1++;

        gameUI.UpdateScoreBoard(scoreOfPlayer1, scoreOfPlayer2);
    }

    public bool CheckWin()
    {
        int winnerId = scoreOfPlayer1 == winScore ? 1 : scoreOfPlayer2 == winScore ? 2 : 0;

        if (winnerId != 0)
        {
            gameUI.OnWin(winnerId);

            return true;
        }

        return false;
    }
}
