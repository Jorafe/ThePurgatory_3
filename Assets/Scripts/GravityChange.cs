using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{
    public GameObject limbo; // Objeto con el aspecto normal del personaje
    public GameObject limbob; // Objeto con el aspecto alternativo del personaje

    public string playerTag = "Player";

    private GameObject player;

    public bool isGravityInverted = false;

    public CameraMovement cameraScript;

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
        Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
        playerRigidbody.gravityScale *= -0.5f;

        yield return new WaitForSeconds(0.25f);

        if(isGravityInverted == true)
        {
            playerRigidbody.gravityScale = -2.5f;
            player.transform.rotation = Quaternion.Euler(180, 0, 0);
            limbo.SetActive(false);
            limbob.SetActive(true);

            cameraScript.activePlayer = cameraScript.playerTransforms[1];

        }
        else
        {
            playerRigidbody.gravityScale = 2.5f;
            player.transform.rotation = Quaternion.Euler(0, 0, 0);
            limbob.SetActive(false);
            limbo.SetActive(true);

            cameraScript.activePlayer = cameraScript.playerTransforms[0];
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
