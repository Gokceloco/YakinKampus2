using UnityEngine;

public class PushBeacon : MonoBehaviour
{
    public float pushForce;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            var direction = transform.position - collision.transform.position;
            collision.gameObject.GetComponent<Enemy>().PushEnemy(direction * pushForce);
            print(direction);            

        }
    }
}
