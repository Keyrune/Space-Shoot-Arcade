using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score : MonoBehaviour
{
    public Text scoreText;
    private float startTime;


    private void Start()
    {
        startTime = Time.time;
    }

    void Update()
    {
        scoreText.text = (Time.time - startTime).ToString("0");
    }
}
