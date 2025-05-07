using System;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float speed;
 
    private Rigidbody _rb;
    public bool isBeingPushed;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        if (GameDirector.instance.gamePlayState == GamePlayState.AppleCollected && !isBeingPushed)
        {
            FollowPlayer();
        }
    }

    public void GetPushedByBeacon(Vector3 dir, float pushPower)
    {
        isBeingPushed = true;
        _rb.linearVelocity = dir * pushPower;
        Invoke(nameof(DisableIsBeingPushed), 1f);
    }

    void DisableIsBeingPushed()
    {
        isBeingPushed = false;
    }

    private void FollowPlayer()
    {
        var direction = GameDirector.instance.player.transform.position - transform.position;
        _rb.linearVelocity = direction.normalized * speed;
    }
}
