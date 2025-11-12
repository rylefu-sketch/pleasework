using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StareTrigger : MonoBehaviour
{
    public StareAtPlayer[] lookers; // Assign objects that will stare at the player

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Goes through each looker assigned and starts their staring behavior
            foreach (StareAtPlayer looker in lookers)
            {
                if (looker != null)
                    looker.StartStaring();
            }

            Destroy(gameObject); // Removes the collected item after activation
        }
    }
}
