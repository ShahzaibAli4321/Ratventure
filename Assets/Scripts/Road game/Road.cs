using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject road;
    public float roadSpeed = 5.0f;

    private void FixedUpdate()
    {
        float adjustedSpeed = roadSpeed / MenuManager.timeMultiplier;
        road.transform.Translate(Vector2.left * adjustedSpeed * Time.deltaTime);

        //road.transform.Translate(Vector2.left * (roadSpeed * (2 - MenuManager.timeMultiplier)) * Time.deltaTime);
    }
}
