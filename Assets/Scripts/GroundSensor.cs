using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundSensor : MonoBehaviour
{
    public bool isGrounded;

    public Animator[] anim;

    PlayerMovement playerScript;

    public MiniEnemy miniEnemy;

    

    void Awake ()
    {
        //anim = GetComponentInParent<Animator>();
        playerScript = GetComponentInParent<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.gameObject.tag == "Subdits")
        {
            //Destroy(collider.gameObject);
            miniEnemy.SubditsDeath();
        }


        isGrounded = true;
        foreach(Animator animator in anim)
            {
                animator.SetBool("IsJumping", false);
            }
    }

    void OnTriggerStay2D(Collider2D collider)
    {
        isGrounded = true;
    } 

    void OnTriggerExit2D(Collider2D collider)
    {
        isGrounded = false;
    }
        
        
}
