using UnityEngine;
using UnityEngine.UI; // for TextMeshPro

public class PipeGameManager : MonoBehaviour
{
    public float timeLimit = 4f;     // seconds for player to adjust pipes
    private float timer;
    private bool timeUp = false;

    public MouseControllerPipe mouseController; // reference to your mouse script
    public Text timerText;       // reference to TMP text object

    void Start()
    {
        timer = timeLimit;
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
        Debug.Log("Time's up! Mouse starts moving...");
        mouseController.MoveAlongPath(); // Let the mouse handle movement and falling logic
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

    public bool CanRotate()
    {
        return !timeUp; // Allow pipe rotation only before time runs out
    }
}
