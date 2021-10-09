using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{   
    [SerializeField] private Transform player;
    public float cameraBounds = 0.2f; // > 0
    public float speed = 1f;


    private void LateUpdate()
    {
        moveCamera();
    }

    private void moveCamera()
    {
        Vector3 newPosition;

        newPosition.x = player.position.x * (1 - (1 / (1 + cameraBounds))); // extend screen by camerabounds %
        newPosition.y = transform.position.y + speed * Time.deltaTime; 
        newPosition.z = -10f;

        transform.position = newPosition;
    }
}
