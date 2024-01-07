using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInfo : MonoBehaviour
{
    //public OnLoad onload;
    public bool hasCat = false;
    public GameObject capturedCat = null;
    public Cat cat;
    public bool isNextScene = true;

    [SerializeField] 
    public SceneInfo sceneInfo;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("neighbour") && cat.isCaptured == false)
        {
            sceneInfo.isNextScene = isNextScene;
            Debug.Log("neighbour hit");
            
            SceneManager.LoadSceneAsync(1);
            //onload.gameObject.SetActive(false);

        }

    }
}
