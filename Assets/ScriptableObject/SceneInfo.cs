using UnityEngine;

[CreateAssetMenu(fileName = "SceneInfo", menuName = "GDP/SceneInfo", order = 0)]
public class SceneInfo: ScriptableObject
{
    public bool isNextScene = true;

    void OnEnable()
    {
        isNextScene = false;
    }
}

