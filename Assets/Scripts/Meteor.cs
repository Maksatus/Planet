using UnityEngine;

public class Meteor : MonoBehaviour
{
    public SphereCollider sphereCol;
    [SerializeField] private GameObject explosion;
    

    void OnCollisionEnter(Collision col)
    {
        Quaternion rot = Quaternion.LookRotation(transform.position.normalized);
        rot *= Quaternion.Euler(90f, 0f, 0f);
        Instantiate(explosion, col.contacts[0].point, rot);

        sphereCol.enabled = false;	  
        transform.position = Vector3.zero;
        this.enabled = false;
    }

}
