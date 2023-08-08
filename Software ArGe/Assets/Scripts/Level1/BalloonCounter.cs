using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class BalloonCounter : MonoBehaviour
{
    [SerializeField] TMP_Text purpleBalloonCounter;
    [SerializeField] TMP_Text redBalloonCounter;
    [SerializeField] TMP_Text yellowBalloonCounter;
    [SerializeField] TMP_Text blueBalloonCounter;

    [SerializeField] GameObject[] checkImg;
    AudioSource audioSource;
    
    int purpleBalloonNum;
    int redBalloonNum;
    int yellowBalloonNum;
    int blueBalloonNum;

    public bool purpleBalloonCheck = false;
    public bool redBalloonCheck = false;
    public bool yellowBalloonCheck = false;
    public bool blueBalloonCheck = false;

    public bool isAllBalloonsChecked = false;
    
    void Awake()
    {
        purpleBalloonNum = Random.Range(3, 6);
        redBalloonNum = Random.Range(6, 9);
        yellowBalloonNum = Random.Range(9, 12);
        blueBalloonNum = Random.Range(12, 15);
        audioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        purpleBalloonCounter.text = purpleBalloonNum.ToString();
        redBalloonCounter.text = redBalloonNum.ToString();
        yellowBalloonCounter.text = yellowBalloonNum.ToString();
        blueBalloonCounter.text = blueBalloonNum.ToString();
    }

    public void ReduceRedBalloonNum()
    {
        this.redBalloonNum--;
        if (redBalloonNum <= 0)
        {
            redBalloonNum = 0;
            checkImg[0].SetActive(true);
            if (!redBalloonCheck) //plays only once
            {
                redBalloonCheck = true;
                audioSource.Play();
            }
        }
    }
    public void ReduceYellowBalloonNum()
    {
        this.yellowBalloonNum--;
        if (yellowBalloonNum <= 0)
        {
            yellowBalloonNum = 0;
            checkImg[1].SetActive(true);
            if (!yellowBalloonCheck)
            {
                yellowBalloonCheck = true;
                audioSource.Play();
            }
        }
    }
    public void ReduceBlueBalloonNum()
    {
        this.blueBalloonNum--;
        if (blueBalloonNum <= 0)
        {
            blueBalloonNum = 0;
            checkImg[2].SetActive(true);
            if (!blueBalloonCheck)
            {
                audioSource.Play();
                blueBalloonCheck = true;
            }
        }
    }
    
    public void ReducePurpleBalloonNum()
    {
        this.purpleBalloonNum--;
        if (purpleBalloonNum <= 0)
        {
            purpleBalloonNum = 0;
            checkImg[3].SetActive(true);
            if (!purpleBalloonCheck)
            {
                audioSource.Play();
                purpleBalloonCheck = true;
            }
        }
    }

    public void IncreaseRedBalloonNum()
    {
        if (redBalloonNum != 0)
        {
            this.redBalloonNum++;
        }
    }
    public void IncreaseYellowBalloonNum()
    {
        if (yellowBalloonNum != 0)
        {
            this.yellowBalloonNum++;
        }
    }
    public void IncreaseBlueBalloonNum()
    {
        if (blueBalloonNum != 0)
        {
            this.blueBalloonNum++;
        }
    }
    
    public bool UpdateChecks()
    {
        if(SceneManager.GetActiveScene().name == "Level1")
        {
            if (redBalloonCheck && yellowBalloonCheck && blueBalloonCheck)
            {
                isAllBalloonsChecked = true;
            }
        }
        else if (SceneManager.GetActiveScene().name == "Level2")
        {
            if (redBalloonCheck && yellowBalloonCheck && blueBalloonCheck && purpleBalloonCheck)
            {
                isAllBalloonsChecked = true;
            }
        }
        return isAllBalloonsChecked;
    }  
}
