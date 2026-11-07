using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AudioManager : MonoBehaviour
{
    static bool AudioBegin = false; 
    public AudioSource audioSource;
    public AudioClip audioClip;
    public AudioClip audioClip3;
    
    void Awake()
    {
        if (!AudioBegin)
        {
            audioSource.clip = audioClip;
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }    
        //audio.Play ();
        DontDestroyOnLoad (gameObject);
        AudioBegin = true;
        } 
    }

    void Update ()
    {
        Scene activeScene;
        activeScene = SceneManager.GetActiveScene();
        string sceneName = activeScene.name;
        
        if(sceneName == "Level3")
        {
         //audioSource.Stop();
         AudioBegin = false;
         PlayAudio();
        }
    }

    void PlayAudio()
    {
        audioSource.clip = audioClip3;
            if(!audioSource.isPlaying)
            {
                audioSource.loop = true;
                audioSource.Play();
            }  
    }
}
