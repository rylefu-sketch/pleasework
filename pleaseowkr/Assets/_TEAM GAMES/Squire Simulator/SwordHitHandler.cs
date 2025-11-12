using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordHitHandler : MonoBehaviour
{
    public WhetstoneLogic manager;
    public AudioSource hitSound;
    public ParticleSystem sparkEffect;
    public bool hasHit = false;

    public void Setup(WhetstoneLogic manager, AudioSource hitSound, ParticleSystem sparkEffect)
    {
        this.manager = manager;
        this.hitSound = hitSound;
        this.sparkEffect = sparkEffect;
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (hasHit) return;

        if (collision.gameObject.CompareTag("Whetstone"))
        {
            hasHit = true;

            // Play FX
            if (hitSound != null) hitSound.Play();
            if (sparkEffect != null)
            {
                sparkEffect.transform.position = collision.contacts[0].point;
                sparkEffect.Play();
            }

            // Switch sword mesh
            if (manager != null)
                manager.SwitchSwordMeshes(gameObject);

            // Add ricochet force off whetstone when sword is thrown
            Rigidbody rb = GetComponent<Rigidbody>();
            if (rb != null)
            {
                Vector3 ricochetDir = Vector3.Reflect(rb.velocity.normalized, collision.contacts[0].normal);
                rb.velocity = ricochetDir * rb.velocity.magnitude * 0.7f; // Reduce speed after ricochet to 70%
            }

            // Enable sword pickup after ricochet
            if (GetComponent<SwordPickup>() == null)
                gameObject.AddComponent<SwordPickup>();

            StartCoroutine(ResetPickupAfterSeconds(2f));
        }
    }

    public IEnumerator ResetPickupAfterSeconds(float delay)
    {
        yield return new WaitForSeconds(delay);
        if (manager != null)
            manager.EnablePickup();
    }
}
