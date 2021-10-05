using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{   
    private Rigidbody2D rb;
    public float health = 100;
    public float speed = 1f;
    public float collisionDamage = 60f;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();   
        rb.velocity = transform.up * speed; 
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

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player player = hitInfo.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(collisionDamage);
        }
    }
    
}
