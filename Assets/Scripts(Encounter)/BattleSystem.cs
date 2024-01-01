using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState{ START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    public int timePause;
    public GameObject ActionOverlay;
    public GameObject Dialog;
    public GameObject PhoneOverlay;
    public Text DiaText;
    public Text textTime;

    public Unit playerUnit;
    public Unit enemyUnit;

    public BattleHUD playerHUD;
    public BattleHUD enemyHUD;

    private bool Rec = false;
    private int RecTurn;
    private bool TimeRecurring;
    public int PolTurn;


    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
    }
    void Update()
    {
        
    }

    IEnumerator SetupBattle()
    {
        playerHUD.SetHUD(playerUnit);
        enemyHUD.SetHUD(enemyUnit);
        DiaText.text = "A wild " + enemyUnit.unitName + " has appeared";

        yield return new WaitForSeconds(timePause);

        DiaText.text = "It is your turn";

        yield return new WaitForSeconds(timePause);

        state = BattleState.PLAYERTURN;
        PlayerTurn();
    }

    void PlayerTurn()
    {
        Dialog.SetActive(false);
        ActionOverlay.SetActive(true);
    }

    public void Phone()
    {
        PhoneOverlay.SetActive(!PhoneOverlay.activeSelf);
    }

    public void PTRecord()
    {
        if (Rec == false)
        {
            Rec = true;
            RecTurn = 1;

            Dialog.SetActive(true);
            ActionOverlay.SetActive(false);
            PhoneOverlay.SetActive(false);


            state = BattleState.ENEMYTURN;
            StartCoroutine(enemyTurn());
        }
    }

    public void PTCall()
    {
        if (Rec == true && RecTurn > PolTurn)
        {
            state = BattleState.WON;
            // do stuff
        }
    }

    public void PTpersuade()
    {

    }
    
    public void PTArgue()
    {

    }

    public void PTRun()
    {
         
    }

    IEnumerator enemyTurn()
    {
        DiaText.text = "The enemy decides to scold you";

        yield return new WaitForSeconds(timePause);

        playerUnit.currentHP -= enemyUnit.damage;
        playerHUD.SetHP(playerUnit.currentHP);
        DiaText.text = "Your morale went down by " + enemyUnit.damage + "%";

        yield return new WaitForSeconds(timePause);

        DiaText.text = "It is your turn";

        yield return new WaitForSeconds(timePause);

        state = BattleState.PLAYERTURN;
        RecTurn += 1;
        PlayerTurn();
    }



}
