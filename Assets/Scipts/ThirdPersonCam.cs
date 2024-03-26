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
    //��ת�ٶ�
    public float rotationSpeed;
    private void Start()
    {
        //�������������Ϸ����
        Cursor.lockState = CursorLockMode.Locked;
        //������꣬����Ҳ��ɼ�
        Cursor.visible = false;
    }

    private void Update()
    {
        //������ת����
        Vector3 viewDir = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientaion.forward = viewDir.normalized;

        //��תplayer����
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 inputDir = Vector3.forward*verticalInput+Vector3.right*horizontalInput;

        if(inputDir != Vector3.zero )
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir, Time.deltaTime*rotationSpeed);
        }
    }
}
