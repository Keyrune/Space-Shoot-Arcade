using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    private float length, startPos;
    public Transform cam;
    public float parallaxEffect;


    void Start()
    {
        startPos = transform.position.y;
        length = GetComponent<SpriteRenderer>().bounds.size.y / 5;
    }

    void Update()
    {
        float temp = cam.transform.position.y * (1 - parallaxEffect);
        float dist = cam.transform.position.y * parallaxEffect;

        transform.position = new Vector3(transform.position.x, startPos + dist, transform.position.z);

        if (temp > startPos + length) startPos += length;
        else if (temp < startPos - length) startPos -= length;
    }
}
