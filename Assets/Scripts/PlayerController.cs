using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust the speed of movement
    private CharacterController controller;
    private Animator animator;
    private float verticalVelocity = 0f;
    public AudioClip footstepAudio;

    // Reference to the camera
    public Transform cameraTransform;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();

        // If cameraTransform is not set, automatically find the main camera
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        // Get input from the player
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Set the move direction based on input
        Vector3 inputDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Convert the input direction relative to the camera's orientation
        Vector3 moveDirection = (cameraTransform.right * inputDirection.x + cameraTransform.forward * inputDirection.z).normalized;

        // Ignore vertical movement (as we want to move on a flat plane)
        moveDirection.y = 0f;

        // Apply fake gravity to ensure the player stays grounded
        if (controller.isGrounded)
        {
            verticalVelocity = 0f; // Reset vertical velocity
        }
        else
        {
            // Apply downward force when not grounded
            verticalVelocity -= 9.81f * Time.deltaTime; // Adjust gravity as needed
        }

        // Combine horizontal movement with vertical velocity
        Vector3 movement = moveDirection * moveSpeed + Vector3.up * verticalVelocity;

        // Set isMoving parameter in the Animator controller
        animator.SetBool("isMoving", inputDirection.magnitude > 0);

        // Move the player based on the combined movement vector
        controller.Move(movement * Time.deltaTime);

        // Rotate the player based on movement direction
        if (moveDirection != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }
    }

    public void Footstep()
    {
        StartCoroutine(FootstepRoutine());
    }

    private IEnumerator FootstepRoutine()
    {
        AudioSource footstepSource = gameObject.AddComponent<AudioSource>();

        footstepSource.pitch = Random.Range(0.55f, 1f);
        footstepSource.clip = footstepAudio;
        footstepSource.Play();

        yield return new WaitForSeconds(footstepAudio.length);

        Destroy(footstepSource);
    }

    public void MoveToNPCSpot(GameObject npcTalkSpot)
    {
        transform.position = npcTalkSpot.transform.position;
        transform.rotation = npcTalkSpot.transform.rotation;
    }
}
