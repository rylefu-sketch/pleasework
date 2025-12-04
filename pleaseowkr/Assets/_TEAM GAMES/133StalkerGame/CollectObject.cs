using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Audio;

public class CollectObject : MonoBehaviour
{
    private int collectibleCount;

    private int winCount;
    public GameObject winScreen;
    public GameObject gameOverScreen;
    public float timeToFailure;

    public AudioSource collectSound;

    public List<GameObject> collectionItemsOrder;
    public static int activeIndex = 0;

    public GameObject lightsToTurnOff;
    public int flashlightDelaySeconds = 2;
    public GameObject phoneFlashlight;

    public AudioSource knockSound;
    public AudioSource heartbeatSound;

    public AudioMixer audioMixer;

    public float baseHeartbeatSpeed = 1;
    public float maxHeartbeatSpeed = 2;
    public float heartbeatSpeedUpInterval = 0.05f;
    private float currentHeartbeatSpeed;
    public float heartbeatVolume;

    private bool journalOpen = false;
    public GameObject journalMenu;

    private float timer;
    private bool canCountTimer;

    // Start is called before the first frame update
    void Start()
    {
        timer = 0;
        activeIndex = 0;
        canCountTimer = false;
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        foreach (GameObject item in collectionItemsOrder)
        {
           item.tag = "Untagged";
        }
        collectionItemsOrder[activeIndex].tag = "Collect";

        winCount = collectionItemsOrder.Count;
        winScreen.SetActive(false);
        gameOverScreen.SetActive(false);
        phoneFlashlight.SetActive(false);
        journalMenu.SetActive(false);

        currentHeartbeatSpeed = baseHeartbeatSpeed;
        audioMixer.SetFloat("_Pitch", currentHeartbeatSpeed);
        audioMixer.SetFloat("Volume", heartbeatVolume);
    }

    // Update is called once per frame
    void Update()
    {
        if (canCountTimer)
        {
            timer += Time.deltaTime;
            if (timer >= timeToFailure)
            {
                GameOver();
            }
        }
        Debug.Log(timer);

        if(journalOpen && Input.GetKeyDown(KeyCode.Escape))
        {
            journalMenu.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            journalOpen = false;
            Time.timeScale = 1;
            KnockEvent();
        }
    }

    public void GameOver()
    {
        gameOverScreen.SetActive(true);
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 0;
        audioMixer.SetFloat("Volume", -100);
    }

    public void PickUpCollectible(GameObject collect)
    {
       
        activeIndex++;
        if(activeIndex < collectionItemsOrder.Count)
        {
            foreach (GameObject item in collectionItemsOrder)
            {
                item.tag = "Untagged";
            }
            collectionItemsOrder[activeIndex].tag = "Collect";
           
        }

        if (collectSound != null)
        {
            collectSound.Play();
        }

        collect.gameObject.SetActive(false);

        if(activeIndex == 3)
        {
            LightsOffEvent();
        }
        if (activeIndex == 5)
        {
            LightsOnEvent();
        }
        if (activeIndex == 7)
        {
            JournalEvent();
        }
        if (activeIndex == 8)
        {
            HeartbeatEvent();
            canCountTimer = true;
        }

        if (activeIndex == winCount)
        {
            winScreen.SetActive(true);
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            Time.timeScale = 0;
            audioMixer.SetFloat("Volume", -100);
        }

    }

    public void LightsOffEvent()
    {
        lightsToTurnOff.SetActive(false);
        StartCoroutine(Flashlight());
    }

    IEnumerator Flashlight()
    {
        yield return new WaitForSeconds(flashlightDelaySeconds);
        phoneFlashlight.SetActive(true);
    }

    public void LightsOnEvent()
    {
        phoneFlashlight.SetActive(false);
        lightsToTurnOff.SetActive(true);
    }

    public void JournalEvent()
    {
        journalOpen = true;
        Time.timeScale = 0f;
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        journalMenu.SetActive(true);
    }

    public void KnockEvent()
    {
        knockSound.Play();
        
    }

    public void HeartbeatEvent()
    {
        StartCoroutine(HeartbeatPace());
    }

    IEnumerator HeartbeatPace()
    {        
        audioMixer.SetFloat("_Pitch", currentHeartbeatSpeed);
        if (knockSound.isPlaying || heartbeatSound.isPlaying)
        {
            yield return null;
        }
        else
        {
            heartbeatSound.Play();
            if (currentHeartbeatSpeed < maxHeartbeatSpeed)
            {
                currentHeartbeatSpeed = currentHeartbeatSpeed + heartbeatSpeedUpInterval;
            }
        }
        StartCoroutine(HeartbeatPace());
    }
}
