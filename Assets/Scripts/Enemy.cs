using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour

{
    
    public Rigidbody2D rBody;

    public SpriteRenderer render; 

    public Animator anim;

    public float speed = 2f; // Velocidad de movimiento del enemigo
    public float moveDelay = 1f; // Tiempo de espera entre movimientos
    
    private Vector2 direction = Vector2.left; // Direccion inicial del movimiento


    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        /*source = GetComponent<AudioSource>();*/
    }

    private void Start()
    {
        // Iniciar el movimiento del enemigo
        InvokeRepeating("Move", moveDelay, moveDelay);
    }

    private void Move()
    {
        // Mover el enemigo en la direccion establecida
        transform.Translate(direction * speed * Time.deltaTime);
        
        anim.SetBool("IsWalking", true);
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 3)
    
        if(enemyDirection == 1)
        {
            enemyDirection = -1;
        }
        else if(enemyDirection == -1)
        {
            enemyDirection = 1;
        } 
    }*/
    
}