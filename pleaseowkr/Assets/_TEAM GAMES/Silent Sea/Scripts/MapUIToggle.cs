using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapUIToggle : MonoBehaviour
{
    public GameObject mapUI;
    public AudioSource audioSource;
    public AudioClip mapOpenSound;
    public AudioClip mapCloseSound;

    public bool isMapOpen = false;


    void Start()
    {
        mapUI.SetActive(false);
        isMapOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            isMapOpen = !isMapOpen;
            mapUI.SetActive(isMapOpen);

            if (audioSource != null)
            {
                AudioClip clipToPlay = isMapOpen ? mapOpenSound : mapCloseSound;
                if (clipToPlay != null)
                {
                    audioSource.Stop();
                    audioSource.PlayOneShot(clipToPlay);
                }
            }
        }
    }
}
