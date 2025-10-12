using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseControllerJump : MonoBehaviour
{
    public Rigidbody2D Mouse;
    public float jumpForce = 5f;
    public Transform groundCheck;   // an empty object placed slightly below the mouse
    public float checkRadius = 0.1f;
    public LayerMask groundLayer;   // assign your ground layer here

    private bool isGrounded;

    void Update()
    {
        // check if the mouse is on the ground
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);

        // jump only when grounded
        if (isGrounded && (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.UpArrow) || Input.GetMouseButtonDown(0)))
        {
            Mouse.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Mouse Trap"))
        {
            Debug.Log("Mouse Died");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
