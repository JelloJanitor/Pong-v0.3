using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PaddleController : MonoBehaviour
{
    public Rigidbody2D rb;
    public int playerId;
    //public float paddleInitialY = 0;
    //public float paddleInitialX = 8.5f;
    public float moveSpeed = 700f;
    private Vector2 moveDirection;

    private Vector2 startPosition;

    public BallController ball;

    public InputActionReference move;

    // Subscribe to GameManager
    private void OnEnable()
    {
        startPosition = transform.position;
        GameManager.Instance.OnGameStart += EnableInput;
        GameManager.Instance.OnGameOver += ResetPaddles;
    }

    // Enable paddle input
    private void EnableInput()
    {
        move.action.Enable();
    }
    
    // Disable paddle input
    private void ResetPaddles(int _winnerId)
    {
        transform.position = new Vector2(startPosition.x, 0.0f);
        move.action.Disable();
    }

    // Get user input
    private void Update()
    {
        if (playerId == 2 && GameManager.Instance.playMode == GameManager.PlayMode.PlayerVsCPU)
        {
            //MoveCPU();
            if (transform.position.y - ball.transform.position.y > 20)
            {
                moveDirection = new Vector2(0.0f, 1.0f);
            }
            else if (transform.position.y - ball.transform.position.y < -20)
            {
                moveDirection = new Vector2(0.0f, -1.0f);
            }
            else
            {
                moveDirection = new Vector2(0.0f, 0.0f);
            }
        }
        else
        {
            moveDirection = move.action.ReadValue<Vector2>();
        }
    }

    // Move paddle
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, moveDirection.y * moveSpeed);
    }

    private void MoveCPU()
    {
        Vector2 ballPosition = ball.transform.position;
        transform.position = new Vector2(startPosition.x, ballPosition.y);
    }
}
