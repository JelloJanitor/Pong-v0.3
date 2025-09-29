using System;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class GameUIController : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject gameMenu;
    public ScoreTextController scoreTextPlayer1, scoreTextPlayer2;
    public TextMeshProUGUI startButtonText;
    public TextMeshProUGUI winText;

    // Subscribe to GameManager
    public void OnEnable()
    {
        GameManager.Instance.OnScore += UpdateScoreBoard;
        GameManager.Instance.OnGameOver += OnWin;
    }

    // Updates both score displays with currrent score
    public void UpdateScoreBoard(int scoreOfPlayer1, int scoreOfPlayer2)
    {
        scoreTextPlayer1.SetScore(scoreOfPlayer1);
        scoreTextPlayer2.SetScore(scoreOfPlayer2);
    }

    // Recieves start button input an startes a serve
    public void OnStartButtonClicked()
    {
        scoreTextPlayer1.SetScore(0);
        scoreTextPlayer2.SetScore(0);
        gameMenu.SetActive(false);
        GameManager.Instance.StartGame();
    }

    // Brings up the menu again and displays the winner
    public void OnWin(int winnerId)
    {
        gameMenu.SetActive(true);
        startButtonText.text = $"Play Again";
        winText.text = $"Player {winnerId} wins!";
    }
}
