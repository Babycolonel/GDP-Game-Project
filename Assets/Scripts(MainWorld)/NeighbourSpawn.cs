using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NeighbourSpawn : MonoBehaviour
{
    public List<GameObject> neighbours;
    public DayCounter dayCounter;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 3f;

    private GameObject neighbour;
    private float timeTillNextSpawn = 0;
    private float currentTime;
    private float spawnCooldown;

    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (dayCounter.DayNumber >= 4 && neighbours != null && (currentTime >= timeTillNextSpawn || timeTillNextSpawn == 0))
        {
            neighbour = neighbours[Random.Range(0, neighbours.Count)];
            neighbour.SetActive(true);
            neighbours.Remove(neighbour);
            spawnCooldown = Random.Range(minSpawnTime, maxSpawnTime);
            timeTillNextSpawn = currentTime + spawnCooldown;
            Debug.Log(timeTillNextSpawn);
        }
    }
}
