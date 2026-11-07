using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverBox : MonoBehaviour
{
    public SpriteRenderer spriteRender;
    public GameObject voidPos;
    public GameObject unvoidPos;
    public Sprite spriteVoid;
    public Sprite spriteUnVoid;
    public float moveSpeed;
    Rigidbody2D rb;
    public LifeSc life;
    public GameObject voidAudio;
    public GameObject unvoidAudio;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // if(rb.velocity.x > 0)
        // {
        //     isMoving = true;
        //     audioSource.clip = audioClip1;
        //     if(!audioSource.isPlaying)
        //     {
        //         audioSource.loop = true;
        //         audioSource.Play();
        //     } 
            
        // } else{
        //     isMoving = false;
        //     audioSource.Stop();
        // } 
        
        if(gameObject.tag == "Voided")
        {
            VoidedEffect();
            
        } else if(gameObject.tag == "Unvoided")
        {
            UnvoidedEffect();
        }
    }

    public void VoidedEffect()
    {
        //rb.mass = 10;
        rb.gravityScale = 0.5f;
        spriteRender.sprite = spriteVoid; 
        unvoidAudio.SetActive(false);
        voidAudio.SetActive(true);
    }

    public void UnvoidedEffect()
    {
        //rb.mass = 10;
        rb.gravityScale = -0.5f;
        spriteRender.sprite = spriteUnVoid;
        unvoidAudio.SetActive(true);
        voidAudio.SetActive(false);
    }
}
