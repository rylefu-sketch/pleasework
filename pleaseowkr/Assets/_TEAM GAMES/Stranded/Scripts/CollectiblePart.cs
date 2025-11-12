using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePart : MonoBehaviour
{
    public string partID;           // Unique identifier for the part, like "PowerCell" or "EngineCore"
    public float pickupRange = 3f;  // Distance within which the player can pick up the part

    public Transform player;
    public bool collected = false;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (collected || player == null) return;

        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= pickupRange && Input.GetKeyDown(KeyCode.E))
        {
            var inventory = player.GetComponent<PlayerInventory>();
            if (inventory != null)
            {
                inventory.AddPart(partID);
                collected = true;
                gameObject.SetActive(false); // Hide the part after collection
            }
        }
    }
}
