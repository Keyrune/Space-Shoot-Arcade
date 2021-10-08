using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{   
    [SerializeField]
    private Asteroid asteroidPrefab;
    public float waveCooldown = 2f;
    private float lastSpawn;
    public float waveNumber;


    public void SpawnWave()
    {
        Vector3 screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        if (Time.time < lastSpawn + waveCooldown) return;
        lastSpawn = Time.time;
        waveCooldown *= 0.97f;

        Vector3 spawnPosition = Vector3.zero;
        spawnPosition.x = Random.Range(-screenBounds.x, screenBounds.x);
        spawnPosition.y = screenBounds.y + 1f;

        Instantiate(asteroidPrefab, spawnPosition, new Quaternion(0, 0, 180, 1));
    }


}
