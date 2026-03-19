using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Triggerta : MonoBehaviour
{
    public string na;
    public Image img;
    public Text tex;
    private void Start()
    {

        img.enabled = false;
        tex.enabled = false;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // 假设角色的标签是 "Player"
        {
            Debug.Log(1);

            StartCoroutine(timeWait2());

        }
    }
    IEnumerator timeWait2()
    {
        img.enabled = true;
        tex.enabled = true;
        yield return new WaitForSeconds(5);
        img.enabled = false;
        tex.enabled = false;
        SceneManager.LoadScene(na);
        
    }

    
}
