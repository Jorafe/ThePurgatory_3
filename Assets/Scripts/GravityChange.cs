using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    public SpriteRenderer limbo; // Objeto con el aspecto normal del personaje
    public SpriteRenderer limbob; // Objeto con el aspecto alternativo del personaje

    public string playerTag = "Player";

    public GameObject player;

    public bool isGravityInverted = false;

    public Rigidbody2D playerRigidbody;

    public PlayerMovement playerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerRigidbody = player.GetComponent<Rigidbody2D>();
        playerScript = player.GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            
            isGravityInverted = !isGravityInverted;
            StartCoroutine(ChangeGravityWithDelay());
           /* if(isGravityInverted == true)
            {
                player.transform.rotation = Quaternion.Euler(180, 0, 0);
            }
            else
            {
                player.transform.rotation = Quaternion.Euler(0, 0, 0);
            }*/
        }
    }

    IEnumerator ChangeGravityWithDelay()
    {
        playerRigidbody.gravityScale *= -0.5f;

        yield return new WaitForSeconds(0.25f);

        if(isGravityInverted == true)
        {
            playerScript.xRotacion = 180;
            playerRigidbody.gravityScale = -2.5f;
            player.transform.rotation = Quaternion.Euler(180, player.transform.eulerAngles.y, 0);
            limbob.enabled = true;
            limbo.enabled = false;
        }
        else
        {
            playerScript.xRotacion = 0;
            playerRigidbody.gravityScale = 2.5f;
            player.transform.rotation = Quaternion.Euler(0,  player.transform.eulerAngles.y, 0);
            limbob.enabled = false;
            limbo.enabled = true;
        }

        
    }
   
    /*private void CambiarAspecto()
    {
        if (aspectoNormalActivo)
        {
            // Desactiva el aspecto normal y activa el aspecto alterno
            limbo.SetActive(false);
            limbo b.SetActive(true);
        }
        else
        {
            // Desactiva el aspecto alterno y activa el aspecto normal
            limbo b.SetActive(false);
            limbo.SetActive(true);
        }

        // Cambia el estado del aspecto actual
       // aspectoNormalActivo = !aspectoNormalActivo;
    }*/

}
