using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHouseUnlock : MonoBehaviour
{
    [SerializeField] private GameObject catHouse;
    [SerializeField] private int unlockCondition = 5;
    public int itemCount;

    // Start is called before the first frame update
    void Start()
    {
        itemCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (itemCount == unlockCondition)
        {
            catHouse.SetActive(true);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("item") && itemCount < unlockCondition)
        {
            itemCount += 1;
            Destroy(collision.gameObject);
            Debug.LogWarning(itemCount);
        }
    }
}
