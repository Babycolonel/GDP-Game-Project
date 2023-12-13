using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class FoodStore : MonoBehaviour
{
    public Food food;
    public static UnityEvent onFoodRestock = new UnityEvent(); //foodstore button
    public TMP_Text foodLeftText;

    public void OnClickRestock()
    {
        Restock();
    }

    void Restock()
    {
        onFoodRestock.Invoke();
    }

    void Start()
    {
        onFoodRestock.AddListener(RestockFood);
        if (foodLeftText != null)
        {
            foodLeftText.text = $"Food Left: 5/{food.maxFood}";
        }
    }

    private void RestockFood()
    {
        if (food.currentFood != food.maxFood)
        {
            food.currentFood = food.maxFood;
            food.foodText.text = food.currentFood + "/5"; //update the player button ui
            foodLeftText.text = $"Food Left: {food.currentFood}/{food.maxFood}"; //update the food store ui
        }
    }
}
