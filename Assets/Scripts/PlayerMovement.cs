using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rBody;

    public GroundSensor sensor; 

    public SpriteRenderer render; 

    public Animator anim;

    AudioSource source;

    public AudioSource jumpSound;

    public AudioSource runSound;

    public AudioSource deathSound;

    public GravityChange gravityChange;

    //private bool isDead = false;


    private int puntuacion;
    public Text puntuacionText;

   /* public Vector3 newPosition = new Vector3(50, 5, 0); */

    public float movementSpeed = 10;
    public float jumpForce = 10;

    private float inputHorizontal;

    public bool jump = false;

    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        render = GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        /*source = GetComponent<AudioSource>();*/
    }
    
    // Update is called once per frame
    void Update()
    {

        inputHorizontal = Input.GetAxis("Horizontal"); //Los controladores se ponen en el Update


        if(Input.GetButtonDown("Jump") & sensor.isGrounded == true) 
        {
            if (gravityChange.isGravityInverted)
            {
                rBody.AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);
            }
            else
            {
                rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }

            anim.SetBool("IsJumping", true);
            jumpSound.Play();

        }

        if (inputHorizontal < 0 )
        {
            render.flipX = true;
            anim.SetBool("IsRunning", true);
            /*runSound.Play();*/
            
        }
        else if(inputHorizontal > 0)
        {
            render.flipX = false;
            anim.SetBool("IsRunning", true);
             /*runSound.Play();*/
            
        }
        else
        {
            anim.SetBool("IsRunning", false);
            /*runSound.Stop();*/
            
        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            if (runSound != null)
            {
                runSound.Play();
            }
        }
        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            runSound.Stop();
        }
    }

    void FixedUpdate()
    {
        rBody.velocity = new Vector2(inputHorizontal * movementSpeed, rBody.velocity.y); //Cuando trabajamos con fisicas de forma continua, trabajamos en el FixedUpdate.
    }

    void Start()
    {
        puntuacion = 0;
        
        jumpSound = GetComponent<AudioSource>();

       /* runSound = GetComponent<AudioSource>();
        
        deathSound = GetComponent<AudioSource>();*/
    }
    
    private void OnTriggerEnter2D(Collider2D collision)
    {
         if(collision.gameObject.tag == "BlackCoin")
         {
           puntuacion ++;
           puntuacionText.text = puntuacion.ToString();  
         }

    }
  
 }

