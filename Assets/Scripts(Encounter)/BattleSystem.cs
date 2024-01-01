using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState{ START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    

    public Unit playerUnit;
    public Unit enemyUnit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;


    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
