using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Vet : MonoBehaviour
{
    public GameObject catInVet = null;
    public PlayerInfo player;
    public static UnityEvent onHealCat = new UnityEvent(); //healing button? idk i just copied foodstore
    public static UnityEvent onPickUpCat = new UnityEvent();
    public TMP_Text vetStatusText;
    public float timeNeededToHeal = 5f;

    private bool isHealed = false;
    private bool isHealing = false;
    private float timeTillHeal = 0f;
    private Cat catScript;
    private string secondsShown;

    public void OnClickHeal()
    {
        HealOrPickUp();
    }

    void HealOrPickUp()
    {
        if (catInVet == null && player.hasCat)
        {
            onHealCat.Invoke();
        }
        if (catInVet != null && isHealed && !player.hasCat)
        {
            onPickUpCat.Invoke();
        }
    }

    void Start()
    {
        onHealCat.AddListener(HealCat);
        onPickUpCat.AddListener(PickUpCat);
        if (vetStatusText != null)
        {
            vetStatusText.text = "You are not carrying a cat";
        }
    }

    private void HealCat()
    {
        if (!isHealed)
        {
            isHealing = true;
            timeTillHeal = timeNeededToHeal;
            catInVet = player.capturedCat;
            player.capturedCat = null;
            player.hasCat = false;
        }
    }

    private void PickUpCat()
    {
        if (isHealed && !player.hasCat)
        {
            catScript = catInVet.GetComponent<Cat>();
            catScript.IsFaint = false;
            catScript.CatCurrentHealth = catScript.CatMaxHealth;
            catScript.CatCurrentHunger = catScript.CatMaxHunger;
            player.capturedCat = catInVet;
            catInVet = null;
            player.hasCat = true;
            isHealed = false;
        }
    }

    void Update()
    {
        if (!player.hasCat && catInVet == null)
        {
            vetStatusText.text = "You are not carrying a cat";
        }
        if (player.hasCat && catInVet == null)
        {
            vetStatusText.text = "Click to heal your cat!";
        }
        if (isHealed && player.hasCat)
        {
            vetStatusText.text = "Cat healed, please drop off yout cat before picking up another";
        }
        else if (isHealed)
        {
            vetStatusText.text = "Cat healed!";
        }
        if (isHealing)
        {
            timeTillHeal -= Time.deltaTime;
            secondsShown = timeTillHeal.ToString("F1");
            vetStatusText.text = $"Treating cat... Cat will be ready in {secondsShown}";
            if (timeTillHeal <= 0f)
            {
                isHealing = false;
                isHealed = true;
            }
        }
    }
}
