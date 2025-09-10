using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public Rigidbody2D rb;
    public int playerId;
    public float moveSpeed = 5f;

    void Update()
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
    }
}
