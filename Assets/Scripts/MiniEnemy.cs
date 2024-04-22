using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniEnemy : MonoBehaviour
{
    //private GameManager gameManager;
    
    public Rigidbody2D rBody;

    private AudioSource source;

    private CircleCollider2D circleCollider;

    public AudioClip deathSound;

    public float enemySpeed = 5;

    public float enemyDirection = 1;

    public SpriteRenderer render;

    //rBodyGet = component<Rigidbody2D>();
    //source = <GetComponent>();

    // Start is called before the first frame update
    void Awake()
    {
        rBody = GetComponent<Rigidbody2D>();
        source = GetComponent<AudioSource>();
        circleCollider = GetComponent<CircleCollider2D>();
        render = GetComponent<SpriteRenderer>();
        //gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rBody.velocity = new Vector2(enemyDirection * enemySpeed, rBody.velocity.y);
    }

    public void LoadGameOver()
    {
        SceneManager.LoadScene("Game Over");
    }


    void OnCollisionEnter2D(CircleCollider2D collision)
    {
        if(collision.gameObject.layer == 3 ||collision.gameObject.tag == "Subdits")
    
        if(enemyDirection == 1)
        {
            enemyDirection = -1;
            render.flipX = true;
        }
        else if(enemyDirection == -1)
        {
            enemyDirection = 1;
            render.flipX = false;
        } 
        if(collision.gameObject.tag == "Player")
    {
       Destroy(collision.gameObject);
       //SceneManager.LoadScene("Game Over");
    }
   
    }

    public void SubditsDeath()
    {
        source.PlayOneShot(deathSound);
        circleCollider.enabled = false;
        rBody.gravityScale = 0;
        enemyDirection = 0;
        Destroy(gameObject);
    }
    
    /*
    void OnBecameVisible()
    {
        gameManager.enemiesInScreen.Add(this.gameObject);
    }

    void OnBecameInvisible()
    {
        gameManager.enemiesInScreen.Remove(this.gameObject);
    }
    */


    }
