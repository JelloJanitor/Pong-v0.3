using UnityEngine;
using TMPro;

public class ScoreTextController : MonoBehaviour
{
    public TextMeshProUGUI TextMex;

    // Function for GameManager to call to update the displayed score
    public void SetScore(int score)
    {
        TextMex.text = score.ToString();
    }
}
