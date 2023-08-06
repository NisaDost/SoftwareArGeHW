using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Health : MonoBehaviour
{
    public float heartCooldown = 90f;
    [SerializeField] TMP_Text healthTimerText;
    bool noMoreLives = false;

    [SerializeField] static int health = 3;
    [SerializeField] int numOfHearts = 3;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    void Start()
    {
        //bunun yüzünden yanlış componenti buluyor
        healthTimerText = GameObject.Find("HealthTimerText").GetComponent<TMP_Text>();
        healthTimerText.enabled = false;
    }
    void Update()
    {
        if (noMoreLives == true && heartCooldown > 0)
        {
            heartCooldown -= Time.deltaTime;
            StartHealthTimer(heartCooldown);
        }

        if (health > numOfHearts)
        {
            health = numOfHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else hearts[i].sprite = emptyHeart;

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else hearts[i].enabled = false;
        }
    }

    public int ReduceHealth()
    {
        health--;
        if (health <= 0)
        {
            health = 0;
            noMoreLives = true;
        }
        return health;
    }

    public void StartHealthTimer(float timeToDisplay)
    {
        healthTimerText.enabled = true; 
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;
        }
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        healthTimerText.text = string.Format("{0:00}:{1:00}", minutes, seconds); 
    }
    public int GetHealth()
    {
        return health;
    }
    
}
