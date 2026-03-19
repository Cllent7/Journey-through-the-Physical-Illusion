using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 实验流程核心控制器，负责协调各个组件
/// 挂载在空对象（如 ExperimentManager）
/// </summary>
public class ExperimentManager : MonoBehaviour
{
    
    public bollController heavyObject; // 质量大的物体
    public bollController lightObject;  // 质量小的物体

    private bool isExperimentRunning; // 实验运行状态
    public float startTime;          // 实验开始时间


    /// <summary>
    /// 外部调用的实验启动方法
    /// </summary>
    public void StartExperiment()
    {
        isExperimentRunning = true;
        startTime = Time.time; // 记录实验开始时间

        // 重置两个物体的状态
        heavyObject.ResetObject();
        lightObject.ResetObject();
    }

    /// <summary>
    /// 外部调用的实验重置方法
    /// </summary>
    public void ResetExperiment()
    {
        isExperimentRunning = false;
        // 停止物体运动
        heavyObject.StopMovement();
        lightObject.StopMovement();

        // 重置小球位置和状态
        heavyObject.ResetObject();
        lightObject.ResetObject();
    }

    void Update()
    {
        if (isExperimentRunning)
        {
            // 当两个物体都触地时结束实验
            if (heavyObject.IsLanded && lightObject.IsLanded)
            {
                GenerateReport();
                isExperimentRunning = false;
            }
        }
    }

    /// <summary>
    /// 生成实验报告并传递数据到UI
    /// </summary>
    private void GenerateReport()
    {
        // 计算理论下落时间公式：t = sqrt(2h/g)
        float theoreticalTime = Mathf.Sqrt(2 * 55.86f / 9.81f);

        // 获取 UI 控制器并显示结果
        ExperimentUIController uiController = FindObjectOfType<ExperimentUIController>();
        if (uiController != null)
        {
            uiController.ShowResult(
                heavyObject.FallTime,
                lightObject.FallTime,
                theoreticalTime);
        }
     
    }
}