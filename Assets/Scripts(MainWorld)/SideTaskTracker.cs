using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SideTaskTracker : MonoBehaviour
{
    public CatHouseUnlock catHouseUnlock;
    public TMP_Text sideTaskProgressText;
    public TMP_Text sideTaskText;
    public Transform vetTimerTransform;
    public GameObject sideTaskPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (catHouseUnlock.itemCount < 5)
        {
            sideTaskProgressText.text = $"Progress: {catHouseUnlock.itemCount}/5";
        }
        else
        {
            StartCoroutine(CompleteSideTask());
        }
        
    }

    IEnumerator CompleteSideTask()
    {
        sideTaskProgressText.text = $"";
        sideTaskText.fontSize = 56;
        sideTaskText.text = $"Cat house unlocked!";
        yield return new WaitForSeconds(2);
        sideTaskPanel.SetActive(false);
    }
}
