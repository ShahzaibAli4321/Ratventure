using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public static int previousScene = 0;
    public static float timeMultiplier = 1f;

    public Text ScoreText;
    public static int score = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ScoreText.text = score.ToString();



        if (score % 5 == 0 && score != 0 && timeMultiplier >= 0.4f)
        {
            timeMultiplier -= 0.1f;
        }

        Debug.Log(score);
        Debug.Log(timeMultiplier);
        Debug.Log(previousScene);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void NextLevel()
    {
        int a = Random.Range(3, 8);
        while (a == previousScene)
        {
            a = Random.Range(3, 8);
        }
        SceneManager.LoadScene(a);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void Retry()
    {
        SceneManager.LoadScene(previousScene);
    }
}
