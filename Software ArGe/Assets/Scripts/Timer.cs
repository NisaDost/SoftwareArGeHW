using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 12f;
    [SerializeField] TMP_Text TimerCoundown;
    
    void Start()
    {
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
        }
    }
}
