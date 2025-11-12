using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollected : MonoBehaviour
{
    public ChecklistLogic checklistItem01;
    public ChecklistLogic checklistItem02;
    public ChecklistLogic checklistItem03;
    public ChecklistLogic checklistItem04;

    public void OnTriggerEnter(Collider other)
    {
      if (other.CompareTag("Player"))
        {
            checklistItem01.MarkCollected();
            gameObject.SetActive(false);

            checklistItem02.MarkCollected();
            gameObject.SetActive(false);

            checklistItem03.MarkCollected();
            gameObject.SetActive(false);

            checklistItem04.MarkCollected();
            gameObject.SetActive(false);
        }


    }
}
