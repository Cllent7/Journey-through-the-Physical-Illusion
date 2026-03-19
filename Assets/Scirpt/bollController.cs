using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 下落物体控制器
/// 挂载在每个下落物体上（如两个球体）
/// </summary>
public class bollController : MonoBehaviour
{
     public Rigidbody rb;

   
    public float spawnHeight = 55.86f;

    // 属性封装
    public bool IsLanded { get; private set; } // 是否已触地
    public float FallTime { get; private set; } // 下落时间

    private Vector3 initialPosition; // 初始位置
    private float airResistance; // 空气阻力

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        // 初始化位置：保持XZ轴不变，Y轴设置为生成高度
        initialPosition = new Vector3(
            transform.position.x,
            spawnHeight,
            transform.position.z
        );

        // 初始禁用物理模拟
        rb.isKinematic = true;
    }
    //空气阻力
    public void SetAirResistance(float value)
    {
        airResistance = value;
        rb.drag = airResistance;
    }
    /// <summary>
    /// 重置物体状态
    /// </summary>
    public void ResetObject()
    {
        // 复位位置和速度
        transform.position = initialPosition;
        rb.velocity = Vector3.zero;
        rb.isKinematic = false; // 启用物理模拟
        IsLanded = false;
    }

    /// <summary>
    /// 停止物体运动
    /// </summary>
    public void StopMovement()
    {
        rb.isKinematic = true; // 禁用物理模拟
    }

    /// <summary>
    /// 碰撞检测回调
    /// </summary>
    void OnCollisionEnter(Collision collision)
    {

        // 检测是否碰撞到地面
        if (collision.gameObject.CompareTag("Ground"))
        {
            IsLanded = true;
            // 计算下落时间：当前时间 - 实验开始时间
            FallTime = Time.time - FindObjectOfType<ExperimentManager>().startTime;
        }
    }
}