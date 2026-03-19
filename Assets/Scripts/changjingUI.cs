using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class changjingUI : MonoBehaviour
{
   
    public GameObject changjingui;
    public GameObject ui;

    public void OnButton() 
    {
        ui.SetActive(false);
        changjingui.SetActive(true);
    }
}
