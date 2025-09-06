using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScoreTextController textLeft, textRight;
    int scoreLeft = 0, scoreRight = 0;

    public void SetScore(string tag)
    {
        if (tag == "LeftZone")
        {
            textRight.SetScore(++scoreRight);
        }
        else if (tag == "RightZone")
        {
            textLeft.SetScore(++scoreLeft);
        }
        else
        {
            Debug.Log("You dun goofed something up. Way to go genius.");
        }
    }
}
