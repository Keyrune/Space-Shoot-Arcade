using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveX;
    public float offsetY = -3.5f;

    # region Shoot

    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    private float reloadTime;
    private bool canShoot = true;
    public float speed = 0.2f;

    # endregion



    public void Shoot()
    {   
        if (canShoot)
        {
            canShoot = false;
            reloadTime = Time.time + 1 / fireRate;

            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            FindObjectOfType<AudioManager>().Play("Shoot");
        } 
        
        if (Time.time > reloadTime)
        {
            canShoot = true;
        }

    }

    public void TakeDamage(float amount)
    {
        FindObjectOfType<GameManager>().GameOver();
    }

    public void Move(Vector3 moveDirection) // move in direction of position
    {   

        transform.position += Vector3.ClampMagnitude(moveDirection, speed * Time.deltaTime);
    }

}
