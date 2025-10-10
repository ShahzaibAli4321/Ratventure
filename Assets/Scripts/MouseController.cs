using UnityEngine;
using System.Collections;

public class MouseController : MonoBehaviour
{
    public Transform[] pipes; // Assign pipe transforms in order from start to end
    public float moveSpeed = 2f;
    public float fallSpeed = 3f;

    public void MoveAlongPath()
    {
        StartCoroutine(MoveThroughPipes());
    }

    private IEnumerator MoveThroughPipes()
    {
        for (int i = 0; i < pipes.Length; i++)
        {
            Transform pipe = pipes[i];
            float zRotation = (pipe.eulerAngles.z + 360) % 360;

            // Check if the pipe is correctly placed (horizontal)
            bool isHorizontal = Mathf.Abs(zRotation) <= 5f || Mathf.Abs(zRotation - 180f) <= 5f;

            // Move towards current pipe
            while (Vector3.Distance(transform.position, pipe.position) > 0.05f)
            {
                transform.position = Vector3.MoveTowards(transform.position, pipe.position, moveSpeed * Time.deltaTime);
                yield return null;
            }

            // If the pipe is NOT horizontal — fall down here
            if (!isHorizontal)
            {
                Debug.Log($"Mouse fell at pipe {i + 1}");
                yield return StartCoroutine(FallDown(pipe.position));
                yield break;
            }

            yield return null;
        }

        Debug.Log("Mouse successfully passed all pipes!");
    }

    private IEnumerator FallDown(Vector3 startPos)
    {
        Vector3 targetPos = startPos + Vector3.down * 6f; // how far it falls
        while (Vector3.Distance(transform.position, targetPos) > 0.05f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, fallSpeed * Time.deltaTime);
            yield return null;
        }

        Debug.Log("Mouse fell down!");
    }
}
