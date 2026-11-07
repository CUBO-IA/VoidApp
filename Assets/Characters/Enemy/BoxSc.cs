using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BoxSc : MonoBehaviour
{
    public float currentHealth;
    public SpriteRenderer spriteRender;
    private Rigidbody2D rb;
    public AudioSource audioSource;
    public AudioClip audioClip1;
    public bool isMoving;
    public GameObject voidAudio;
    public GameObject unvoidAudio;
    public Sprite spriteVoid;
    public Sprite spriteUnVoid;
    public LifeSc life;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        currentHealth = life.currentHealth;
        if(currentHealth == 100)
        {
            UnvoidedEffect();
        } else if (currentHealth == 0)
        {
            VoidedEffect();
        }

        if(rb.linearVelocity.x > 0)
        {
            isMoving = true;
            audioSource.clip = audioClip1;
            if(!audioSource.isPlaying)
            {
                audioSource.loop = true;
                audioSource.Play();
            } 
            
        } else{
            isMoving = false;
            audioSource.Stop();
        }   
    }

    public void VoidedEffect()
    {
        gameObject.tag = "Voided";
        spriteRender.sprite = spriteVoid; 
        unvoidAudio.SetActive(false);
        voidAudio.SetActive(true);
    }

    public void UnvoidedEffect()
    {
        gameObject.tag = "Unvoided";
        spriteRender.sprite = spriteUnVoid;
        unvoidAudio.SetActive(true);
        voidAudio.SetActive(false);
    }
    

    // private void OnTriggerEnter2D(Collider2D col) {
    //     if(col.gameObject.CompareTag("Triggerbox")) //)
    //     {
    //        audioSource.clip = audioClip;
    //         if(!audioSource.isPlaying)
    //         {
    //             audioSource.loop = false;
    //             audioSource.Play();
    //         } 
    //     }
    // }
}
