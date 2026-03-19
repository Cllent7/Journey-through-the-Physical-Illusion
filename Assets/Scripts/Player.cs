using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public float mouseSensitivity = 100.0f;
    public Transform playerCamera;          // 相机的Transform组件

    private float xRotation = 0.0f;
    private float xRotationLimit = 60.0f;

    private Rigidbody rb;

    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // 获取移动输入
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // 计算移动方向
        Vector3 move = transform.forward * z + transform.right * x;
        transform.position += move * moveSpeed * Time.deltaTime;

        // 获取鼠标输入
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -xRotationLimit, xRotationLimit);


        playerCamera.localRotation = Quaternion.Euler(xRotation, 0, 0);


        transform.Rotate(Vector3.up * mouseX);

        if (Input.GetKey(KeyCode.LeftShift))
        {
            moveSpeed = 10f;
        }
        else 
        {
            moveSpeed = 3f;
        }
    }
    
}
