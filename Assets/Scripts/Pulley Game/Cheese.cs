using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheese : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Finish"))
        {
            Debug.Log("Win");
            MenuManager.score++;
            SceneManager.LoadScene(1);
        }

        if (collision.collider.CompareTag("Mouse Trap"))
        {
            Debug.Log("Lose");
            SceneManager.LoadScene(2);
        }
    }
}
