using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RotateGameManager : MonoBehaviour
{
    public float timeLimit = 10f;     // seconds for player to adjust pipes
    private float timer;
    private bool timeUp = false;
    public Text timerText;       // reference to TMP text object

    void Start()
    {
        MenuManager.previousScene = SceneManager.GetActiveScene().buildIndex;
        timer = timeLimit * MenuManager.timeMultiplier;
        UpdateTimerUI();
    }

    void Update()
    {
        if (!timeUp)
        {
            timer -= Time.deltaTime;
            UpdateTimerUI();

            if (timer <= 0f)
            {
                timeUp = true;
                timer = 0f;
                UpdateTimerUI();
                OnTimeUp();
            }
        }
    }

    void OnTimeUp()
    {
        Debug.Log("Time's up!");
        SceneManager.LoadScene(2);
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int seconds = Mathf.FloorToInt(timer);
            int milliseconds = Mathf.FloorToInt((timer % 1) * 100);

            timerText.text = $"{seconds:00}:{milliseconds:00}";

            if (timer <= 1f)
                timerText.color = Color.red;
            else
                timerText.color = Color.white;

        }
    }
}
