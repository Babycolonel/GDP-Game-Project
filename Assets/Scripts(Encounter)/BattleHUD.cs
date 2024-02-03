using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BattleHUD : MonoBehaviour
{
    public Text nameText;
    public BarScript barScript;

    public void SetHUD(Unit unit)
    {
        nameText.text = unit.unitName;
        barScript.SetMaxBar(unit.maxHP);
        SetHP(unit.currentHP);
    }

    public void SetHP(int hp)
    {
        barScript.SetBar(hp);
    }
}
