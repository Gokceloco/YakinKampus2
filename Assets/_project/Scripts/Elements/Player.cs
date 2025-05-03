using System;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed;

    public PlayerState playerState;

    private Rigidbody _rb;

    public Transform cameraHolder;

    void Start()
    {
        _rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        MovePlayer();
        MoveCamera();
    }

    void MoveCamera()
    {
        var targetPos = transform.position;
        targetPos.x = 0;
        cameraHolder.position = targetPos;
    }

    void MovePlayer()
    {
        var direction = Vector3.zero;

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            direction += Vector3.forward;
        }
        if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            direction += Vector3.back;
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            direction += Vector3.left;
        }
        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            direction += Vector3.right;
        }

        _rb.linearVelocity = direction.normalized * speed;

        transform.LookAt(transform.position + direction);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            gameObject.SetActive(false);
        }
    }

    
}


public enum PlayerState
{
    Idle,
    Walking,
    Stunned,
    Attacking,
    Dead,
}