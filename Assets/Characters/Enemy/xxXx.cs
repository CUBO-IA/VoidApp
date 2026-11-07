using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class xxXx : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip audioClip;

    private void OnTriggerEnter2D(Collider2D col) {
        if(col.gameObject.CompareTag("Unvoided")) //)
        {
           audioSource.clip = audioClip;
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            } 
        }
    }
}
