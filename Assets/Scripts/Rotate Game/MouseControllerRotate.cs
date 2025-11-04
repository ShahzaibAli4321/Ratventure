using UnityEngine;
using UnityEngine.SceneManagement;

public class MouseControllerRotate : MonoBehaviour
{
    public float grabDistance = 2f;      // how far forward it moves
    public float grabSpeed = 5f;         // how fast it moves forward
    public float returnSpeed = 5f;       // how fast it moves back

    private Vector3 originalPosition;
    private Vector3 targetPosition;
    private bool isGrabbing = false;
    private bool isReturning = false;

    public LayerMask Cheese;
    public LayerMask MouseTrap;

    void Start()
    {
        originalPosition = transform.position;
    }

    void Update()
    {
        // Start the grab when Space or Left Click is pressed
        if (!isGrabbing && !isReturning && (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0)))
        {
            targetPosition = transform.position + Vector3.right * grabDistance; // move right
            isGrabbing = true;
        }

        // Move forward
        if (isGrabbing)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, grabSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, targetPosition) < 0.01f)
            {
                isGrabbing = false;
                isReturning = true;
            }
        }

        // Move back
        if (isReturning)
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPosition, returnSpeed * Time.deltaTime);
            if (Vector3.Distance(transform.position, originalPosition) < 0.01f)
            {
                isReturning = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Mouse Trap"))
        {
            Debug.Log("Mouse died");
            SceneManager.LoadScene(2);
        }

        if (collision.collider.CompareTag("Cheese"))
        {
            Debug.Log("Mouse Won");
            MenuManager.score++;
            SceneManager.LoadScene(1);
        }
    }
}
