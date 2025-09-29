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

    public InputActionReference move;

    // Subscribe to GameManager
    private void OnEnable()
    {
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
        move.action.Disable();
    }

    // Get user input
    private void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();
    }

    // Move paddle
    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, moveDirection.y * moveSpeed);
    }
}
