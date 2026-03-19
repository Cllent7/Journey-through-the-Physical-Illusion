using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NPC : MonoBehaviour
{
    public GameObject talkPanel; // 对话框面板

    private bool canTalk; // 是否可以对话（玩家是否靠近 NPC）
    private bool isTalk; // 当前是否正在对话

    private void Update()
    {
       
        if (canTalk && Input.GetKeyDown(KeyCode.E))
        {
            if (isTalk == false)
            {
                isTalk = true;
                talkPanel.SetActive(true);
            }
            else
            {
                isTalk = false;
                talkPanel.SetActive(false);
            }
        }
    }

    // 当玩家进入 NPC 的触发器范围时，允许对话
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTalk = true;
            //Debug.Log("Player can talk now.");
        }
    }

    // 当玩家离开 NPC 的触发器范围时，禁止对话并关闭对话框
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTalk = false;
            isTalk = false; 
            talkPanel.SetActive(false);
            //Debug.Log("Player cannot talk now.");
        }
    }
}
