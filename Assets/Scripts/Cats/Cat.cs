using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Cat : MonoBehaviour
{
    //[SerializeField] GameObject CatInteractButtons; //gameobject holding cat interactions buttons

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

    //For the feeding system, checks if the cat collider is touching the player
    public Transform playerCheck;
    public LayerMask playerLayer;
    public bool isPlayer;

    void Awake()
    {
        //tagging the child game object (straycat1_orange)

        Transform strayCatTransform1 = transform.Find("straycat1_orange"); // Find the straycat1_orange GameObject using its name
        Transform strayCatTransform2 = transform.Find("straycat2_white");


        if (strayCatTransform1 != null) // Check if the GameObject is found
        {
            // Change the tag of the straycat1_orange GameObject
            strayCatTransform1.gameObject.tag = "cat";
        }
        else
        {
            Debug.Log("straycat1_orange not found!");
        }

        if (strayCatTransform2 != null) // Check if the GameObject is found
        {
            // Change the tag of the straycat1_orange GameObject
            strayCatTransform2.gameObject.tag = "cat";
        }
        else
        {
            Debug.Log("straycat2_white not found!");
        }
    }

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

        CatManager.onFeedingCat.AddListener(FeedCat);
    }

    public void FeedCat()
    {
        if (isPlayer)
        {
            IncreaseHunger(10);
        }
        
    }

    public void IncreaseHunger(float value)
    {
        CatCurrentHunger += value;

        if (CatCurrentHunger > 100)
        {
            CatCurrentHunger = 100;
        }

        HGB.SetBar(CatCurrentHunger);
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
    void FixedUpdate()
    {
        isPlayer = Physics2D.OverlapCapsule(playerCheck.position, new Vector2(2.5f, 2.5f), CapsuleDirection2D.Vertical, 0, playerLayer);
    }

    /*private void OnTriggerEnter2D(Collider2D collision)
    {
        CatInteractButtons.SetActive(true); //makes the interact buttons visible

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        CatInteractButtons.SetActive(false); //makes the interaction buttons disabled
    }*/
}


