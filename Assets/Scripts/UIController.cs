using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Transform[] objects; // 可滑落物体
    public Transform platformTop; // 斜面顶部
    public Transform platformBottom; // 斜面底部

    public Text[] texts;

    public float gravity = -9.81f; // 重力加速度

    private int selectObjectIndex = 0; // 当前选中物体的索引
    private int selectTime;

    private float[] startTime; // 滑落开始时间
    private bool[] isSliding; // 是否正在滑落

    // Start is called before the first frame update
    void Start()
    {
        // 检查 objects 和 texts 数组长度是否一致
        if (objects.Length != texts.Length)
        {
            Debug.LogError("objects 数组和 texts 数组长度不一致，请确保它们长度相同。");
            return;
        }

        // 初始化物体位置
        foreach (Transform t in objects)
        {
            Rigidbody rb = t.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.useGravity = false; // 禁用重力
            }
            //t.position = platformTop.position;
        }

        //初始化计时数据
        startTime = new float[objects.Length];
        isSliding = new bool[objects.Length];

        for (int i = 0; i < texts.Length; i++)
        {
            texts[i].text = "Time:0.0s";
        }

    }

    // Update is called once per frame
    void Update()
    {
        // 选择物体
        if (Input.GetKeyDown(KeyCode.Alpha1) && objects.Length > 0)
        {
            selectObjectIndex = 0;
            //text2.text = "Selected: Object 1";
            selectTime = 0;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && objects.Length > 1)
        {
            selectObjectIndex = 1;
            //text2.text = "Selected: Object 2";
            selectTime = 1;
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && objects.Length > 2)
        {
            selectObjectIndex = 2;
            selectTime = 2;
            //text2.text = "Selected: Object 3";
        }

        // 开始滑落
        if (Input.GetKeyDown(KeyCode.Tab) && selectObjectIndex != -1 && !isSliding[selectObjectIndex])
        {
            StartSliding();
        }

        // 更新滑落时间
        if (selectObjectIndex >= 0 && selectObjectIndex < objects.Length && isSliding[selectObjectIndex])
        {
            // 检查物体是否被销毁
            if (objects[selectObjectIndex] != null)
            {
                float elapsedTime = Time.time - startTime[selectObjectIndex];
                texts[selectObjectIndex].text = "Time:" + elapsedTime.ToString();
                // 检测物体是否到达底部
                if (objects[selectObjectIndex].position.y <= platformBottom.position.y)
                {
                    StopSliding();
                }
            }
            else
            {
                // 物体已被销毁，重置状态
                isSliding[selectObjectIndex] = false;
                selectObjectIndex = -1;
            }
        }
    }

    public void StartSliding()
    {
        // 检查物体是否被销毁
        if (objects[selectObjectIndex] != null)
        {
            // 将选中的物体移动到斜面顶部
            objects[selectObjectIndex].position = platformTop.position;

            // 获取 Rigidbody 组件并设置初始速度
            Rigidbody rb = objects[selectObjectIndex].GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.velocity = Vector3.zero;
                rb.useGravity = true; // 启用重力
            }
            else
            {
                Debug.LogError("Selected object does not have a Rigidbody component.");
            }

            // 开始计时
            startTime[selectObjectIndex] = Time.time;
            isSliding[selectObjectIndex] = true;
        }
        else
        {
            Debug.LogError("Selected object has been destroyed.");
            selectObjectIndex = -1;
        }
    }

    public void StopSliding()
    {
        // 停止计时
        isSliding[selectObjectIndex] = false;
        // 获取 Rigidbody 组件并停止运动
        Rigidbody rb = objects[selectObjectIndex].GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.velocity = Vector3.zero;
            rb.useGravity = false; // 禁用重力
        }

        // 获取游戏对象并销毁
        GameObject go = objects[selectObjectIndex].gameObject;
        Destroy(go, 1);

        // 更新 objects 数组
        List<Transform> objectList = objects.ToList();
        objectList.RemoveAt(selectObjectIndex);
        objects = objectList.ToArray();

        // 更新 startTime 和 isSliding 数组
        List<float> startTimeList = startTime.ToList();
        startTimeList.RemoveAt(selectObjectIndex);
        startTime = startTimeList.ToArray();

        List<bool> isSlidingList = isSliding.ToList();
        isSlidingList.RemoveAt(selectObjectIndex);
        isSliding = isSlidingList.ToArray();

        // 更新 texts 数组
        List<Text> textList = texts.ToList();
        textList.RemoveAt(selectObjectIndex);
        texts = textList.ToArray();

        // 重置选中索引
        selectObjectIndex = -1;
    }
}