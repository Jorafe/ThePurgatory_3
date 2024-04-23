using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{

    public string playerTag = "Player";

    private GameObject player;

    public bool isGravityInverted = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            
            isGravityInverted = !isGravityInverted;
            StartCoroutine(ChangeGravityWithDelay());
            if(isGravityInverted == true)
            {
                player.transform.rotation = Quaternion.Euler(180, 0, 0);
            }
            else
            {
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }
    }

    IEnumerator ChangeGravityWithDelay()
    {
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        playerRigidbody.gravityScale *= -0.5f;

        yield return new WaitForSeconds(0.25f);

        if(isGravityInverted == true)
        {
            playerRigidbody.gravityScale = -2.5f;
        }
        else
        {
            playerRigidbody.gravityScale = 2.5f;
        }

        
    }

}
