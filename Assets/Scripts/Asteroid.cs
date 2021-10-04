using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{   
    private Rigidbody2D rb;
    public float health = 100;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();    
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0) Die();
    }

    private void Die()
    {
        Destroy(gameObject);
    }
    
}
