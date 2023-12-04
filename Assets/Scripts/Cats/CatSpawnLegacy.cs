using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawnLegacy : MonoBehaviour
{
    public GameObject[] cats;

    [SerializeField]
    private float initialSpawnTime;
    [SerializeField]
    private int spawnLimit;

    private float spawnTime;

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = initialSpawnTime;
    }

    // Update is called once per frame
    void Update()
    {
        // Check if there are more cats to spawn
        if (spawnLimit > 0)
        {
            spawnTime -= Time.deltaTime;

            if (spawnTime <= 0)
            {
                // Instantiate a random cat from the array
                Instantiate(cats[Random.Range(0, cats.Length)], transform.position, Quaternion.identity);

                // Reset spawn time and decrement spawn limit
                spawnTime = initialSpawnTime;
                spawnLimit -= 1;
            }
            else
            { }
        }
    }
   
}