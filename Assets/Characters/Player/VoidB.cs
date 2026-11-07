using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidB : MonoBehaviour
{
    public GameObject player;
    private Transform playerPos;
    private Vector2 currentPos;
    public float distance = 30f;
    public float speedEnemy = 10f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Catch");
    }

    void Update()
    {
        playerPos = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;

        if(Vector3.Distance(transform.position, playerPos.position) < distance)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speedEnemy * Time.deltaTime);
            Destroy(gameObject, 0.4f);
        } 
    }

    // private void OnTriggerEnter2D(Collider2D col) {
    //     if(col.gameObject.CompareTag("Unvoided")) //)
    //     {
    //         float colHealth = col.GetComponent<LifeSc>().currentHealth;
    //         if(colHealth > 99)
    //         {
    //             colHealth -= voidSpeed;
    //         } else if (colHealth < 1)
    //         {
    //             col.GetComponent<Beacons>().SoulInst();
    //             col.gameObject.tag = "Voided";
    //         }
    //     }
    // }
}
