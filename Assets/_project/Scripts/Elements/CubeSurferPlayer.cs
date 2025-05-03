using System;
using System.Collections.Generic;
using UnityEngine;

public class CubeSurferPlayer : MonoBehaviour
{
    public float speed;

    public float sensitivity;

    public Transform cameraHolder;
    public Transform mainCamera;

    public List<Cube> collectedCubes;
    
    void Update()
    {
        MovePlayer();
        MoveCamera();
        OrderCubes();
    }

    private void OrderCubes()
    {
        var targetPos = transform.position;
        targetPos.y = collectedCubes.Count;
        transform.position = targetPos;

        for (int i = 0; i < collectedCubes.Count; i++)
        {
            collectedCubes[i].transform.position = transform.position + Vector3.down * (i+1);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Cube") && !other.GetComponent<Cube>().isCollected)
        {
            collectedCubes.Add(other.GetComponent<Cube>());
            other.GetComponent<Cube>().isCollected = true;
        }
    }

    private void MovePlayer()
    {
        var direction = Vector3.forward;
        if (Input.GetMouseButton(0))
        {
            direction += Input.GetAxis("Mouse X") * Vector3.right * sensitivity;
        }
        transform.position += direction * speed * Time.deltaTime;        
    }

    private void MoveCamera()
    {
        var targetPos = transform.position;
        targetPos.x = 0;
        targetPos.y = 0;
        cameraHolder.position = targetPos;
        mainCamera.transform.localPosition 
            = new Vector3(0,7 + collectedCubes.Count * .5f, -10 - collectedCubes.Count * .5f);
    }

    public void CollectCube(Cube cube)
    {
        collectedCubes.Add(cube);
        cube.isCollected = true;
    }
}
