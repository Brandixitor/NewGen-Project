using UnityEngine;

public class MushroomPickup : MonoBehaviour
{
    public float KillRadius = 2f; // The radius within which the player can pick up the mushroom
    private bool CanBeKilled = false; // Whether the mushroom can be picked up

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Calculate the distance between the player and the mushroom
            float distance = Vector3.Distance(transform.position, other.transform.position);

            // If the player is within the pickup radius and presses the "E" key, pick up the mushroom
            if (distance <= KillRadius && Input.GetKeyDown(KeyCode.E))
            {
                Destroy(gameObject); // Destroy the mushroom GameObject
            }
        }
    }
}
