using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject[] enemyPrefab;

    public Transform[] spawnPoint;

    public float spawnRate = 0.5f;

    public float waitTime = 3f;

    public float timer;

    private bool activateSpawn = false;

    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnEnemy", 1f, spawnRate);
    }

    // Update is called once per frame
    void Update()
    {
        if(activateSpawn)
        {
          SpawnEnemy();
        }
      
    }
    void SpawnEnemy()
    {
        timer += Time.deltaTime;

        if(timer >= waitTime)
        {
            //Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

            /*Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnPoint[0].position, spawnPoint[0]. rotation);
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnPoint[1].position, spawnPoint[1]. rotation);
            Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], spawnPoint[2].position, spawnPoint[2]. rotation);*/
            timer = 0;

            foreach (Transform point in spawnPoint)
            {
                Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)], point.position, point.rotation);
            }

            for(int i = 0; i < spawnPoint.Length; i++)
            {
                Instantiate(enemyPrefab[Random.Range(0, enemyPrefab.Length)],spawnPoint[i].position, spawnPoint[i].rotation);
            }
        }
            //Instantiate (enemyPrefab, transform.position, transform.rotation);

    

    }

    
        void OnTriggerEnter2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                activateSpawn = true;
            }
        }

        void OnTriggerExit2D(Collider2D collider)
        {
            if (collider.gameObject.tag == "Player")
            {
                activateSpawn = false;
            }
        }
}