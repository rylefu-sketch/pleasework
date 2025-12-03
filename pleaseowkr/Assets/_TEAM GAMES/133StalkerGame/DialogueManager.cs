using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public List<GameObject> dialogueTriggerList;
    private int i;
    public Image dialogueObject;
    public float dialogueOnScreenDuration = 5;
    public float triggerActiveDelay = 0.5f;
    // Start is called before the first frame update
    void Start()
    {
        dialogueObject.enabled = false;
        i = 0;
        foreach(GameObject dialogue in dialogueTriggerList)
        {
            dialogue.SetActive(false);
        }
        dialogueTriggerList[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowDialogue(Sprite dialogueImg)
    {
        StopCoroutine(ShowDialogue());
        dialogueObject.sprite = dialogueImg;
        StartCoroutine(ShowDialogue());
        
    }

    public void NextDialogue()
    {
        dialogueTriggerList[i].SetActive(false);
        if (i < dialogueTriggerList.Count - 1)
        {
            i++;
            StartCoroutine(TriggerDelay());
        }
    }


    IEnumerator ShowDialogue()
    {
        dialogueObject.enabled = true;
        yield return new WaitForSecondsRealtime(dialogueOnScreenDuration);
        dialogueObject.enabled = false;
    }

    IEnumerator TriggerDelay()
    {
        yield return new WaitForSecondsRealtime(triggerActiveDelay);
        dialogueTriggerList[i].SetActive(true);
    }
}
