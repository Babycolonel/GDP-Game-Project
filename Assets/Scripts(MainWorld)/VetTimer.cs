using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class VetTimer : MonoBehaviour
{
    public Vet vetScript;
    public TMP_Text vetTimerText;
    public GameObject timerPanel;
    
    private string vetTimerString;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (vetScript.timeTillHeal > 0 || vetScript.timeTillSpay > 0)
        {
            timerPanel.SetActive(true);
            vetTimerString = vetScript.secondsShown;
            vetTimerText.text = $"Cat ready in: {vetScript.secondsShown}s";
        }
        else
        {
            timerPanel.SetActive(false);
        }
        
    }
}
