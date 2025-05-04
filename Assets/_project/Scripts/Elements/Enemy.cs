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

    private void FollowPlayer()
    {
        var direction = GameDirector.instance.player.transform.position - transform.position;
        _rb.linearVelocity = direction.normalized * speed;
    }
}
