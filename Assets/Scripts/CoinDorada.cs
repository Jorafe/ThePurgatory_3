using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinDorada : MonoBehaviour
{

    public AudioSource source;

    public AudioClip coinSound;

    private BoxCollider2D boxCollider;

    void Awake()
    {
      source = GameObject.Find("sfxmanager").GetComponent<AudioSource>();
    }

 

    void OnTriggerEnter2D(Collider2D collider)
    {
       
        if(collider.gameObject.tag == "Player")
        {
          GameManager.Instance.ConseguirMoneda();
          source.PlayOneShot(coinSound);
          Destroy(gameObject);
        }
    
       
       
    

    }
}