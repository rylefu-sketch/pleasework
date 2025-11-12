using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectiblePickup : MonoBehaviour
{
    public float interactionDistance = 3f;
    public LayerMask pickupLayer;
    public GameObject heldItem; // Item model shown on screen when picked up

    public Camera cam;

    void Start()
    {
        cam = Camera.main;
        heldItem.SetActive(false); // Should be hidden at start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            PickUpItem();
        }
    }

    public void PickUpItem()
    {
        Ray ray = new Ray(cam.transform.position, cam.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, interactionDistance, pickupLayer))
        {
            // Display picked up item
            Debug.Log("Picked up: " + hit.collider.gameObject.name);

            // Remove the item from the scene
            Destroy(hit.collider.gameObject);

            // Enable held item on display on screen
            heldItem.SetActive(true);
        }
    }
}
