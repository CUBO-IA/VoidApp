using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public int sceneIndex;
    
    public void Replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(sceneIndex);
    }

    
    public void Salvi()
    {
        Application.OpenURL("https://www.instagram.com/sivarvideojuegos/");
    }
}
