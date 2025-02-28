using UnityEngine;

public class BallController : MonoBehaviour
{
    public float speed = 8f;
    public float maxSpeed = 10f;
    public float jumpForce = 9f;
    public float fallMultiplier = 3f;
    public float airControl = 0.5f;

    private Rigidbody rb;
    private bool isGrounded;
    private bool canDoubleJump;
    private float moveInput = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX;
        rb.interpolation = RigidbodyInterpolation.Interpolate;
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;
    }

    void Update()
    {
        if (isGrounded)
        {
            rb.AddForce(new Vector3(moveInput * speed, 0, 0), ForceMode.Acceleration);
        }
        else
        {
            rb.AddForce(new Vector3(moveInput * speed * airControl, 0, 0), ForceMode.Acceleration);
        }

        rb.linearVelocity = new Vector3(Mathf.Clamp(rb.linearVelocity.x, -maxSpeed, maxSpeed), rb.linearVelocity.y, rb.linearVelocity.z);

        if (rb.linearVelocity.y < 0)
        {
            rb.linearVelocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
    }

    public void MoveLeft() => moveInput = -1f;
    public void MoveRight() => moveInput = 1f;
    public void StopMoving() => moveInput = 0f;

    public void Jump()
    {
        if (isGrounded)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            canDoubleJump = true;
        }
        else if (canDoubleJump)
        {
            rb.linearVelocity = new Vector3(rb.linearVelocity.x, jumpForce, rb.linearVelocity.z);
            canDoubleJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            canDoubleJump = false;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
