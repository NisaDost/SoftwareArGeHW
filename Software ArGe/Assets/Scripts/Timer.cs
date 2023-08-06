using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    BalloonCounter balloonCounter;
    Health health;
    Level1EndPanel levelEndPanel;

    float currentTime = 0f;
    float startingTime = 30f;
    
    bool isLevelWon = true;
    bool isLevelLose = true;

    [SerializeField] TMP_Text TimerCoundown;
    
    void Start()
    {
        Time.timeScale = 1;
        balloonCounter = FindObjectOfType<BalloonCounter>();
        health = FindObjectOfType<Health>();
        levelEndPanel = GetComponent<Level1EndPanel>();

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

        if (balloonCounter.UpdateChecks())
        {
            Time.timeScale = 0;
            if (isLevelWon == true) // win yazısını 1 kere almak için
            {
                Debug.Log("You Win");
                isLevelWon = false;
                levelEndPanel.WonPanel();
            }  
        }
        
        if (currentTime <= 0)
        {
            currentTime = 0;
            Time.timeScale = 0;//timescale 0 iken health timer çalışmıyor
            
            if (balloonCounter.UpdateChecks() == false) 
            {
                if (isLevelLose == true) // lose yazısını 1 kere almak için
                {
                    Debug.Log("You Lose");
                    isLevelLose = false;
                    levelEndPanel.LosePanel();
                } 
                //restart panel
            }
        }
    }
}
