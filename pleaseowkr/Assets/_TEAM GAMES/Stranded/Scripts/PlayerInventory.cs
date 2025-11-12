using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public HashSet<string> collectedParts = new HashSet<string>();
    public bool HasPart(string partID)
    {
        return collectedParts.Contains(partID);
    }

    public void AddPart(string partID)
    {
        if (!collectedParts.Contains(partID))
        {
            collectedParts.Add(partID);
            Debug.Log($"Collected part {partID} added to inventory.");
        }
    }

    public void RemovePart(string partID)
    {
        if (collectedParts.Contains(partID))
        {
            collectedParts.Remove(partID);
            Debug.Log($"Used part {partID} removed from inventory.");
        }
    }
}
