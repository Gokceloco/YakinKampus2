using UnityEngine;

public class Cube : MonoBehaviour
{
    public CubeSurferPlayer player;
    public bool isCollected;

    private void OnTriggerEnter(Collider other)
    {
        if (isCollected && other.CompareTag("Cube") && !other.GetComponent<Cube>().isCollected)
        {
            player.CollectCube(other.GetComponent<Cube>());
        }
        if (other.CompareTag("Obstacle"))
        {
            
        }
    }
}
