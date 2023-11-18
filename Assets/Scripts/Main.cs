using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private HappinessSystem HappinessSystem;
    // Start is called before the first frame update
    void Start()
    {
        HappinessSystem.HappinessBarStart();
    }

    // Update is called once per frame
    void Update()
    {
        HappinessSystem.HappinessBarUpdate();
    }
}

