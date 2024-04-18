using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pendulo : MonoBehaviour
{

    Rigidbody2D rb;
    public float leftLimit = 1f;
    public float rightLimit = 1f;
    public float Speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.angularVelocity = 900;
    }

    // Update is called once per frame
    void Update()
    {
        swingMove();

        /*Debug.Log(rb.angularVelocity);*/
    }

    void swingMove()
    {
        if(transform.rotation.z < rightLimit && rb.angularVelocity > 0 && rb.angularVelocity < Speed)
        {
            rb.angularVelocity = Speed;
        }
        else if(transform.rotation.z > leftLimit && rb.angularVelocity < 0 && rb.angularVelocity > -Speed)
        {
            rb.angularVelocity = -Speed;
        }
    }

     void OnTriggerEnter2D(Collider2D collition)
    {
        if (GetComponent<Collider>().CompareTag("Player"))
        {
            Destroy(collition.gameObject);
        }
    }
}
