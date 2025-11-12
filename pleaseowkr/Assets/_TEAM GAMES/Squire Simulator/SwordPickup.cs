using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPickup : MonoBehaviour
{
    public float pickupRange = 2f;
    public Transform player;
    public bool canPickup = false;


    void Start()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(player.position, transform.position);
        canPickup = distance <= pickupRange;

        if (canPickup)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                PickupSword();
            }
        }
    }

    public void PickupSword()
    {
        Debug.Log("Sword Picked Up!");
        Destroy(gameObject);
    }
}
