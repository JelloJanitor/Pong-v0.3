using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;

    // Establishes singleton GameManager
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject obj = new GameObject("GameManager");
                _instance = obj.AddComponent<GameManager>();
                DontDestroyOnLoad(obj);
            }

            return _instance;
        }
    }

    // Establishes actions
    public Action OnGameStart;
    public Action<int, int> OnScore;
    public Action<int> OnGameOver;

    int scoreOfPlayer1 = 0, scoreOfPlayer2 = 0;
    public int winScore = 4;

    // Used when the player starts a new game
    public void StartGame()
    {
        scoreOfPlayer1 = 0;
        scoreOfPlayer2 = 0;
        OnGameStart?.Invoke();
    }

    // Function that updates a score when player scores
    public void UpdateScore(string tag)
    {
        // Update right score when left zone entered
        if (tag == "LeftZone")
            scoreOfPlayer2++;
        // Update right score when left zone entered
        else if (tag == "RightZone")
            scoreOfPlayer1++;

        //gameUI.UpdateScoreBoard(scoreOfPlayer1, scoreOfPlayer2);
        OnScore?.Invoke(scoreOfPlayer1, scoreOfPlayer2);
    }

    // Checks if either player 1 or 2 has reached a winning score
    public bool CheckWin()
    {
        // Checks if there is a winner
        int winnerId = scoreOfPlayer1 == winScore ? 1 : scoreOfPlayer2 == winScore ? 2 : 0;

        // If a win condition was met enter the menu
        if (winnerId != 0)
        {
            OnGameOver?.Invoke(winnerId);

            return true;
        }

        return false;
    }
}
