using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public Transform voidPoint;
    public GameObject voidPrefab;
    public Transform voidPointUp;
    public Transform voidPointH;

    public Transform firePoint;
    public Transform firePointH;
    public Transform firePointUp;
    public GameObject bulletPrefab;
    public GameObject bulletPrefabH;
    public GameObject bulletPrefabUp;

    public bool pointerDown;
    public bool pressUp = false;
    //public bool pressBoth = false;
    public bool pressSoul = false;

    public bool hasSoul = false;

    public PlayerControl player;
    public Animator playerAnim;
    public Animator aimAnim;
    public Animator aimAnimY;
    public GameObject gunObj;
    public GameObject soulContained;
    public AudioSource audioSource;
    public AudioClip audioClip;

    void Update()
    {
        //PressX
        if(Input.GetKeyDown(KeyCode.X) && !pointerDown && !pressUp && gunObj.transform.childCount > 0) //&& !pressBoth
        {   
            GameObject[] uncontainedSouls = GameObject.FindGameObjectsWithTag("Soul");
            foreach (GameObject uncontainedSoul in uncontainedSouls)
            {
                Destroy(uncontainedSoul);
            }
            soulContained = gameObject.transform.GetChild(0).gameObject;
            Destroy(soulContained);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        } //PressX up
        else if (Input.GetKeyDown(KeyCode.X) && !pointerDown && pressUp && gunObj.transform.childCount > 0)// && !pressBoth
        {
            GameObject[] uncontainedSouls = GameObject.FindGameObjectsWithTag("Soul");
            foreach (GameObject uncontainedSoul in uncontainedSouls)
            {
                Destroy(uncontainedSoul);
            }
            soulContained = gameObject.transform.GetChild(0).gameObject;
            Destroy(soulContained);
            Instantiate(bulletPrefabUp, firePointUp.position, firePointUp.rotation);
        } 
        // else if (Input.GetKeyDown(KeyCode.X) && !pointerDown && pressBoth && gunObj.transform.childCount > 0)
        // {
        //     GameObject[] uncontainedSouls = GameObject.FindGameObjectsWithTag("Soul");
        //     foreach (GameObject uncontainedSoul in uncontainedSouls)
        //     {
        //         GameObject.Destroy(uncontainedSoul);
        //     }
        //     soulContained = gameObject.transform.GetChild(0).gameObject;
        //     Destroy(soulContained);
        //     Instantiate(bulletPrefabH, firePointH.position, firePointH.rotation);
        // }

        if(Input.GetKeyDown(KeyCode.Z) && player.isGrounded && player.moveInput == 0)
        {
            audioSource.clip = audioClip;
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }   
            pointerDown = true;
            playerAnim.SetBool("Zpressed", true);  
        }
        else if (Input.GetKeyUp(KeyCode.Z))
        {
            audioSource.Stop();
            pointerDown = false;
            playerAnim.SetBool("Zpressed", false);
            aimAnim.SetBool("suck", false);
        }

        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            pressUp = true;
            //playerAnim.SetBool("Zpressed", false);
            playerAnim.SetBool("ZpressedUp", true);
            // if(Input.GetAxisRaw("Horizontal") != 0)
            // {
            //     pressBoth = true;
            // }
        } else if(Input.GetKeyUp(KeyCode.UpArrow))
        {
            aimAnimY.SetBool("suckY", false);
            pressUp = false;
            //pressBoth = false;
            playerAnim.SetBool("ZpressedUp", false);
        }

        if(pointerDown && !pressUp)// && !pressBoth)
        {
            // RaycastHit2D hit = Physics2D.Raycast(transform.position, rayDirection, rayDis, 7);
            // if (hit.collider != null)
            // {
            //     Debug.Log(hit.collider);
            //     if (hit.collider.tag =="Enemy")
            //     {
            //         Debug.Log(hit.collider + "was hit");
            aimAnim.SetBool("suck", true);
            Vector3 randomPos = new Vector3(Random.Range(-2f,2f), Random.Range(-2f,2f), 0f);
            Instantiate(voidPrefab, voidPoint.position + randomPos, voidPoint.rotation);
            //         pointerDownTimer += Time.deltaTime;
			//         if (pointerDownTimer >= requiredHoldTime)
			//         {
			// 	        Debug.Log("Void is coming");
            //             Reset();     
            //         }
            //     }
            // }
        } else if (pointerDown && pressUp)// && !pressBoth)
        {
        aimAnim.SetBool("suck", false);
        aimAnimY.SetBool("suckY", true);
        Vector3 randomPos = new Vector3(Random.Range(-2f,2f), Random.Range(-2f,2f), 0f);
        Instantiate(voidPrefab, voidPointUp.position + randomPos, voidPointUp.rotation);
        }
        // else if (pointerDown && pressBoth)
        // {
        // Vector3 randomPos = new Vector3(Random.Range(-2f,2f), Random.Range(-2f,2f), 0f);
        // Instantiate(voidPrefab, voidPointH.position, voidPointH.rotation);
        // }
    }

    public void PressZ()
    {
        pointerDown = true;
        playerAnim.SetBool("Zpressed", true);
    }

    public void UnpressZ()
    {
        pointerDown = false;
        playerAnim.SetBool("Zpressed", false);
        aimAnim.SetBool("suck", false);
    }

    public void PressX()
    {
        GameObject[] uncontainedSouls = GameObject.FindGameObjectsWithTag("Soul");
            foreach (GameObject uncontainedSoul in uncontainedSouls)
            {
                Destroy(uncontainedSoul);
            }
            soulContained = gameObject.transform.GetChild(0).gameObject;
            Destroy(soulContained);
            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }

    public void PressUp()
    {
        pressUp = true;
        playerAnim.SetBool("ZpressedUp", true);
    }

    public void UnpressUp()
    {
        aimAnimY.SetBool("suckY", false);
        pressUp = false;
        playerAnim.SetBool("ZpressedUp", false);
    }
}
