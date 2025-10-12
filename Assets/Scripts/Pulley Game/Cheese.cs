using UnityEngine;
using UnityEngine.SceneManagement;

public class Cheese : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Finish"))
        {
            Debug.Log("Win");
            int i = Random.Range(0, 5);
            while (i == SceneManager.GetActiveScene().buildIndex)
            {
                i = Random.Range(0, 5);
            }
            SceneManager.LoadScene(i);
        }

        if (collision.collider.CompareTag("Mouse Trap"))
        {
            Debug.Log("Lose");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
