using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletUp : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    bool enemyCol;
    public int damage;
    SpriteRenderer spriteRender;
    float enemy;

    void Start()
    {
        rb.linearVelocity = transform.up * speed;  
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.tag == "Enemy")
        {
            Debug.Log(col.gameObject.name);
            col.GetComponent<BoxSc>().currentHealth = 100f;
            Destroy(gameObject);
            //sadenemybool
        }
    }
}
