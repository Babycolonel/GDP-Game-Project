using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PhoneOverlay : MonoBehaviour
{
    public GameObject ObjectOverlay;

    public void ToggleOverlay()
    {
        ObjectOverlay.SetActive(!ObjectOverlay.activeSelf);
    }
}
