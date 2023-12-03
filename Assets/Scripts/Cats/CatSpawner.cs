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

    public float speed;
    public Vector3 moveDirection = new Vector3(1f, 1f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        spawnTime = initialSpawnTime;
        SetRandomMoveDirection();
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

                // Change the move direction after spawning a cat
                SetRandomMoveDirection();
            }
            else
            {
                // Move the spawner
                Vector3 movement = moveDirection.normalized * speed * Time.deltaTime;
                transform.Translate(movement);
            }
        }
    }

    // Set a random move direction
    private void SetRandomMoveDirection()
    {
        moveDirection = new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0f).normalized;
    }
}
