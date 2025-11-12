using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Stores the player's collected items into an inventory list
    public List<string> collectedItems = new List<string>();

    public void AddItem(string itemID)
    {
        collectedItems.Add(itemID);
        Debug.Log($"Added to inventory: " + itemID);

        Debug.Log("Inventory contains:");
            foreach (string item in collectedItems)
            { Debug.Log("- " + item); }
    }
}
