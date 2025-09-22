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

    private void OnEnable()
    {
        move.action.Enable();
    }

    private void Update()
    {
        moveDirection = move.action.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(0, moveDirection.y * moveSpeed);
    }

    /*void Update()
    {
        float axisValue = GetAxisValue();
        MovePaddle(axisValue);
    }

    private void MovePaddle(float axisValue)
    {
        Vector2 velocity = rb.linearVelocity;
        velocity.y = axisValue * moveSpeed;
        rb.linearVelocity = velocity;
    }

    private float GetAxisValue()
    {
        float axisValue = 0f;

        if (playerId == 1) axisValue = Input.GetAxis("PaddlePlayer1");
        else if (playerId == 2) axisValue = Input.GetAxis("PaddlePlayer2");

        return axisValue;
    }*/
}
