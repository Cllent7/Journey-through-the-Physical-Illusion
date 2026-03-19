using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaitingCanvas : MonoBehaviour
{
    public Image waitingImage;
    public static WaitingCanvas Instance;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
           
        }
       
    }

    public void Waiting() 
    {
        
            waitingImage.enabled = true;
           
        

    }
}
