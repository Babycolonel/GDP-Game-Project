using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClearCat : MonoBehaviour
{
    public PlayerInfo playerInfo;
    public Vet vet;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Awake()
    {
        playerInfo.capturedCat = null;
        vet.catInVet = null;
    }
}
