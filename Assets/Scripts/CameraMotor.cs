using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMotor : MonoBehaviour
{   
    [SerializeField] private Transform player;
    public float cameraBounds = 0.2f;
    public float speed = 1f;


    void Update()
    {
        moveCamera();
    }

    private void moveCamera()
    {
        Vector3 newPosition;

        newPosition.x = player.position.x * cameraBounds;
        newPosition.y = transform.position.y + speed * Time.deltaTime; 
        newPosition.z = -10f;

        transform.position = newPosition;
    }
}
