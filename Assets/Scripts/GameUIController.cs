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

    //private void Start()
    //{
    //    gameMenu.SetActive(false);
    //}

    public void UpdateScoreBoard(int scoreOfPlayer1, int scoreOfPlayer2)
    {
        scoreTextPlayer1.SetScore(scoreOfPlayer1);
        scoreTextPlayer2.SetScore(scoreOfPlayer2);
    }

    public void OnStartButtonClicked()
    {
        Console.WriteLine("Heyo");
        gameMenu.SetActive(false);
        ball.Invoke("Serve", 3); // CHECK TO MAKE SURE IT WORKS
    }

    public void OnWin(int winnerId)
    {
        gameMenu.SetActive(true);
        startButtonText.text = $"Play Again";
        winText.text = $"Player {winnerId} wins!";
    }
}
