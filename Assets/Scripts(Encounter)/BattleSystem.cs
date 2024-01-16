using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
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

    public Animator enemyAnimator;

    public BattleState state;

    public GameObject player;
    public Transform playerTransform;
    public PlayerInfo playerInfo;
    public Transform enemyTransform;

    // Start is called before the first frame update
    void Start()
    {
        state = BattleState.START;
        StartCoroutine(SetupBattle());
        player = GameObject.FindWithTag("Player");
        playerTransform = player.GetComponent<Transform>();
        playerInfo = player.GetComponent<PlayerInfo>();
        enemyTransform = playerInfo.enemyTransform;
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
        enemyUnit.currentHP += playerUnit.damage;
        enemyHUD.SetHP(enemyUnit.currentHP);
        StartCoroutine(Persuade());
    }

    IEnumerator Persuade()
    {
        ActionOverlay.SetActive(false);
        PhoneOverlay.SetActive(false);
        Dialog.SetActive(true);
        DiaText.text = "You have persuaded " + enemyUnit.unitName + " by " + playerUnit.damage + "%";

        yield return new WaitForSeconds(timePause);

        // if (enemyUnit.currentHP <= 0)
        // {
        //     DiaText.text = "You have persuaded " + enemyUnit.unitName + "!";
        //     yield return new WaitForSeconds(timePause);
        //     SceneManager.LoadSceneAsync(0);
        //     Destroy(enemyTransform.gameObject);
        // }

        StartCoroutine(enemyTurn());
    }

    public void PTArgue()
    {
        enemyUnit.currentHP += playerUnit.damage * 2;
        enemyHUD.SetHP(enemyUnit.currentHP);

        playerUnit.currentHP -= playerUnit.damage;
        playerHUD.SetHP(playerUnit.currentHP);
        StartCoroutine(Argue());
    }

    IEnumerator Argue()
    {
        ActionOverlay.SetActive(false);
        PhoneOverlay.SetActive(false);
        Dialog.SetActive(true);
        DiaText.text = "You have argued with " + enemyUnit.unitName + " and persuaded by " + playerUnit.damage + "%";

        yield return new WaitForSeconds(timePause);

        // if (enemyUnit.currentHP <= 0)
        // {
        //     DiaText.text = "You have persuaded " + enemyUnit.unitName + "!";
        //     yield return new WaitForSeconds(timePause);
        //     SceneManager.LoadSceneAsync(0);
        //     Destroy(enemyTransform.gameObject);
        // }

        DiaText.text = "Your morale went down by " + enemyUnit.damage + "%";

        yield return new WaitForSeconds(timePause);

        // if (playerUnit.currentHP <= 0)
        // {
        //     DiaText.text = "You have ran out of morale...";
        //     yield return new WaitForSeconds(timePause);
        //     SceneManager.LoadSceneAsync(0);
        //     playerTransform.position = new Vector2(0, 0);
        // }

        StartCoroutine(enemyTurn());
    }

    public void PTRun()
    {
        StartCoroutine(Run());
    }

    //public bool isNextScene = true;

   // [SerializeField] public SceneInfo sceneInfo;
    IEnumerator Run()
    {
      //  sceneInfo.isNextScene = isNextScene;
        ActionOverlay.SetActive(false);
        PhoneOverlay.SetActive(false);
        Dialog.SetActive(true);

        DiaText.text = "Run is successful";
        yield return new WaitForSeconds(timePause);
        SceneManager.LoadSceneAsync(0);
        playerTransform.position += (playerTransform.position - enemyTransform.position) * 0.5f;
    }

    IEnumerator enemyTurn()
    {
        DiaText.text = "The enemy decides to scold you";
        enemyAnimator.SetTrigger("Scold");

        yield return new WaitForSeconds(timePause);

        playerUnit.currentHP -= enemyUnit.damage;
        playerHUD.SetHP(playerUnit.currentHP);
        DiaText.text = "Your morale went down by " + enemyUnit.damage + "%";

        yield return new WaitForSeconds(timePause);

        // if (playerUnit.currentHP <= 0)
        // {
        //     DiaText.text = "You have ran out of morale...";
        //     yield return new WaitForSeconds(timePause);
        //     SceneManager.LoadSceneAsync(0);
        //     playerTransform.position = new Vector2(0, 0);
        // }

        DiaText.text = "It is your turn";

        yield return new WaitForSeconds(timePause);

        state = BattleState.PLAYERTURN;
        RecTurn += 1;
        PlayerTurn();
    }


}

