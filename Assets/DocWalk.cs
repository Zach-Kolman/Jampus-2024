using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DocWalk : MonoBehaviour
{
    public float walkSpeed = 2f; // Speed of movement
    public float walkDuration = 5f; // Duration to move in seconds
    public Vector3 walkDirection = Vector3.right; // Direction of movement (default: left/-X)

    private IEnumerator DocWalkRoutine()
    {
        float elapsedTime = 0f;

        // Move the object in the specified direction for the duration
        while (elapsedTime < walkDuration)
        {
            // Calculate movement step based on direction
            transform.Translate(walkDirection.normalized * walkSpeed * Time.deltaTime);

            // Update the elapsed time
            elapsedTime += Time.deltaTime;

            // Wait until the next frame
            yield return null;
        }

        GetComponent<Animator>().SetTrigger("Stop");
    }

    public void Walking()
    {
        StartCoroutine(DocWalkRoutine());
    }

    public void ReverseWalk()
    {
        walkDirection = -walkDirection;
    }
}
