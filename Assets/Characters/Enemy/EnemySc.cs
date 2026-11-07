using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemySc : MonoBehaviour
{
    public bool voided;
    public bool unvoided;
    public float voidSpeed = 0.5f;
    public GameObject soulPrefab;
    public GameObject checkSouls;
    
    public float currentHealth;
    public float startHealth = 100f;
    Slider myHealth;

    //private Rigidbody2D rb;
    //public AudioSource audioSource;
    //public AudioClip[] audioClipArray;

    void Start()
    {
        currentHealth = startHealth;
        //rb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        if(currentHealth > 99)
        {
            //currentHealth = 100f;
            voided = false;
            unvoided = true;
        } else if (currentHealth < 1)
        {
            voided = true;
            unvoided = false;
        }

        // if(rb.velocity.x != 0)
        // {
        //     audioSource.clip = audioClipArray[0];
        //     if(!audioSource.isPlaying)
        //     {
        //         audioSource.Play();
        //     }    
        // } else {
        //     audioSource.Stop();
        // }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.CompareTag("Void")) //)
        {
            // if(voided)
            // {
            //    // Destroy(col.gameObject);
            // }
            
            if(currentHealth > 5)
            {
                currentHealth -= voidSpeed;
            } else if (currentHealth < 10)
            {
                SoulInst();
            }
        }
    }

    private void SoulInst()
    {
        checkSouls = GameObject.FindWithTag("Soul");
        if (checkSouls == null && unvoided)
        {
            Instantiate(soulPrefab, transform.position, transform.rotation);   
            currentHealth = 0;
        } 
    }
}
