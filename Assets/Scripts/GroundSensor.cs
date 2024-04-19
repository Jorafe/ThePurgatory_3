using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GroundSensor : MonoBehaviour
{
    public bool isGrounded;

    public Animator anim;

    PlayerMovement playerScript;

    void Awake ()
    {
        anim = GetComponentInParent<Animator>();
        playerScript = GetComponentInParent<PlayerMovement>();
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        /*if(collider.gameObject.tag == "Subdits")
        {
            //Destroy(collider.gameObject);
        MiniEnemy miniEnemy = collider.gameObject.GetComponent<Enemy>();
            miniEnemy.SubditsDeath();
        }*/


        isGrounded = true;
        anim.SetBool("IsJumping", false);
    }

    void OnTriggerExit2D(Collider2D collider)
    {
        isGrounded = false;
    }
        
        
}
