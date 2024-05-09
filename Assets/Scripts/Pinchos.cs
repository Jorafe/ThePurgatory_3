using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pinchos : MonoBehaviour
{

    public PlayerMovement playerScript;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            playerScript.Death();
            Destroy(collision.gameObject);
            //SceneManager.LoadScene("GameOverMenu");
        }
    }
}
