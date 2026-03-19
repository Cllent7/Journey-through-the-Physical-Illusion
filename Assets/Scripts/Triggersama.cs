using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggersama : MonoBehaviour
{
    public GameObject hotAirBollom; // 热气球的 GameObject
    public Rigidbody rb; // 热气球的 Rigidbody 组件
    public float speedUp = 5f; // 上升速度
    public float speedDown = 5f; // 下降速度
    public bool isUp = false; // 是否在上升
    public bool isDown = false; // 是否在下降
    public float High = 350f; // 最大高度
    public float Low = 259.1f; // 最低高度

    private void Update()
    {
        // 在 Update 中控制上升和下降
        if (isUp)
        {
            Up();
        }
        if (isDown)
        {
            Down();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        // 检测玩家是否在触发器内
        if (other.CompareTag("Player"))
        {
            // 按下 Q 键时上升
            if (Input.GetKey(KeyCode.Q))
            {
                isUp = true;
                Debug.Log("Up key pressed");
            }
            else
            {
                isUp = false;
            }

            // 按下 E 键时下降
            if (Input.GetKey(KeyCode.E))
            {
                isDown = true;
                Debug.Log("Down key pressed");
            }
            else
            {
                isDown = false;
            }
        }
    }

    private void Up()
    {
        // 如果当前高度低于最大高度，则上升
        if (hotAirBollom.transform.position.y < High)
        {
            rb.AddForce(Vector3.up * speedUp);
            Debug.Log("Hot air balloon is rising");
        }
        else
        {
            Debug.Log("Reached maximum height");
        }
    }

    private void Down()
    {
        // 如果当前高度高于最低高度，则下降
        if (hotAirBollom.transform.position.y > Low)
        {
            rb.AddForce(Vector3.down * speedDown);
            Debug.Log("Hot air balloon is descending");
        }
        else
        {
            Debug.Log("Reached minimum height");
        }
    }
}