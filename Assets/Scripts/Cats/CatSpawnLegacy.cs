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

    private GameObject spawnedCat, player;

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
                spawnedCat = Instantiate(cats[Random.Range(0, cats.Length)], transform.position, Quaternion.identity);
                player = GameObject.Find("Player");
                spawnedCat.gameObject.GetComponent<Cat>().food = player.gameObject.GetComponent<Food>();
                spawnedCat.gameObject.GetComponent<Capture>().playerTransform = player.gameObject.GetComponent<Transform>();
                spawnedCat.gameObject.GetComponent<Capture>().player = player.gameObject.GetComponent<PlayerInfo>();

                // Reset spawn time and decrement spawn limit
                spawnTime = initialSpawnTime;
                spawnLimit -= 1;
            }
            else
            { }
        }
    }
   
}
