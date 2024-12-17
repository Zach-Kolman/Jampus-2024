using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrancoisFollow : MonoBehaviour
{
    public Transform player; // Reference to the player's transform
    public float followDistance = 10f; // Distance at which the AI starts following
    public float stopDistance = 2f; // Distance at which the AI stops following
    public float moveSpeed = 3f; // AI movement speed
    public Animator animator; // Reference to the Animator component

    private bool isFollowing = false;

    void Update()
    {
        // Calculate the distance between the player and the AI
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Check if the AI should start following the player
        if (distanceToPlayer > followDistance)
        {
            isFollowing = true;
            animator.SetTrigger("Run"); // Trigger walk animation
        }
        // Check if the AI should stop following the player
        else if (distanceToPlayer < stopDistance)
        {
            isFollowing = false;
            animator.SetTrigger("Stop"); // Trigger stop animation
        }

        // If the AI is following, move towards the player
        if (isFollowing)
        {
            FollowPlayer();
        }
    }

    void FollowPlayer()
    {
        // Move towards the player
        Vector3 direction = (player.position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        // Optional: Rotate AI to face the player
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * moveSpeed);
    }
}
