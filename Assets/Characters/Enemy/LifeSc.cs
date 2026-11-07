using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSc : MonoBehaviour
{
    public int currentHealth;
    public int startHealth = 100;
    public int voidSpeed = 1;
    public GameObject soulPrefab;
    public GameObject checkSouls;

    void Start()
    {
        currentHealth = startHealth;
    }

    void Update()
    {
        if(currentHealth > 99)
        {
            gameObject.tag = "Unvoided";
        }
    }

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.CompareTag("Void") && currentHealth > 0)
        {   
            currentHealth -= voidSpeed;
            if(currentHealth < 1)
            {
                SoulInst();
            }
        }
    }

    public void SoulInst()
    {
        checkSouls = GameObject.FindWithTag("Soul");
        if (checkSouls == null)
        {
            Instantiate(soulPrefab, transform.position, transform.rotation);   
            gameObject.tag = "Voided";
        } else 
        {
            gameObject.tag = "Voided";
            Destroy(checkSouls);
        }
    }
}
