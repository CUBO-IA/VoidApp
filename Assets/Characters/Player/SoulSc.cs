using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoulSc : MonoBehaviour
{
    public GameObject player;
    public GameObject gunObj;
    private Transform playerPos;
    private Vector2 currentPos;
    public float distance = 30f;
    public float speedEnemy = 20f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Catch");
        gunObj = GameObject.FindGameObjectWithTag("Gun");
    }

    void Update()
    {
        playerPos = player.GetComponent<Transform>();
        currentPos = GetComponent<Transform>().position;

        if(Vector3.Distance(transform.position, playerPos.position) < distance)
        {
            transform.position = Vector3.MoveTowards(transform.position, playerPos.position, speedEnemy * Time.deltaTime);
            //gunObj.GetComponent<Gun>().SoulWin();
            if(gunObj.transform.childCount == 0)
            {
                transform.gameObject.tag = "SoulContained";
                transform.parent = gunObj.transform;
            }
        } 
    }
}
