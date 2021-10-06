using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Text scoreText;
    private float startTime;
    public float score;
    


    private void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        scoreText.text = (Time.time - startTime).ToString("0");
    }

    public void SetHighScore()
    {
        PlayerPrefs.SetFloat("HighScore", score);
    }

    public void ResetHighScore()
    {
        PlayerPrefs.SetFloat("HighScore", 0f);
    }

    public void UpdateScore()
    {
        scoreText.text = score.ToString("0");
    }

    public void AddScore(float amount)
    {
        score += amount;
    }

    public void ResetScore()
    {

    }

}
