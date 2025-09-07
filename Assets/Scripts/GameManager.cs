using UnityEngine;

public class GameManager : MonoBehaviour
{
    public ScoreTextController textLeft, textRight;
    int scoreLeft = 0, scoreRight = 0;

    // Function that updates a score when player scores
    public void SetScore(string tag)
    {
        // Update right score when left zone entered
        if (tag == "LeftZone")
        {
            textRight.SetScore(++scoreRight);
            Debug.Log("Ball entered the left score zone!");
        }
        // Update right score when left zone entered
        else if (tag == "RightZone")
        {
            textLeft.SetScore(++scoreLeft);
            Debug.Log("Ball entered the right score zone!");
        }
        else
        {
            Debug.Log("You dun goofed something up. Way to go genius.");
        }
    }
}
