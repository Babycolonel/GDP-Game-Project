using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class Vet : MonoBehaviour
{
    public GameObject catInVet = null;
    public static UnityEvent onHealCat = new UnityEvent(); //healing button? idk i just copied foodstore
    public static UnityEvent onSpayCat = new UnityEvent();
    public static UnityEvent onPickUpCat = new UnityEvent();
    public TMP_Text vetStatusText;
    public float timeNeededToHeal = 5f;
    public float timeNeededToSpay = 5f;

    private bool isHealed = false;
    private bool isHealing = false;
    public float timeTillHeal = 0f;
    private Cat catScript;
    public string secondsShown;

    private bool isCatSpayed = false;
    private bool isSpaying = false;
    public float timeTillSpay = 0f;

    public SpriteRenderer spriteRenderer;
    public Sprite vetWithCat, vetWithoutCat;

    public Cat cat;
    public PlayerInfo pin;

    public void OnClickHeal()
    {
        HealOrPickUp();
    }

    public void OnClickSpay()
    {
        SpayOrPickUp();
    }

    void HealOrPickUp()
    {
        if (catInVet == null && cat.isCaptured)
        {
            onHealCat.Invoke();
        }
        if (catInVet != null && isHealed && !cat.isCaptured)
        {
            onPickUpCat.Invoke();
        }
    }

    void SpayOrPickUp()
    {
        if (catInVet == null && cat.isCaptured && !pin.capturedCat.GetComponent<Cat>().isSpayed)
        {
            onSpayCat.Invoke();
        }

        if (catInVet != null && isCatSpayed && !cat.isCaptured)
        {
            onPickUpCat.Invoke();
        }
    }

    void Start()
    {
        onHealCat.AddListener(HealCat);
        onSpayCat.AddListener(SpayCat);
        onPickUpCat.AddListener(PickUpCat);
        spriteRenderer = GetComponent<SpriteRenderer>();
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
            catInVet = pin.capturedCat;
            pin.capturedCat = null;
            cat.isCaptured = false;
        }
    }

    private void SpayCat()
    {
        if (!isCatSpayed)
        {
            isSpaying = true;
            timeTillSpay = timeNeededToSpay;
            catInVet = pin.capturedCat;
            pin.capturedCat = null;
            cat.isCaptured = false;
        }
    }

    private void PickUpCat()
    {
        if (isHealed && !cat.isCaptured)
        {
            catScript = catInVet.GetComponent<Cat>();
            catScript.IsFaint = false;
            catScript.CatCurrentHealth = catScript.CatMaxHealth;
            catScript.CatCurrentHunger = catScript.CatMaxHunger;
            pin.capturedCat = catInVet;
            catInVet = null;
            cat.isCaptured = true;
            isHealed = false;
        }
        if (isCatSpayed && !cat.isCaptured)
        {
            catScript = catInVet.GetComponent<Cat>();
            catScript.IsFaint = false;
            catScript.isSpayed = true;
            pin.capturedCat = catInVet;
            catInVet = null;
            cat.isCaptured = true;
            isCatSpayed = false;
        }
    }

    void Update()
    {
        if (!cat.isCaptured && catInVet == null)
        {
            vetStatusText.text = "You are not carrying a cat";
        }
        if (cat.isCaptured && catInVet == null)
        {
            vetStatusText.text = "Click the left button to heal your cat, and right to spay it!";
        }
        if (isHealed && cat.isCaptured)
        {
            vetStatusText.text = "Cat healed, please drop off your cat before picking up another";
        }
        else if (isHealed)
        {
            vetStatusText.text = "Cat healed!";
        }
        if (isCatSpayed && cat.isCaptured)
        {
            vetStatusText.text = "Cat spayed, please drop off your cat before picking up another";
        }
        else if (isCatSpayed)
        {
            vetStatusText.text = "Cat spayed!";
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
            spriteRenderer.sprite = vetWithCat;
        }
        if (isSpaying)
        {
            timeTillSpay -= Time.deltaTime;
            secondsShown = timeTillSpay.ToString("F1");
            vetStatusText.text = $"Treating cat... Cat will be ready in {secondsShown}";
            if (timeTillSpay <= 0f)
            {
                isSpaying = false;
                isCatSpayed = true;
            }
            
        }
        if (catInVet != null)
        {
            spriteRenderer.sprite = vetWithCat;
        }
        else
        {
            spriteRenderer.sprite = vetWithoutCat;
        }
    }
}
