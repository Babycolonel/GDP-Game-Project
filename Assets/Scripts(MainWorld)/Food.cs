using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

//stores amount of food player has 

public class Food : MonoBehaviour
{
    public int maxFood = 5;
    public int currentFood;
    public bool hasFood = true;
    public TMP_Text foodText;

    // Start is called before the first frame update
    void Start()
    {
        currentFood = maxFood;
        foodText.text = currentFood + "/5";
    }

    // public void useFood()
    // {
    //     return currentFood - 1;
    // }
}
