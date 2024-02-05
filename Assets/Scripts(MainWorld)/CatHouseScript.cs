using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;

public class CatHouseScript : MonoBehaviour
{
    public GameObject CatinHouse;
    public static UnityEvent onCatInHouse = new UnityEvent();
    public static UnityEvent CatPickup = new UnityEvent();
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
        //onCatInHouse.AddListener();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void onClickPlace()
    {
        if (CatinHouse == null && player.GetComponent<PlayerInfo>().capturedCat != null)
        {
            onCatInHouse.Invoke();
        }
        if (CatinHouse != null  && player.GetComponent<PlayerInfo>().capturedCat == null)
        {
            CatPickup.Invoke();
        }
    }

}
