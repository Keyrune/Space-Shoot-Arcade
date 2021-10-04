using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveX;
    public float offsetY = -3.5f;

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            touchPosition.z = 0f;
            
            transform.position = touchPosition;

        }

    }
}
