using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    //https://www.youtube.com/watch?v=j111eKN8sJw&t=274s
    
    public float speedX = 2f;
    public float jumpForce = 10f;
    public float moveInput;

    private Rigidbody2D rb;
    private Animator anim;

    public bool isGrounded;
    //public bool doubleJump;
    public bool onTrigger;
    public Transform feetPos;
    public float checkRadius;
    public float fallingThreshold = -10f;
    public bool falling = false;
    public LayerMask whatIsGround;
    public float fallingGravity;
    public float normalGravity;
    public Animator transition;
    public GameObject nextBut1;
    public GameObject nextBut2;
    public Gun gunObj;
    public AudioSource audioSource;
    public AudioClip audioClipArray1;
    public AudioClip audioClipArray2;
    public AudioClip audioWIn;
    public GameObject triggerBox;
    public Animator gateOpen;
    public Animator eyeOpen;

    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        normalGravity = rb.gravityScale;
    }

    void Update()
    {
        anim.SetFloat("speed", Mathf.Abs(moveInput));
        isGrounded = Physics2D.OverlapCircle(feetPos.position, checkRadius, whatIsGround);

        if(isGrounded)
        {
            anim.SetBool("Up", false);
            anim.SetBool("Down", false);
        }
        
        if(isGrounded == true && Input.GetKeyDown(KeyCode.Space) && gunObj.pointerDown == false)
        {
            // anim.SetFloat("Speed", 0f);
            // anim.SetBool("isJumping", true);
            Jump();
            //doubleJump = true;
        }

        // if(isGrounded == false && doubleJump == true && Input.GetKeyDown(KeyCode.Space))
        // {
        //     // anim.SetFloat("Speed", 0f);
        //     // anim.SetBool("isJumping", true);
        //     rb.velocity = Vector2.up * jumpForce;    
        //     doubleJump = false;
        // }
        if(isGrounded && moveInput > 0 && rb.linearVelocity.y == 0|| isGrounded && moveInput < 0)
        {
            audioSource.clip = audioClipArray1;
            if(!audioSource.isPlaying)
            {
                audioSource.loop = true;
                audioSource.Play();
            }    
        } else 
        {
            audioSource.loop = false;
            //audioSource.Pause();
        }

        

        if(rb.linearVelocity.y > 0 && !isGrounded)
        {
            anim.SetBool("Up", true);
        } else 
        {
            anim.SetBool("Up", false);
        }

        if(rb.linearVelocity.y < 0 && !isGrounded)
        {
            anim.SetBool("Down", true);
        } else 
        {
            anim.SetBool("Down", false);
        }         

        if(moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0,0,0); 
        }   
        else if(moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }

        if(rb.linearVelocity.y < fallingThreshold && !isGrounded)
        {
            falling = true;
        } else 
        {
            falling = false;
        }

        if(falling)
        {
            rb.gravityScale = fallingGravity;
        } else {
            rb.gravityScale = normalGravity;
        }

        if(Mathf.Abs(moveInput) == 0)
        {
            anim.SetBool("Push", false);
        }
    }

    void FixedUpdate()
    {
        if(Input.GetAxisRaw("Vertical") < 1 && gunObj.pointerDown == false)
        {
        moveInput = Input.GetAxisRaw("Horizontal");
        rb.linearVelocity = new Vector2(moveInput * speedX, rb.linearVelocity.y);
        }
    }

    public void Jump()
    {
        //audioSource.playOnAwake = true;
        audioSource.loop = false;
        audioSource.clip = audioClipArray2;
            if(!audioSource.isPlaying)
            {
                audioSource.Play();
            }  
        rb.linearVelocity = Vector2.up * jumpForce;    
    }

    // private void OnCollisionEnter2D(Collision2D col) 
    // {
    //     if(col.gameObject.tag== "Push") //&& Mathf.Abs(moveInput) > 0)
    //     {
    //         Debug.Log("push");
    //         anim.SetBool("Push", true);
    //     }
    // }

    // private void OnCollisionExit2D(Collision2D col) 
    // {
    //     anim.SetBool("Push", false);
    // }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Win")){
            transition.SetTrigger("win");
            nextBut1.SetActive(true);
            nextBut2.SetActive(true);
            
            audioSource.clip = audioWIn;
            if(!audioSource.isPlaying)
            {
                audioSource.loop = false;
                audioSource.Play();
            }  
        }

        if(col.gameObject.tag== "Push" && Mathf.Abs(moveInput) > 0)
        {
            anim.SetBool("Push", true);
        }

        if(col.gameObject.tag== "Triggerbox")
        {
            Destroy(triggerBox);
            //randomObj.SetActive(true);
            gateOpen.SetTrigger("open");
            eyeOpen.SetTrigger("open");
        }
    }

    private void OnTriggerStay2D(Collider2D col)
    {
        if(col.gameObject.tag== "Push" && Mathf.Abs(moveInput) > 0)
        {
            anim.SetBool("Push", true);
        }

        if(col.gameObject.tag== "Push" && Mathf.Abs(moveInput) == 0)
        {
            anim.SetBool("Push", false);
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if(col.gameObject.tag== "Push")
        {
            anim.SetBool("Push", false);
        }
    }

    //mobile
    public void PressLeft()
    {
        moveInput = -1;
        rb.linearVelocity = new Vector2(-1 * speedX, rb.linearVelocity.y);
    }

    public void UnpressMove()
    {
        moveInput = 0;
        rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
    }

    public void PressRight()
    {
        moveInput = 1;
        rb.linearVelocity = new Vector2(1 * speedX, rb.linearVelocity.y);
    }
}
