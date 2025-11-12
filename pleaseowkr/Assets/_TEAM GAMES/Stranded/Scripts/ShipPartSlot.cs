using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipPartSlot : MonoBehaviour
{
    public string requiredPartID;   // The ID of the part required for this slot
    public GameObject partObject;   // The model of the part in the slot
    public float installRange = 5f; // Distance within which the player can install the part

    public Transform player;
    public bool isInstalled = false;

    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;

        if (partObject != null)
            partObject.SetActive(false); // Part is hidden until installed
    }

    void Update()
    {
        if (isInstalled || player == null) return;

        float distance = Vector3.Distance(player.position, transform.position);
        if (distance <= installRange && Input.GetKeyDown(KeyCode.E))
        {
            var inventory = player.GetComponent<PlayerInventory>();
            if (inventory != null && inventory.HasPart(requiredPartID))
            {
                InstallPart(inventory);
                isInstalled = true;
            }
            
            else
            {
                Debug.Log($"You need the part {requiredPartID} to install here.");
            }
        }
    }

    public void InstallPart(PlayerInventory inventory)
    {
        isInstalled = true;

        if (partObject != null)
        {
            partObject.SetActive(true); // Show the installed part
            Debug.Log($"Part {requiredPartID} successfully installed on the ship.");
        }

        else
        {
            Debug.LogWarning("No part object assigned to this slot.");
        }

        inventory.RemovePart(requiredPartID);
    }
}
