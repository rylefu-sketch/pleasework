using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StareAtPlayer : MonoBehaviour
{
    public Transform player;
    public float rotationSpeed = 5f;
    private bool isStaring = false;

    public void StartStaring()
    {
        isStaring = true;
    }

    public void Update()
    {
        if (!isStaring) return;

        // Determine direction to look at the player
        Quaternion targetRot = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRot, rotationSpeed * Time.deltaTime);
    }
}
