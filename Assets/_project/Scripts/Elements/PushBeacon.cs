using UnityEngine;

public class PushBeacon : MonoBehaviour
{
    public float pushForce;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var enemy = collision.gameObject.GetComponent<Enemy>();
            enemy.GetPushedByBeacon(enemy.transform.position - transform.position, pushForce);
        }
    }
}
