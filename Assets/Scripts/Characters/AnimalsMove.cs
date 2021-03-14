using System;
using UnityEngine;

public class AnimalsMove : MonoBehaviour
{
    public bool isMove = false;
    
    [SerializeField] private float speed = 15f;
    [SerializeField] private float rotationSpeed = 70f;
    [SerializeField] private  Rigidbody rb;
    
    private float _rotation;
    private bool _platfrom = true; //true - android

    private void Awake()
    {
#if UNITY_ANDROID && !UNITY_EDITOR
       _platfrom = true;
#else
        _platfrom = false;
#endif
        Debug.Log(_platfrom);
    }
    

    void Update ()
    {
        _rotation = Input.GetAxis("Horizontal");
        Debug.Log(_rotation);
    }

    void FixedUpdate ()
    {
        if (isMove)
        {
            Move();
        }
    }

    private void Move()
    {
        rb.MovePosition(rb.position + transform.forward * (speed * Time.fixedDeltaTime));
        transform.Rotate(0f, _rotation * rotationSpeed * Time.fixedDeltaTime, 0f, Space.Self);
    }
}
