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
    public int CatMinRand;
    public bool hasFeed = false;
    public float feedingTime;
    public float feedingLeft;
    public int FeedMultiplier;

    public float CatMaxHealth = 10;
    public float CatMinHealth = 0;
    public float CatCurrentHealth;

    private bool IsFaint = false;

    public bool Isdead = false;
    public bool IsDying = false;
    public bool Executed = false;
    public static UnityEvent onAnyCatDeath = new UnityEvent();
    public static UnityEvent onAnyCatDying = new UnityEvent();

    public BarSetting HPB, HGB;
    public CatManager CM;

    //For the feeding system, checks if the cat collider is touching the player
    public Transform playerCheck;
    public LayerMask playerLayer;
    public bool isPlayer;

    //animator
    public Animator animator;

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

        if (strayCatTransform2 != null) // Check if the GameObject is found
        {
            // Change the tag of the straycat1_orange GameObject
            strayCatTransform2.gameObject.tag = "cat";
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //This is the health
        CatCurrentHealth = CatMaxHealth;
        HPB.SetMaxBar(CatMaxHealth);
        HPB.SetBar(CatCurrentHealth);
        HPB.SetMinBar(CatMinHealth);

        //This is the randomiser 
        CatCurrentHunger = Random.Range(CatMinRand, CatMaxHunger + 1);
        HGB.SetMaxBar(CatMaxHunger);
        HGB.SetBar(CatCurrentHunger);
        HGB.SetMinBar(CatMinHunger);

        //This is the event listener from cat manager
        //So when the button is clicked, it will be send to here and execute "FeedCat" function
        CatManager.onFeedingCat.AddListener(FeedCat);

        //for healing
        CatManager.onHealCat.AddListener(HealCat);

    }

    //Feed cat is the executed function
    public void FeedCat()
    {
        if ((isPlayer) && (Isdead == false))
        {
            hasFeed = true;
        }
        
    }

    //function to heal the cat
    public void HealCat()
    {
        if ((isPlayer) && (Isdead == false))
        {
            CatCurrentHealth = CatMaxHealth;
        }
    }


    //Increase hunger is just a UI thing
    public void IncreaseHunger(float value)
    {
        if (Isdead == false)
        {
            CatCurrentHunger += value;

            if (CatCurrentHunger > CatMaxHunger)
            {
                CatCurrentHunger = CatMaxHunger;
            }

            HGB.SetBar(CatCurrentHunger);
        }
        
    }

    //This will send send the listener to the happiness system to deduct happiness
    void Die()
    {
        onAnyCatDeath.Invoke();
    }
    //This will send send the listener to the happiness system to slowly deduct happiness by time
    void Dying()
    {
        onAnyCatDying.Invoke();
    }
    void faint()
    {
        IsFaint = true;
        animator.SetBool("Faint", true);

        CatCurrentHealth -= Time.deltaTime;
        //While reducing health it will slowly
        //It will activate the listener in happiness script
        Dying();
        HPB.SetBar(CatCurrentHealth);
    }

    // Update is called once per frame
    // This handles all the conditions 
    void Update()
    {
        //This check if the cat is dead and if it is being fed
        if ((Isdead == false)&&(hasFeed == false))
        {
            //It will then slowly reduce hunger
            if (CatCurrentHunger > 0)
            {
                CatCurrentHunger -= Time.deltaTime;
                HGB.SetBar(CatCurrentHunger);
            }
            //If not it will slowly reduce health
            else if (CatCurrentHealth > 0)
            {
                faint();
            }
            else
            {
                //This is when the health is at 0
                //running the death condition
                CatCurrentHealth = 0;
                HPB.SetBar(CatCurrentHealth);
                Isdead = true;
                //Executed is to prevent it to keep running
                Executed = false;
            }
        }
        //This is when the cat is feeding
        else if (hasFeed == true)
        {
            IsFaint = false;
            animator.SetBool("Faint", false);
            animator.SetBool("Feeding", true);

            //Feeding time is how much time have lapsed
            feedingLeft += Time.deltaTime;
            //This checks if there is still time left
            if (feedingLeft <= feedingTime) 
            {
                //if yes then it will slowly increase
                IncreaseHunger(Time.deltaTime * FeedMultiplier);    
            }
            else
            {
                //or else it will just stop and reset the timer
                hasFeed = false;
                feedingLeft = 0;

                animator.SetBool("Feeding", false);
            }
            
        }
        //This is the death script
        else if (Executed == false)
        {
            //it runs the listener
            Die();
            //And prevents it to be executed again
            Executed = true;
        }
        else { }
    }
    void FixedUpdate()
    {
        isPlayer = Physics2D.OverlapCapsule(playerCheck.position, new Vector2(2.5f, 2.5f), CapsuleDirection2D.Vertical, 0, playerLayer);
    }

    
}


