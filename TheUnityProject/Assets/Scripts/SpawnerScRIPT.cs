using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerScRIPT : MonoBehaviour
{
    public static SpawnerScRIPT instance { get; private set; }

    //floats for controlling the spawn rate
    public float spawnRate;
    private float timeToSpawn;

    //bools
    public bool canSpawn = true;

    //gameObjects
    [SerializeField] GameObject[] shapesPrefap;


    GameObject shapeObject;// the instatiated shape object


    //coins
    [SerializeField] GameObject coinPrefap;
    float coinTimer;
    Vector2 coinVector;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        coinVector = new Vector2(Random.Range(-8, 8), 6);
    }

    private void Update()
    {

    }
    void FixedUpdate()
    {
        if (GameManager.instance.isDead == false)
        {
            if (timeToSpawn <= 0)
            {
                SpawnShape();
                timeToSpawn = spawnRate;
            }
            else { timeToSpawn -= Time.fixedDeltaTime; }

             SpawnCoins();
        }


        if (GameManager.instance.isDead == true) Destroy(shapeObject);



    }


    void SpawnCoins()
    {
        if (coinTimer <= 0)
        {
           Instantiate(coinPrefap, coinVector, Quaternion.identity);
           coinTimer = 6.5f;

           
        } else coinTimer -= Time.fixedDeltaTime;

    }

    void SpawnShape()
    {
        int n = Random.Range(0, 4);
        shapeObject = Instantiate(shapesPrefap[n], transform.position, Quaternion.identity);
        Destroy(shapeObject, 4);
    }
}
