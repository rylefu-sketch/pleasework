using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueTrigger : MonoBehaviour
{
    public Sprite thisDialogue;
    private DialogueManager manager;
    private bool hasShown = false;

    // Start is called before the first frame update
    void Start()
    {
       manager = FindFirstObjectByType<DialogueManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && !hasShown)
        {
            hasShown = true;
            manager.ShowDialogue(thisDialogue);
            manager.NextDialogue();
        }
    }

}
