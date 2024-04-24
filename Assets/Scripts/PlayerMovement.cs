using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rBody;

    public GroundSensor sensor; 

    public SpriteRenderer[] render; 

    public GameObject[] childObjects;

    public Animator[] anim;

    public AudioSource source;

    public AudioSource jumpSound;

    public AudioSource runSound;

    public AudioSource deathSound;

    public GravityChange gravityChange;

    public Transform bulletSpawn;

    public GameObject bulletPrefab;

    private bool canShoot = true;

    public float timer;

    public float rateOffire = 1;

    public Transform hitBox;

    public float hitBoxRadius = 2;

    public bool isDeath = false;

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
        //render = GetComponent<SpriteRenderer>();
        //anim = GetComponent<Animator>();
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

            foreach(Animator animator in anim)
            {
                animator.SetBool("IsJumping", true);
            }

            
           
            jumpSound.Play();
        }
        
         /*if (sensor.isGrounded)

        {
        // Configura la animación de salto a false cuando el jugador toca el suelo
         foreach (Animator animator in anim)
        {
            animator.SetBool("IsJumping", false);
        }
        }*/

        if (inputHorizontal < 0 )
        {
             foreach(Animator animator in anim)
            {
                animator.SetBool("IsRunning", true);
             }    
            
           
             for (int i = 0; i < render.Length; i++)
            {
             render[i].flipX = true; // Cambia la propiedad flipX de cada SpriteRenderer en el array render
            }
            /*runSound.Play();*/
            
        }
        else if(inputHorizontal > 0)
        {  
            foreach(Animator animator in anim)
            {
                animator.SetBool("IsRunning", true); 
            }    
                
            
           
            for (int i = 0; i < render.Length; i++)
            {
                render[i].flipX = false; // Cambia la propiedad flipX de cada SpriteRenderer en el array render
            }
          
            /*runSound.Play();*/
            
        }
        else
        {
              foreach(Animator animator in anim)
            {
                animator.SetBool("IsRunning", false);
            }
           
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

        childObjects = new GameObject[transform.childCount];

        render = new SpriteRenderer[transform.childCount];

        for (int i = 0; i < transform.childCount; i++)
        {
            childObjects[i] = transform.GetChild(i).gameObject;
            render[i] = childObjects[i].GetComponent<SpriteRenderer>();
          
        }

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

    public void Shoot()
    {
        if(!canShoot)
        {
              foreach(Animator animator in anim)
            {
                animator.SetBool("IsAttacking", true);
            }
            
            timer += Time.deltaTime;

            if(timer >= rateOffire)
            {
                canShoot = true;
                timer = 0;
            }
            
           
        }
        if(Input.GetKeyDown(KeyCode.F) && canShoot)
        {
            foreach(Animator animator in anim)
            {
                animator.SetBool("IsAttacking", false);
            }

            Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

            canShoot = false;
            
            
        }
        
    }
    
    public void Death()
    {
        deathSound.Play();

        SceneManager.LoadScene(3);

        //StartCoroutine("Die");

        //StopCoroutine("Die");
        //StopAllCoroutine();
    }

    public IEnumerator Die()
    {
        isDeath = true;

        deathSound.Stop();

        yield return new WaitForSeconds(3);

        //yield return Corrutine();

        SceneManager.LoadScene(0);
    }

    IEnumerator Corrutine()
    {
        yield return new WaitForSeconds(2);
    }
 }

