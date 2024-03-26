using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCam : MonoBehaviour
{
    [Header("Reference")]
    public Transform orientaion;
    public Transform playerObj;
    public Transform player;
    public Rigidbody rb;
    //旋转速度
    public float rotationSpeed;
    private void Start()
    {
        //将鼠标锁定在游戏窗口
        Cursor.lockState = CursorLockMode.Locked;
        //隐藏鼠标，让玩家不可见
        Cursor.visible = false;
    }

    private void Update()
    {
        //设置旋转方向
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientaion.forward = viewDir.normalized;

        //旋转player方向
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = Vector3.forward*verticalInput+Vector3.right*horizontalInput;

        if(inputDir != Vector3.zero )
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir, Time.deltaTime*rotationSpeed);
        }
    }
}
