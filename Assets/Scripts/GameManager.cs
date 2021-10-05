﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float spawnTime = 5f;
    public Asteroid asteroidPrefab;
    private Vector2 screenBounds;
    private float lastSpawn = 0f;
    public float restartDelay = 1f;
    

    void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        SpawnAsteroid();
    }

    private void SpawnAsteroid()
    {  
        if (Time.time < lastSpawn + 2f) return;
        lastSpawn = Time.time;

        Vector3 spawnPosition = Vector3.zero;
        spawnPosition.x = Random.Range(-screenBounds.x, screenBounds.x);
        spawnPosition.y = screenBounds.y + 1f;

        Instantiate(asteroidPrefab, spawnPosition, new Quaternion(0, 0, 180, 1));
    }

    private void ClearOfScreen()
    {

    }

    public void GameOver()
    {
        Debug.Log("Game over");
        Invoke("RestartGame", restartDelay);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}