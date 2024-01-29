using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatHouse : MonoBehaviour
{
    public Cat cat;
    public HappinessSystem HS;
    public bool catInHouse;

    // Start is called before the first frame update
    void Start()
    {
        catInHouse = false;
        HS.AddHappiness(5);
    }


    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("cat") && !catInHouse && !cat.IsFaint || !cat.Isdead)
        {
            Debug.LogWarning("On Trigger Enter = True");
            StartCoroutine(catHouseHappiness());
        }
    }

    private IEnumerator catHouseHappiness()
    {
        Debug.LogWarning("Couroutine start");
        catInHouse = true;
        HS.AddHappiness(5);

        catInHouse = false;
        Debug.LogWarning("Couroutine end");

        yield return new WaitForSeconds(1f);
    }*/
}
