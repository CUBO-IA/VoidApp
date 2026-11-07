using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHalf : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    bool enemyCol;
    public int damage;
    SpriteRenderer spriteRender;
    public Animator anim;
    float enemy;
    public float directionY;
    public float directionX;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(directionX, directionY) * speed;
    }

    void Update()
    {
        if(gameObject.tag == "Unvoided")
        {
            
            rb.gravityScale = 0f;
            Destroy(gameObject, 15f);
        } else if(gameObject.tag == "Voided")
        {
            Destroy(gameObject, 10f);
            anim.GetComponent<Animator>().enabled = false;
            rb.gravityScale = 4f;
        }
    }
    

    void OnCollisionEnter2D(Collision2D col)
    {
        if(col.gameObject.tag == "Player" && gameObject.tag == "Unvoided")
        {
            Debug.Log("loose");
            Destroy(col.gameObject);
            //sadenemybool
        }

        if(col.gameObject.tag == "Ground" && gameObject.tag == "Unvoided")
        {
            Destroy(gameObject);
        }
    }
}
