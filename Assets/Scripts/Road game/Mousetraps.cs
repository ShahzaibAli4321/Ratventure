using UnityEngine;

public class Mousetraps : MonoBehaviour
{
    bool up = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        up = Random.value > 0.5f;

        Vector2 pos = transform.position; // get current position
        pos.y = up ? 2.0f : -2.0f;        // modify Y
        transform.position = pos;          // apply back
    }
}
