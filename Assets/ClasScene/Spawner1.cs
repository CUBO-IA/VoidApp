using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Spawner1 : MonoBehaviour
{
    //[SerializeField]
    //private TextMeshProUGUI waveCounterText;
    private int waveCount;
    private int enemyCount;
    private float waveTextTimer = 1f;
    public float spawnRate = 1f;
    private float timesBetweenWaves = 5f;
    public GameObject[] spawnObj;
    public GameObject enemies;

    [SerializeField]
    private bool _isWaveActive = true;
    private bool _stopSpawning = false;

    void Start()
    {
        StartCoroutine(waveSpawner());
    }

    IEnumerator waveSpawner()
    {
        while(_isWaveActive == true && _stopSpawning == false)
        {
            int randomCannon = Random.Range(0, spawnObj.Length);
            int randomCannon2 = Random.Range(0, spawnObj.Length);
            Vector3 spawnPos = new Vector3(spawnObj[randomCannon].transform.position.x, spawnObj[randomCannon2].transform.position.y , 0);
            _isWaveActive = false;

            for (int i=0; i<enemyCount; i++)
            {
                ActivateWaveText();
                yield return new WaitForSeconds(waveTextTimer);
                //waveCounterText.gameObject.SetActive(false);

                GameObject enemyClone = Instantiate(enemies, spawnPos, Quaternion.identity);
                yield return new WaitForSeconds(spawnRate);

                if(waveCount >= 5)
                {
                    EndEnemyWaves();
                }
            }
            spawnRate -= 1f;
        enemyCount +=1;
        yield return new WaitForSeconds(timesBetweenWaves);
        waveCount +=1;
        _isWaveActive = true;
        }
    }

    private void ActivateWaveText()
    {
        //waveCounterText.text = "Wave: " + waveCount.ToString();
        //waveCounterText.gameObject.SetActive(true);
    }

    public void EndEnemyWaves()
    {
        _stopSpawning = true;
        GameObject[] enemoes = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemoe in enemoes)
        {
            GameObject.Destroy(enemies);
        }

        
    }
  
    
}
