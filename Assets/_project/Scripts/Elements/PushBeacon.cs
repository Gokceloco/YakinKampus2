using UnityEngine;

public class PushBeacon : MonoBehaviour
{
    public float pushForce;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
                  

        }
    }
}
