using UnityEngine;

public class Pipe : MonoBehaviour
{
    private bool isRotating = false;
    private Quaternion targetRotation;

    void Start()
    {
        targetRotation = transform.rotation;
    }

    void OnMouseDown()
    {
        if (!isRotating)
        {
            targetRotation *= Quaternion.Euler(0, 0, 90);
            isRotating = true;
            Debug.Log("Clicked");
        }
    }

    void Update()
    {
        if (isRotating)
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * 8f);

            if (Quaternion.Angle(transform.rotation, targetRotation) < 0.1f)
            {
                transform.rotation = targetRotation;
                isRotating = false;
            }
        }
    }
}
