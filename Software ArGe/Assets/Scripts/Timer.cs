using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    BalloonCounter balloonCounter;
    Health health;
    float currentTime = 0f;
    float startingTime = 30f;

    [SerializeField] TMP_Text TimerCoundown;
    
    void Start()
    {
        health = FindObjectOfType<Health>();
        balloonCounter = FindObjectOfType<BalloonCounter>();
        currentTime = startingTime;
    }

    void Update()
    {
        currentTime -= 1f * Time.deltaTime;
        TimerCoundown.text = currentTime.ToString("0");

        if (currentTime < 10)
        {
            TimerCoundown.color = Color.red;
        }
        if (currentTime <= 0)
        {
            currentTime = 0;
            Time.timeScale = 0;
            if (balloonCounter.redBalloonCheck == true 
                && balloonCounter.yellowBalloonCheck == true 
                && balloonCounter.blueBalloonCheck == true)
            {
                Debug.Log("You Win");
                //next level panel   
            }
            else
            {
                Debug.Log("You Lose");
                health.ReduceHealth(); //update içinde olduğundan düzgün çalışmıyor
                //restart panel
            }
        }
    }
}
