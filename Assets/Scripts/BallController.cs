using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameManager gm;
    public float ballSpeed = 1200f;
    public float maxInitialAngle = 0.67f;
    private float startX = 0f;
    public float startY = 4f;

    // Serve is called to start a volley
    // Sends the ball in a random direction after a brief delay
    public void Serve()
    {
        // Direction vector for ball randomized between left and right serve
        Vector2 direction = Vector2.left;

        // Generate random (x, y) vector2
        if (Random.value > 0.5)
        {
            direction = Vector2.right;
        }
        direction.y = Random.Range(-maxInitialAngle, maxInitialAngle);

        //rb.AddForce(direction);
        rb.linearVelocity = direction * ballSpeed;

        // rigidbody.linearVelocity(x,y)
    }

    // Detects collision with score zones and updates score
    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Detects collision
        if (collision != null)
            gm.SetScore(collision.tag); // Passes score zone tag

        // If the win condition is not met, serves again
        if (!gm.CheckWin())
        {
            ResetBall();
            Invoke("Serve", 2);
        }
    }

    // Resets ball for serve
    public void ResetBall()
    {
        Vector2 direction = Vector2.zero;
        direction.y = Random.Range(-startY, startY);
        rb.transform.position = direction;
        rb.linearVelocity = Vector2.zero;
    }
}
