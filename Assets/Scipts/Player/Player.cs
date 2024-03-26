using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody _rigidbody;
    float horizontal;
    float vertical;
    Vector3 m_Movement;
    public float _maxWalkSpeed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
    }
    private void FixedUpdate()
    {
        Movement();
    }
    void Movement()
    {
        m_Movement.Set(horizontal, 0, vertical);
        m_Movement.Normalize();
        _rigidbody.MovePosition(_rigidbody.position + m_Movement * _maxWalkSpeed * Time.fixedDeltaTime);
    }
}
