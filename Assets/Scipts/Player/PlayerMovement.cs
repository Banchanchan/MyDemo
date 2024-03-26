using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    //移动速度
    public float moveSpeed;

    public float groundDrag;
    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    public Transform orientaion;
    //移动方向
    Vector3 moveDirection;
    Rigidbody rb;
    float horizontalInput;
    float verticalInput;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }
    private void Update()
    {
        //Ground Check
        grounded = Physics.Raycast(transform.position,Vector3.down,playerHeight*0.5f+0.2f,whatIsGround);
        MyInput();
        SpeedControl();

        if (grounded)
            rb.drag = groundDrag;
        else
            rb.drag = 0;
    }
    private void FixedUpdate()
    {
        MyPlayer();
    }
    private void MyInput()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
    }
    private void MyPlayer()
    {
        //计算方向
        moveDirection = Vector3.forward*verticalInput+ Vector3.right*horizontalInput;
        rb.AddForce(moveDirection.normalized*moveSpeed*10f,ForceMode.Force);
    }
    private void SpeedControl()
    {
        Vector3 flatVel = new Vector3(rb.velocity.x,0f,rb.velocity.z);

        if (flatVel.magnitude > moveSpeed)
        {
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.y);
        }
    }
}
