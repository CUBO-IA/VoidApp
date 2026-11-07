using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effects : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxSc boxSc;
    SpriteRenderer sprite;
    Color initialColor;
    public Sprite spriteVoid;
    public Sprite spriteUnVoid;

    public Animator gateOpen;
    public Animator eyeOpen;

    //HEAVY
    public float massHeavy;
    public float massLight;
    public float gHeavy;
    public float gLight;

    public GameObject triggerBox;
    public GameObject tutoBox;
    public GameObject randomObj;

    void Start()
    {
        sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.sprite = spriteVoid; 
        rb = GetComponent<Rigidbody2D>();
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
        sprite.sprite = spriteVoid; 
        rb.mass = massHeavy;
        rb.gravityScale = gHeavy;
    }

    public void UnvoidedEffect()
    {
        sprite.sprite = spriteUnVoid; 
        rb.mass = massLight;
        rb.gravityScale = gLight;   
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.CompareTag("Triggerbox")) //)
        {
            transform.position = tutoBox.transform.position;
            rb.bodyType = RigidbodyType2D.Static;
            Destroy(triggerBox);
            randomObj.SetActive(true);
            gateOpen.SetTrigger("open");
            eyeOpen.SetTrigger("open");
        }
    }
}
