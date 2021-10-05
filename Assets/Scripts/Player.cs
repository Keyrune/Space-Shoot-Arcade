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

    # endregion

    void Update()
    {
        if (Input.touchCount > 0)
        {
            Vector3 touchPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            touchPosition.z = 0f;
            
            transform.position = touchPosition;

        } 
        else
        {
            transform.position += new Vector3(0, Time.deltaTime, 0);
        }

        Shoot();

    }

    private void Shoot()
    {   
        if (canShoot)
        {
            canShoot = false;
            reloadTime = Time.time + 1 / fireRate;

            Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
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

}
