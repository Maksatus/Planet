using UnityEngine;

public class Gravity : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidbodyBody;
    [SerializeField] private Transform planet;
    [SerializeField] private float gravity = -10f;
    
    private float rotationSpeed = 100;
    
    private void FixedUpdate()
    {
        GravityPlanet();
    }

    public void GravityPlanet()
    {
        rigidbodyBody.AddForce((transform.position-planet.position).normalized*gravity);
        
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.FromToRotation(transform.up,
            (transform.position - planet.position).normalized) * transform.rotation,rotationSpeed * Time.deltaTime);
    }
    
}
