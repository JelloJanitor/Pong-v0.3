using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallController : MonoBehaviour
{
    public Rigidbody2D rb;
    public GameManager gm;
    public float ballSpeed = 4f;
    public float maxInitialAngle = 0.67f;
    private float startX = 0f;
    public float startY = 4f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Invoke("Serve", 3);
    }

    // Update is called once per frame
    void Update()
    {
        ////
        //if (Mouse.current.leftButton.isPressed)
        //{
        //    Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());

        //    Vector2 currentPosition = transform.position;

        //    currentPosition.x = mousePosition
        //}
    }

    // Serve is called to start a volley
    // Sends the ball in a random direction after a brief delay
    private void Serve()
    {
        // Find the rigidbody component
        //rb = GetComponent<Rigidbody2D>();

        //
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        gm.SetScore(collision.tag);

        ResetBall();
        Invoke("Serve", 2);
    }

    private void ResetBall()
    {
        Vector2 direction = Vector2.zero;
        direction.y = Random.Range(-startY, startY);
        rb.transform.position = direction;
        rb.linearVelocity = Vector2.zero;
    }
}
