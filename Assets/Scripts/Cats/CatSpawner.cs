using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
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
        spawnTime -= Time.deltaTime;

        if ((spawnTime <= 0) && (spawnLimit > 0))
        {
            Instantiate(cats[Random.Range(0, cats.Length)], transform.position, Quaternion.identity);
            spawnTime = initialSpawnTime;
            spawnLimit -= 1;
            //Destroy(this);
        }
    }
}
