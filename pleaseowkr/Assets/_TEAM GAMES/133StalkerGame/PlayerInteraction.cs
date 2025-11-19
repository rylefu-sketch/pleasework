using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerInteraction : MonoBehaviour
{
    public float interactDistance;
    public TMP_Text interactText;
    public Transform camera_;
   
    void Start()
    {
        interactText.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        CheckForInteractable();
        Interact();
    }

    public void CheckForInteractable()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera_.transform.position, camera_.transform.forward, out hit, interactDistance)) //here we are sending out a raycast in front of the player, which is constantly checking if it is touching objects that we can interact with, so it can prompt the player to interact. in this case, we just have an interactable door, so if the player raycast hits an object tagged as Door, it will show us the prompt that this object is interactable.
        {
            Debug.Log(hit.collider.gameObject.name);
            Debug.Log(hit.collider.tag);
            //this raycast also uses a distance we set in the inspector, which we can mess around with so make sure we can't interact with things too far away from us, as well as to make sure we can interact with things that feel close enough to be able to. 
            if (hit.collider.CompareTag("Door") || hit.collider.CompareTag("Collect") || hit.collider.CompareTag("BasementDoor") && CollectObject.activeIndex == 4)
            {
                if (interactText != null)
                {
                    interactText.text = "E";
                }
            }
            else
            {
                interactText.text = "";
            }
        }
        else
        {
            interactText.text = "";
        }
    }
    public void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E)) //this method is checking for the interactable object once we press the button to interact. We again have to that the object in front of us is interactable, and if the object is tagged as Door, it gets the script that is attached to the door and tells it to execute the Interact method. In our door script, that means to close it if it is open, and open it if it is closed. 
        {
            RaycastHit hit;
            if (Physics.Raycast(camera_.transform.position, camera_.transform.forward, out hit, interactDistance))
            {
                Debug.Log(hit.collider.name);
                if (hit.collider.CompareTag("Door"))
                {
                    Debug.Log("hit door");
                    hit.collider.gameObject.GetComponent<OpenDoor>().Interact();
                }
                if (hit.collider.CompareTag("BasementDoor"))
                {
                    if (CollectObject.activeIndex == 4)
                    {
                        hit.collider.gameObject.GetComponent<OpenDoor>().Interact();
                    }
                }
                if (hit.collider.CompareTag("Collect"))
                {
                    Debug.Log("collected");
                    this.gameObject.GetComponent<CollectObject>().PickUpCollectible(hit.collider.gameObject);
                }
            }
        }

    }


}
