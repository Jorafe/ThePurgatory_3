using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravityChange : MonoBehaviour
{

    public string playerTag = "Player";

    private GameObject player;

    public PlayerMovement playerMovementScript;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag(playerTag);
        playerMovementScript = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(playerTag))
        {
            Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
            playerRigidbody.gravityScale *= -1;
            player.transform.rotation = Quaternion.Euler(180, 0, 0);
            playerMovementScript.SetGravityInverted(true);
        }
    }
}
