using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class CatHouseScript : MonoBehaviour
{
    [SerializeField]
    private bool CatInHouseCheck = false;

    public GameObject CatInHouse;
    public static UnityEvent onCatInHouse = new UnityEvent();
    public static UnityEvent CatPickup = new UnityEvent();
    public static UnityEvent CatHouseHappyIncrease = new UnityEvent();
    public TMP_Text CatHouseText;

    public Cat cat;
    public PlayerInfo pin;
    public GameObject player;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        onCatInHouse.AddListener(CatResting);
        CatPickup.AddListener(PickUpCat);
    }

    // Update is called once per frame
    void Update()
    {
        /*player = GameObject.FindGameObjectWithTag("Player");
        if (player.GetComponent<PlayerInfo>().capturedCat == null && CatInHouse == null)
        {
            CatHouseText.text = "You are not carrying a cat";
        }
        if (player.GetComponent<PlayerInfo>().capturedCat != null && CatInHouse == null)
        {
            CatHouseText.text = "Tap the button to heal your cat!";
        }*/

        if (CatInHouseCheck == true)
        {
            CatHouseHappyIncrease.Invoke();
        }

    }

    public void onClickPlace()
    {
        if (CatInHouse == null && player.GetComponent<PlayerInfo>().capturedCat != null)
        {
            onCatInHouse.Invoke();
            CatInHouseCheck = true;

        }
        else if (CatInHouse != null  && player.GetComponent<PlayerInfo>().capturedCat == null)
        {
            CatPickup.Invoke();
            CatInHouseCheck = false;
        }

    }

    private void CatResting()
    {
        player.GetComponent<PlayerInfo>().capturedCat.GetComponent<Cat>().isCaptured = false;
        CatInHouse = player.GetComponent<PlayerInfo>().capturedCat;
        player.GetComponent<PlayerInfo>().capturedCat = null;
        Debug.Log(player.GetComponent<PlayerInfo>().capturedCat);
        CatHouseText.text = "Cat in house: 1/1";
    }

    private void PickUpCat()
    {
        if (player.GetComponent<PlayerInfo>().capturedCat == null)
        {
            cat = CatInHouse.GetComponent<Cat>();
            CatInHouse.GetComponent<Cat>().IsFaint = false;
            CatInHouse.GetComponent<Cat>().isCaptured = true;
            CatInHouse.GetComponent<Cat>().CatCurrentHunger = cat.CatMaxHunger;
            player.GetComponent<PlayerInfo>().capturedCat = CatInHouse;
            CatInHouse = null;
            CatHouseText.text = "Cat in house: 0/1";
        }
    }

}
