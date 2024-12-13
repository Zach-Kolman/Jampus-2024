using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocWalk : MonoBehaviour
{
    public float walkSpeed = 2f; // Speed of movement
    public float walkDuration = 5f; // Duration to move in seconds

    private IEnumerator DocWalkRoutine()
    {
        float elapsedTime = 0f;

        // Move the object in the -x direction for the duration
        while (elapsedTime < walkDuration)
        {
            // Calculate movement step
            transform.Translate(Vector3.right * walkSpeed * Time.deltaTime);

            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait until the next frame
            yield return null;
        }
    }

    public void Walking()
    {
        StartCoroutine(DocWalkRoutine());
    }
}
