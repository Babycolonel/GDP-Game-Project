using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthSystem : MonoBehaviour
{
    [SerializeField] GameObject gameOver;
    [SerializeField] private AudioSource dieSFX;

    private bool canPlaySFX = true;

    public HealthBar healthBar;
    public Animator animator;
    private Rigidbody2D rb; //to access the rigidbody component in the gameobject

    [SerializeField] private AudioSource healSFX;
    [SerializeField] private AudioSource hurtSFX;

    private int maxHealth = 100;
    private int minHealth = 0;
    private int currentHealth;

    //coroutine checkers
    private bool isHealing = false; //to check if healing coroutine is running
    private bool isDraining = false; //to check if draining coroutine is running

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        currentHealth = maxHealth; //players health gets set to 100 - starts off with max health
        healthBar.SetMaxHealth(maxHealth); //setting slider values here
        healthBar.SetMinHealth(minHealth); 
        healthBar.SetHealth(currentHealth); 
    }

    private void Update()
    {
        if (minHealth < currentHealth && !isDraining) //starts the draining coroutine if player's current health is above 0
                                                      //and makes sure it starts after the coroutine ends to avoid overlapping itself
        {
            StartCoroutine("DamageOvertime");
        }

        if (currentHealth <= minHealth) //calls die function when player's current health is below or = 0
        {
            Die();
        }
    }

    //collisions
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("hole")) //collider 2d checks if gameobject tagged hole collides with player for player to get instant killed
                                                     //by immediately setting current health to min when it collides with gameobject tagged "hole"
        {
            currentHealth = minHealth;
            healthBar.SetHealth(currentHealth); //also updates healthbar
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("healStation")) //triggers when player enters "healstation" game object,
                                                            //this stops draining coroutine from overlapping with healing coroutine
        {
            healSFX.Play();
            StopCoroutine("DamageOvertime");
        }

        if (collision.gameObject.CompareTag("traps")) //collider 2d detects player colliding with "enemy" = calls take damage function - updates health bar
        {
            hurtSFX.Play();

            TakeDamage(5);
            animator.SetTrigger("hurt");
            healthBar.SetHealth(currentHealth);
        }
    }

    private void OnTriggerStay2D(Collider2D collision) //collider 2d checks if player is still colliding with the game object tagged healstation makes sure the
                                                       //healing coroutine gets called for as long as the collider stays in the "healstation" 
                                                       //instead of just once if it were in ontriggerenter2d
    {
        if (collision.gameObject.CompareTag("healStation"))
        {
            if (currentHealth < maxHealth && !isHealing) //starts healing coroutine if players current health is below max
                                                         //makes sure healing coroutine is not already running to avoid ovelapping itself
            {
                StartCoroutine("Healing");
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("healStation"))
        {
            isHealing = false; //allows the coroutine to start again if the player leaves the healStation in the middle of the coroutine
                               //(in which isHealing would still be true, so healing coroutine cannot start again since the condition needed to start is false)

            StopCoroutine("Healing"); //stops healing coroutine when collider detects player exiting the "healstation"
            StartCoroutine("DamageOvertime"); //starts draining coroutine again   
        }
    }


    //coroutines
    IEnumerator Healing() //coroutine that allows the health to heal slowly instead of all at once
    {
        isHealing = true; //this makes it so that another instance of this coroutine wont start in the middle of the current instance
                          //as the coroutine has to wait for ishealing to be false again

        while (currentHealth < maxHealth)
        {
            GainHealth(1);
            yield return new WaitForSeconds(0.1f); //pauses the loop until and continues the next frame for as long as the players health
                                                   //is below max/leaves the "healstation" - 0.1 second delay to amke it heal faster
        }
        isHealing = false;
    }

    IEnumerator DamageOvertime() //coroutine that allows the health to drain slowly instead of all at once
    {
        Debug.Log("dot coroutine start");
        isDraining = true; //this makes it so that another instance of this coroutine wont start in the middle of the current instance
                           //as the coroutine has to wait for isdraining to be false again

        while (minHealth < currentHealth)
        {
            TakeDamage(1);
            yield return new WaitForSeconds(0.5f); //pauses the loop until and continues the next frame for each long as the players health is above min
        }
        Debug.Log("dot coroutine end");
        isDraining = false;
    }

    //functions
    private void TakeDamage(int damage) //takes in damage parameter to reduce player health
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    private void GainHealth(int heal) //takes in heal parameter to increase player health
    {
        currentHealth += heal;
        healthBar.SetHealth(currentHealth);
    }

    private void Die()
    {
        if (canPlaySFX == true)
        {
            dieSFX.Play();
            canPlaySFX = false;
        }

        rb.bodyType = RigidbodyType2D.Static; //sets the body type of player to static when they die so they cannot move
        animator.SetTrigger("dies"); //plays dying animation
    }

    public void ShowGameOver()
    {
        gameOver.SetActive(true); //makes the game over screen visible
    }
}
