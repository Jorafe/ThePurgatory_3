﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEnemigo2D : MonoBehaviour
{

    

    void OnTriggerEnter2D(Collider2D collition)
    {
        if (GetComponent<Collider>().CompareTag("Player"))
        {
            Destroy(collition.gameObject);
        }
    }




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Brillo();
        /*
        coll.GetComponentInParent<Megaman_X>().audio_S.clip = coll.GetComponentInParent<Megaman_X>().sonido[3];
        coll.GetComponentInParent<Megaman_X>().audio_S.Play();
        */
    }
}