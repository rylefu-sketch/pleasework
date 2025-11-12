using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickup : MonoBehaviour
{
    public float interactionDistance = 3f;
    public LayerMask pickupLayer;

    public Camera cam;
    public Inventory inventory;

    void Start()
    {
        cam = Camera.main;
        inventory = GetComponent<Inventory>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        { PickUpItem();  }
    }


    public void PickUpItem()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, pickupLayer))
        {
            ItemList item = hit.collider.GetComponent<ItemList>();
            
            if (item != null)
            {
                // Adds all items collected to the inventory
                foreach (string itemID in item.itemIDs)
                { inventory.AddItem(itemID); }

                // Remove the item from the scene when picked up
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
