using UnityEngine;

public class AnimalsMove : MonoBehaviour
{
    public bool isMove = false;
    
    [SerializeField] private float speed = 15f;
    [SerializeField] private float rotationSpeed = 70f;
    [SerializeField] private  Rigidbody rb;
    
    private float _rotation;
    void Update ()
    {
        _rotation = Input.GetAxis("Horizontal");
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
