using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject road;
    public float roadSpeed = 5.0f;

    private void FixedUpdate()
    {
        road.transform.Translate(Vector2.left * roadSpeed * Time.deltaTime);
    }
}
