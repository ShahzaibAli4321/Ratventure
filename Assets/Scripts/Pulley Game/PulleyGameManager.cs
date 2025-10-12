using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PulleyGameManager : MonoBehaviour
{
    public float timeLimit = 10f;
    private float timer;
    private bool timeUp = false;
    public Text timerText;

    public Transform mouse;
    public Transform pulley;
    public Transform cheese;
    public SpriteRenderer ropeHorizontal;
    public SpriteRenderer ropeVertical;

    private float totalRopeLength;

    void Start()
    {
        // Total rope length is the initial sum of both rope distances
        totalRopeLength = Vector2.Distance(mouse.position, pulley.position) +
                          Vector2.Distance(pulley.position, cheese.position);

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

            UpdateRopesAndCheese();
        }
    }

    void UpdateRopesAndCheese()
    {
        // Measure the horizontal rope (mouse to pulley)
        float horizontalLength = Vector2.Distance(mouse.position, pulley.position);

        // Remaining rope length goes vertically down from pulley to cheese
        float verticalLength = totalRopeLength - horizontalLength;

        // Clamp so it doesn’t go negative
        if (verticalLength < 0)
            verticalLength = 0f;

        // Move the cheese down based on remaining rope
        Vector3 cheesePos = pulley.position - new Vector3(0, verticalLength, 0);
        cheese.position = cheesePos;

        // Update horizontal rope
        Vector3 midHorizontal = (mouse.position + pulley.position) / 2f;
        ropeHorizontal.transform.position = midHorizontal;
        ropeHorizontal.size = new Vector2(0.3f, horizontalLength);

        // Update vertical rope
        Vector3 midVertical = (pulley.position + cheese.position) / 2f;
        ropeVertical.transform.position = midVertical;
        ropeVertical.size = new Vector2(0.3f, verticalLength);
    }

    void OnTimeUp()
    {
        Debug.Log("Time's up!");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int seconds = Mathf.FloorToInt(timer);
            int milliseconds = Mathf.FloorToInt((timer % 1) * 100);
            timerText.text = $"{seconds:00}:{milliseconds:00}";

            timerText.color = timer <= 1f ? Color.red : Color.white;
        }
    }
}
