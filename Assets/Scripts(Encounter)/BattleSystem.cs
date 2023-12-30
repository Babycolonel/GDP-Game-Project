using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum BattleState{ START, PLAYERTURN, ENEMYTURN, WON, LOST }
public class BattleSystem : MonoBehaviour
{
    public GameObject PlayerPrefeb;
    public GameObject EnemyPrefeb;

    public Transform PlayerBattleStation;
    public Transform EnemyBattleStation;


    public BattleState state;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        SetupBattle();
    }

    void SetupBattle()
    {
        GameObject playerGameObject = Instantiate(PlayerPrefeb, PlayerBattleStation);


        Instantiate(EnemyPrefeb, EnemyBattleStation);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
