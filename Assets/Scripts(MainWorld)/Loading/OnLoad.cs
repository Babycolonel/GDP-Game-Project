using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnLoad : MonoBehaviour
{
    public Objects objects;
    public bool isNextScene = true;
    [SerializeField] SceneInfo sceneInfo;

    
    public static OnLoad instance { get; private set; }

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        else if (instance != this)
        {
            
            this.gameObject.SetActive(false);
            OnLoad.instance.objects.gameObject.SetActive(true);
        }

    }
    private void OnEnable()
    {
        Bruh();
    }



    public void Bruh()
    {
        //sceneInfo.isNextScene = isNextScene;
        if (sceneInfo.isNextScene == false)
        {
            Debug.Log("enabled");
            objects.gameObject.SetActive(true);
            //hasFunctionExecuted = true;
        }
        //else if (sceneInfo.isNextScene)
        //{
        //    Debug.Log("disabled");
        //    this.objects.gameObject.SetActive(true);
        //}
    }


}
