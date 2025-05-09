using UnityEngine;
using UnityEngine.SceneManagement;

public class ZombieAI : MonoBehaviour
{
    public Transform player;
    public float speed = 2f;
    public float detectionRange = 10f;
    private bool isChasing = false;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        // Start chasing if player is in range
        if (distanceToPlayer < detectionRange)
        {
            isChasing = true;
        }

        if (isChasing)
        {
            // Calculate direction to player on the XZ plane (ignoring Y)
            Vector3 direction = (player.position - transform.position).normalized;
            direction.y = 0;  // Prevent floating

            // Calculate the new position while keeping the zombie grounded
            Vector3 move = direction * speed * Time.deltaTime;
            move.y = -0.1f;  // Slight downward force to keep grounded

            // Move using Character Controller
            controller.Move(move);

            // Make the zombie face the player without tilting up
            Vector3 lookDirection = new Vector3(player.position.x, transform.position.y, player.position.z);
            transform.LookAt(lookDirection);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player caught! Restarting level...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
