using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private Rigidbody2D rb;
    public float damage = 60;
    public float speed = 20f;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Asteroid asteroid = hitInfo.GetComponent<Asteroid>();
        if (asteroid != null)
        {
            asteroid.TakeDamage(damage);
        }

        Destroy(gameObject);
    }

}
