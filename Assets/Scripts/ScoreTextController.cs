using UnityEngine;
using TMPro;

public class ScoreTextController : MonoBehaviour
{
    public TextMeshProUGUI TextMex;

    public void SetScore(int score)
    {
        TextMex.text = score.ToString();
    }
}
