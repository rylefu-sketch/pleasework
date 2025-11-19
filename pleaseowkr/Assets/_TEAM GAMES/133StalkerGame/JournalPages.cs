using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JournalPages : MonoBehaviour
{
    public Button left;
    public Button right;
    public List<GameObject> pages;
    private int i;
    // Start is called before the first frame update
    void Start()
    {
        i = 0;
        foreach (var page in pages)
        {
            page.SetActive(false);
        }
        pages[0].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TurnRight()
    {
        if(i < pages.Count -1)
        {
            i++;
            pages[i - 1].SetActive(false);
            pages[i].SetActive(true);
        }

    }

    public void TurnLeft()
    {
        if(i > 0)
        {
            i--;
            pages[i + 1].SetActive(false);
            pages[i].SetActive(true);
        }

    }
}
