using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Beacons : MonoBehaviour
{
    public SpriteRenderer spriteRender;
    public float timeRecharge = 5f;
    public GameObject thisObject;
    public Sprite spriteVoid;
    public Sprite spriteUnVoid;
    public GameObject voidAudio;
    public GameObject unvoidAudio;

    //public float voidSpeed = 0.5f;
    // public GameObject soulPrefab;
    // public GameObject checkSouls;
    public int currentHealth;
    // public float startHealth = 100f;
    // Slider myHealth;

    public LifeSc life;

    void Start()
    {
        spriteRender = thisObject.GetComponent<SpriteRenderer>();
        //currentHealth = startHealth;
    }

    void Update()
    {
        currentHealth = life.currentHealth;
        if(currentHealth == 100)
        {
            UnvoidedEffect();
        } else if (currentHealth == 0)
        {
            VoidedEffect();
        }
        // if(enemySc.voided == true)
        // { VoidedEffect();}
        // else {UnvoidedEffect();}
    }

    // private void OnTriggerEnter2D(Collider2D col) {
    //     if(col.gameObject.CompareTag("Void")) //)
    //     {   
    //         if(gameObject.tag == "Unvoided")
    //         {
    //             life.currentHealth -= voidSpeed;
    //         } else if (currentHealth < 10)
    //         {
    //             SoulInst();
    //         }
    //     }
    // }

    // public void SoulInst()
    // {
    //     checkSouls = GameObject.FindWithTag("Soul");
    //     if (checkSouls == null)
    //     {
    //         Instantiate(soulPrefab, transform.position, transform.rotation);   
    //         gameObject.tag = "Voided";
    //     } 
    // }

    public void VoidedEffect()
    {
        // spriteRender.color = new Color(70, 83, 97);
        spriteRender.sprite = spriteVoid; 
        unvoidAudio.SetActive(false);
        voidAudio.SetActive(true);
        StartCoroutine(Recuperar());
    }

    public void UnvoidedEffect()
    {
        spriteRender.sprite = spriteUnVoid;
        unvoidAudio.SetActive(true);
        voidAudio.SetActive(false); 
    }

    IEnumerator Recuperar()
    {
        yield return new WaitForSeconds(timeRecharge);
        life.currentHealth = 100;
        gameObject.tag = "Unvoided";
        StopCoroutine(Recuperar());
    }

    // void RecuperarVida()
    // { 
    //     recharge = false;
    //     enemySc.currentHealth = 100f;
    // }
}
