using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BbEnemy : MonoBehaviour
{
    public Rigidbody2D rb;
    public LifeSc life;
    SpriteRenderer sprite;
    public SpriteRenderer spriteSwitch;
    public Sprite switchOff;
    public Sprite switchOn;
    public Sprite spriteVoid;
    public Sprite spriteUnVoid;
    public Sprite spriteUnVoid2;
    public GameObject voidAudio;
    public GameObject unvoidAudio;
    public AudioSource audioSource;
    public AudioClip switchc;

    public Animator gateOpen;
    public Animator eyeOpen;
    Animator bbanim;

    public bool onGround;

    public GameObject boxMove;
    public GameObject colinactive;

    //HEAVY
    public float massHeavy;
    public float massLight;
    public float gHeavy;
    public float gLight;

    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.sprite = spriteVoid; 
        rb = GetComponent<Rigidbody2D>();
        bbanim = GetComponent<Animator>();
        spriteSwitch.sprite = switchOff;
    }

    void Update()
    {
        if(gameObject.tag == "Voided")
        { VoidedEffect();}
        
        if(gameObject.tag == "Unvoided")
        {
            UnvoidedEffect();
        }
    }

    //1 y 2
    public void VoidedEffect()
    {
        unvoidAudio.SetActive(false);
        voidAudio.SetActive(true);
        sprite.sprite = spriteVoid; 
    }

    public void UnvoidedEffect()
    {
        unvoidAudio.SetActive(true);
        voidAudio.SetActive(false);
        if(rb.bodyType != RigidbodyType2D.Static)
        {
            sprite.sprite = spriteUnVoid; 
        }
        // else 
        // {
        //     sprite.sprite = spriteUnVoid2; 
        // }  
        if(!onGround)
        {
            rb.mass = massHeavy;
            rb.gravityScale = gHeavy; 
        }
        
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.CompareTag("Switch") && gameObject.tag == "Unvoided") //)
        {
            spriteSwitch.sprite = switchOn;
            sprite.sprite = spriteUnVoid2;
            onGround = true;
            rb.mass = 0;
            rb.gravityScale = 0; 
            colinactive.SetActive(false);
            rb.bodyType = RigidbodyType2D.Static;
            rb.mass = 0;
            rb.gravityScale = 0; 
            audioSource.clip = switchc;
            if(!audioSource.isPlaying)
            {
                //audioSource.loop = true;
                audioSource.Play();
            }   
            boxMove.transform.position = new Vector3(boxMove.transform.position.x, boxMove.transform.position.x - 3f,boxMove.transform.position.z);
            gateOpen.SetTrigger("open");
            eyeOpen.SetTrigger("open");
        }

        if(col.gameObject.CompareTag("Push") && gameObject.tag == "Voided") //)
        {
            rb.mass = massHeavy;
            rb.gravityScale = gHeavy; 
        }

        if(col.gameObject.CompareTag("Finish") && gameObject.tag == "Voided") //)
        {
            rb.mass = massLight;
            rb.gravityScale = gLight; 
        }
    }

    private void OnTriggerExit2D(Collider2D col) {
        if(col.gameObject.CompareTag("Switch")) //)
        {
            onGround = false;
            gateOpen.SetTrigger("open");
            eyeOpen.SetTrigger("open");
        }
    }
}
