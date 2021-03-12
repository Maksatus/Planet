using UnityEngine;

public class DisableAfterCollision : DisableAfterTime
{
  private void OnCollisionEnter(Collision other)
  {
      var isPlayerObject = other.collider.GetComponent<Encounter>();
      
      if (isPlayerObject != null)
      {
          gameObject.SetActive(false);
      }
  }
}
