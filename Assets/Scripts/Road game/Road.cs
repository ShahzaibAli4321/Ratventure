using UnityEngine;

public class Road : MonoBehaviour
{
    public GameObject road;
    public float roadSpeed = 5.0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        road.transform.Translate(Vector2.left * roadSpeed * Time.deltaTime);
    }
}
