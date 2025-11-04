using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MouseControllerPulley : MonoBehaviour
{
    public float baseSpeed = 2f;            // target rightward speed
    public float recoverRate = 3f;          // how fast the velocity returns to baseSpeed
    public float pushForce = 3f;            // impulse applied left on input
    public float maxSpeed = 6f;             // clamp so it doesn't go crazy

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        // recommended: gravity 0 if you don't want vertical physics
        // rb.gravityScale = 0f;
    }

    void FixedUpdate()
    {
        // Smoothly move current x-velocity towards baseSpeed, without instantly overwriting impulses
        float currentX = rb.linearVelocity.x;
        float targetX = baseSpeed;

        // Interpolate the x velocity toward targetX
        float newX = Mathf.Lerp(currentX, targetX, recoverRate * Time.fixedDeltaTime);

        // Clamp horizontal speed to avoid runaway values
        newX = Mathf.Clamp(newX, -maxSpeed, maxSpeed);

        rb.linearVelocity = new Vector2(newX, rb.linearVelocity.y);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space))
        {
            // Apply a left impulse; this will change rb.velocity.x and the FixedUpdate Lerp will
            // bring it back toward baseSpeed over time, so the push is visible.
            rb.AddForce(Vector2.left * pushForce, ForceMode2D.Impulse);
        }
    }
}
