using UnityEngine;

public class MouseController : MonoBehaviour
{
    public float MouseSpeed = 7.0f;
    public LayerMask MouseTrap;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.DownArrow) && transform.position.y >= -2.1f)
        {
            transform.Translate(Vector2.down * MouseSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.UpArrow) && transform.position.y <= 2.1f)
        {
            transform.Translate(Vector2.up * MouseSpeed * Time.deltaTime);
        }

        // Check for overlap
        Collider2D hit = Physics2D.OverlapCircle(transform.position, 1f, MouseTrap);
        if (hit != null)
        {
            Debug.Log("Mouse died");
            Time.timeScale = 0f;
        }
    }
}
