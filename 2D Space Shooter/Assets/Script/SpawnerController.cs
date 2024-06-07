using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    public float spawnRate;
    public GameObject[] enemies;
    public int waves=1;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("SpawnEnemy",spawnRate,spawnRate);  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void SpawnEnemy()
    {
        for(int i=0; i<waves; i++)
        {
            Instantiate(enemies[(int)Random.Range(0, enemies.Length)], new Vector3(Random.Range(-10, 10), 7, 0), Quaternion.identity);
        }
        
    }
}
