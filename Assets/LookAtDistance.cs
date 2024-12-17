using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class LookAtDistance : MonoBehaviour
{
    private float distanceFromPlayer;

    private Transform player;

    private bool inRange = false;

    public LookAtConstraint lookAt;

    public float thresholdValue = 5f;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        distanceFromPlayer = Vector3.Distance(transform.position, player.position);

        lookAt.enabled = distanceFromPlayer < thresholdValue;

       
    }
}
