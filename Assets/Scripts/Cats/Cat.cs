using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Cat : MonoBehaviour
{
    public float CatMaxHunger = 10;
    public float CatMinHunger = 0;
    public float CatCurrentHunger;

    public float CatMaxHealth = 10;
    public float CatMinHealth = 0;
    public float CatCurrentHealth;

    public bool Isdead = false;
    public bool Executed = false;
    public static UnityEvent onAnyCatDeath = new UnityEvent();

    public BarSetting HPB, HGB;
    
    


    // Start is called before the first frame update
    void Start()
    {
        CatCurrentHealth = CatMaxHealth;
        HPB.SetMaxBar(CatMaxHealth);
        HPB.SetBar(CatCurrentHealth);
        HPB.SetMinBar(CatMinHealth);

        CatCurrentHunger = Random.Range(CatMinHunger + 5, CatMaxHunger + 1);
        HGB.SetMaxBar(CatMaxHunger);
        HGB.SetBar(CatCurrentHunger);
        HGB.SetMinBar(CatMinHunger);

        Debug.Log(CatCurrentHunger);

        
    }

    void Die()
    {
        onAnyCatDeath.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        if (Isdead == false)
        {
            if (CatCurrentHunger > 0)
            {
                CatCurrentHunger -= Time.deltaTime;
                HGB.SetBar(CatCurrentHunger);
            }
            else if (CatCurrentHealth > 0)
            {
                CatCurrentHealth -= Time.deltaTime;
                HPB.SetBar(CatCurrentHealth);
            }
            else
            {
                CatCurrentHealth = 0;
                HPB.SetBar(CatCurrentHealth);
                Isdead = true;
                Executed = false;
            }
        }
        else if (Executed == false)
        {
            Die();
            Executed = true;
        }
        else { }
    }
}
