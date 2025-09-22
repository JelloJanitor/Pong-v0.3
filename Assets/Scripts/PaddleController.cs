using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;

public class PaddleController : MonoBehaviour
{
    public Rigidbody2D rb;
    public int playerId;
    public float moveSpeed = 700f;

    private Vector2 moveDirection;

    public InputActionReference move;

    // Enable input actions
    private void OnEnable()
    {
        move.action.Enable();
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
