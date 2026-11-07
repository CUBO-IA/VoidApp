using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalVoid : MonoBehaviour
{
    public SpriteRenderer spriteRender;
    public GameObject thisObject;
    public Sprite spriteVoid;
    public Sprite spriteUnVoid;
    public GameObject voidAudio;
    public GameObject unvoidAudio;
    //public GameObject soulPrefab;
    //public GameObject checkSouls;
    public int currentHealth;
    // public int startHealth = 100;
    // public int voidSpeed = 1;
    public LifeSc life;

    void Start()
    {
        spriteRender = thisObject.GetComponent<SpriteRenderer>();
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
    }

    // private void OnTriggerEnter2D(Collider2D col)
    // {
    //     if(col.gameObject.CompareTag("Void"))// && currentHealth > 0)
    //     {   
    //         currentHealth -= voidSpeed;
    //         if(currentHealth < 1)
    //         {
    //             SoulInst();
    //             currentHealth = 0;
    //         }
    //     }
    // }

    public void VoidedEffect()
    {
        // spriteRender.color = new Color(70, 83, 97);
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
}
