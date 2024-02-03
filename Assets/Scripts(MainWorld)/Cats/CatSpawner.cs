using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatSpawner : MonoBehaviour
{

    public GameObject[] cats;

    [SerializeField] private float initialSpawnTime;
    [SerializeField] private int spawnLimit;
    [SerializeField] private float speed;

    private float spawnTime;
    private Vector3 moveDirection;

    private static readonly Vector3 DefaultMoveDirection = new Vector3(1f, 1f, 0f);

    void Start()
    {
        spawnTime = initialSpawnTime;
        SetRandomMoveDirection();
    }

    void Update()
    {
        if (spawnLimit > 0)
        {
            spawnTime -= Time.deltaTime;

            if (spawnTime <= 0)
            {
                SpawnCat();
                spawnTime = initialSpawnTime;
                spawnLimit--;
                SetRandomMoveDirection();
            }
            else
            {
                MoveSpawner();
            }
        }
    }

    private void SetRandomMoveDirection()
    {
        moveDirection = Random.onUnitSphere; // Random vector on the surface of a sphere
        moveDirection.z = 0f; // Keep it in the XY plane
    }

    private void SpawnCat()
    {
        Vector3 spawnPosition = transform.position; // You might want to adjust this for more control
        Instantiate(cats[Random.Range(0, cats.Length)], spawnPosition, Quaternion.identity);
    }

    private void MoveSpawner()
    {
        Vector3 movement = moveDirection.normalized * speed * Time.deltaTime;
        transform.Translate(movement);
    }
}

