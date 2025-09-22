using System;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUIController : MonoBehaviour
{
    public ScoreTextController scoreTextPlayer1, scoreTextPlayer2;
    public GameObject gameMenu;
    public TextMeshProUGUI startButtonText;
    public BallController ball;
    public TextMeshProUGUI winText;

    // Updates both score displays with currrent score
    public void UpdateScoreBoard(int scoreOfPlayer1, int scoreOfPlayer2)
    {
        scoreTextPlayer1.SetScore(scoreOfPlayer1);
        scoreTextPlayer2.SetScore(scoreOfPlayer2);
    }

    // Recieves start button input an startes a serve
    public void OnStartButtonClicked()
    {
        Console.WriteLine("Heyo");
        gameMenu.SetActive(false);
        ball.Invoke("Serve", 3); // CHECK TO MAKE SURE IT WORKS
    }

    // Brings up the menu again and displays the winner
    public void OnWin(int winnerId)
    {
        gameMenu.SetActive(true);
        startButtonText.text = $"Play Again";
        winText.text = $"Player {winnerId} wins!";
    }
}
