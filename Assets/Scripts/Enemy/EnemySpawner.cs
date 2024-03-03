using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPreFab;
    private float spawnTimer;
    public float spawnInterval = 5f;
    public int enemyCount = 3;

    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemy();       
        
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.childCount < enemyCount)
        {
            //if there is not enough Enemy from this spawn point
            spawnTimer += Time.deltaTime;
            if (spawnTimer >= spawnInterval)
            {
                SpawnEnemy();
                spawnTimer = 0;
            }
        }
        
        
    }

    void SpawnEnemy()
    {
        GameObject GO = GameObject.Instantiate(enemyPreFab, transform.position, Quaternion.identity);
        GO.transform.parent = transform;
    }
}
