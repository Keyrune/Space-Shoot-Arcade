using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public float spawnTime = 5f;
    public Asteroid asteroidPrefab;
    private Vector2 screenBounds;
    private float lastSpawn = 0f;
    public float restartDelay = 1f;
    
    public GameObject MainMenuUI;
    public GameObject GameUI;
    public bool playerActive = false;

    # region Spawn

    # endregion

    # region Score

    public float score;
    private float startTime;
    public Text scoreText;
    public Text highScoreText;

    # endregion

    private void Awake()
    {
        // score = GetComponent<Score>();
    }

    void Start()
    {
        Time.timeScale = 0f;
        startTime = Time.time;
        highScoreText.text = PlayerPrefs.GetFloat("HighScore", 0).ToString("0");
    }

    void Update()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, 0));
        SpawnAsteroid();
        noTouchControll();

        score = Time.time - startTime;
        scoreText.text = score.ToString("0");
        
        if (Input.touchCount > 0 && !playerActive)
        {
            StartGame();
        }

    }

    # region GameControll

    # endregion

    # region Spawn

    # endregion

    # region Score



    # endregion

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

    // show when lvl complited or player dead
    public void GameOver()
    {   
        Debug.Log("Game over");
        
        if (score > PlayerPrefs.GetFloat("HighScore", 0f))
        {
            PlayerPrefs.SetFloat("HighScore", score);
        }
        
        playerActive = false;

        Invoke("StopGame", restartDelay);
        
    }

    public void StartGame()
    {
        // Hide menu UI
        MainMenuUI.SetActive(false);
        GameUI.SetActive(true);

        Time.timeScale = 1f;

        // Fly offscreen

        // Start game timer
        startTime = Time.time;

        // Give controll to the player
        playerActive = true;
    }

    public void StopGame()
    {


        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    // slow game if no touch detected
    private void noTouchControll()
    {
        if (!playerActive) return;

        if (Input.touchCount > 0)
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, 1f, 5f * Time.deltaTime);
        }
        else
        {
            Time.timeScale = Mathf.Lerp(Time.timeScale, 0.05f, 5f * Time.deltaTime);
        }
    }

    private void TouchInput()
    {
        
    }

}
