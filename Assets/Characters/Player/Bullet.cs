using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    //https://www.youtube.com/watch?v=wkKsl1Mfp5M
    public float speed = 20f;
    public Rigidbody2D rb;
    SpriteRenderer spriteRender;

    void Start()
    {
        rb.linearVelocity = transform.right * speed;  
        Destroy(gameObject, 10f); 
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Voided")
        {
            col.GetComponent<LifeSc>().currentHealth = 100;
            Destroy(gameObject);
            //sadenemybool
        }
    }
}
