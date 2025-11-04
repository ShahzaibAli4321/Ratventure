using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuManager : MonoBehaviour
{
    public void PlayNow()
    {
        MenuManager.score = 0;
        MenuManager.previousScene = 0;
        MenuManager.timeMultiplier = 1f;
        int a = Random.Range(3, 8);
        SceneManager.LoadScene(a);
    }
}
