using UnityEngine;

public class FootstepSound : MonoBehaviour
{
    public AudioSource walkSound;
    public AudioSource runSound;
    public float walkInterval = 0.5f;
    public float runInterval = 0.3f;

    private float footstepTimer;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Check if the player is grounded and moving
        if (controller.isGrounded && controller.velocity.magnitude > 0.1f)
        {
            footstepTimer -= Time.deltaTime;

            // Running sound (holding Shift)
            if (Input.GetKey(KeyCode.LeftShift) && controller.velocity.magnitude > 2f)
            {
                if (footstepTimer <= 0)
                {
                    PlaySound(runSound);
                    footstepTimer = runInterval;
                }
            }
            // Walking sound (not holding Shift)
            else if (controller.velocity.magnitude > 0.1f)
            {
                if (footstepTimer <= 0)
                {
                    PlaySound(walkSound);
                    footstepTimer = walkInterval;
                }
            }
        }
        else
        {
            // Stop both sounds when not moving
            StopSounds();
        }
    }

    void PlaySound(AudioSource sound)
    {
        if (!sound.isPlaying)
        {
            sound.Play();
        }
    }

    void StopSounds()
    {
        if (walkSound.isPlaying) walkSound.Stop();
        if (runSound.isPlaying) runSound.Stop();
    }
}
