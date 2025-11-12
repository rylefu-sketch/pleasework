using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WhetstoneLogic : MonoBehaviour
{
    [Header("References")]
    public Canvas ePrompt;
    public GameObject swordPrefab;
    public Transform player;
    public Transform playerCamera;
    public AudioSource hitSound;
    public ParticleSystem sparkEffect;

    [Header("Properties")]
    public float throwForce = 8f;
    public float detectionRange = 3f;

    public bool hasThrown = false;


    // Start is called before the first frame update
    void Start()
    {
        if (ePrompt != null)
            ePrompt.gameObject.SetActive(false);

        if (playerCamera == null && Camera.main != null)
            playerCamera = Camera.main.transform;

        GameObject playerObj = GameObject.FindGameObjectWithTag("Player");
        if (playerObj != null)
            player = playerObj.transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null) return;

        float distance = Vector3.Distance(player.position, transform.position);
        bool playerInRange = distance <= detectionRange;

        // Keeps the E prompt facing the player
        if (ePrompt != null && playerCamera != null)
            ePrompt.transform.LookAt(playerCamera);

        if (playerInRange && Input.GetKeyDown(KeyCode.E) && !hasThrown)
        {
            ThrowSword();
        }
    }

    public void ThrowSword()
    {
        if (swordPrefab == null) return;

        hasThrown = true;

        // Instantiate sword at player's position
        Vector3 spawnPos = playerCamera.position + playerCamera.forward * 1f;
        Quaternion spawnRot = Quaternion.LookRotation(playerCamera.forward);
        GameObject sword = Instantiate(swordPrefab, spawnPos, spawnRot);

        // Enable the sword's physics and launch forward
        Rigidbody rb = sword.GetComponent<Rigidbody>();
        if (rb == null) 
            rb = sword.AddComponent<Rigidbody>();
            
        rb.isKinematic = false;
        rb.useGravity = true;
        rb.AddForce(playerCamera.forward * throwForce, ForceMode.VelocityChange);

        // Add collision handler to the sword
        SwordHitHandler hitHandler = sword.GetComponent<SwordHitHandler>();
        if (hitHandler == null)
            hitHandler = sword.AddComponent<SwordHitHandler>();
            hitHandler.Setup(this, hitSound, sparkEffect);

        // Hide E Prompt
        if (ePrompt != null)
            ePrompt.gameObject.SetActive(false);
    }

    // Called by the SwordHitHandler when the sword hits the whetstone
    public void SwitchSwordMeshes(GameObject sword)
    {
        Transform realSword = sword.transform.Find("RealSword");
        Transform toonSword = sword.transform.Find("ToonSword");

        if (realSword != null)
            realSword.gameObject.SetActive(false);

        if (toonSword != null) 
            toonSword.gameObject.SetActive(true);    
    }

    public void EnablePickup()
    { 
        hasThrown = false;
    }
}
